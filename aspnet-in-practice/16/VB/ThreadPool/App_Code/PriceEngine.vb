Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Threading

Public Class PriceEngine
	Public Sub New(ByVal number As String)
		FlightNumber = number
		FlightResults = New List(Of FlightPriceResult)()
	End Sub

	Private Sync As New Object()
	Private _FlightNumber As String
	Public Property FlightNumber() As String
		Get
			Return _FlightNumber
		End Get
		Private Set(ByVal value As String)
			_FlightNumber = value
		End Set
	End Property
	Private _Completed As Boolean
	Public Property Completed() As Boolean
		Get
			Return _Completed
		End Get
		Private Set(ByVal value As Boolean)
			_Completed = value
		End Set
	End Property
	Private _StartTime As DateTime
	Public Property StartTime() As DateTime
		Get
			Return _StartTime
		End Get
		Private Set(ByVal value As DateTime)
			_StartTime = value
		End Set
	End Property
	Private _EndTime As DateTime
	Public Property EndTime() As DateTime
		Get
			Return _EndTime
		End Get
		Private Set(ByVal value As DateTime)
			_EndTime = value
		End Set
	End Property
	Private _FlightResults As List(Of FlightPriceResult)
	Public Property FlightResults() As List(Of FlightPriceResult)
		Get
			Return _FlightResults
		End Get
		Private Set(ByVal value As List(Of FlightPriceResult))
			_FlightResults = value
		End Set
	End Property

	Public Sub GetFlightPrices()
		StartTime = DateTime.Now
		Try
			Dim handleList As New List(Of WaitHandle)()
			For Each provider As IFlightPriceProvider In GetProviders()
				Dim handle As New ManualResetEvent(False)
				handleList.Add(handle)
				Dim currentState As New Tuple(Of IFlightPriceProvider, ManualResetEvent)(provider, handle)

				ThreadPool.QueueUserWorkItem(AddressOf ExecuteProvider, currentState)
			Next
            ' finally, re-join the threads

			WaitHandle.WaitAll(handleList.ToArray())
		Finally
			EndTime = DateTime.Now
			Completed = True
		End Try
	End Sub

	Private Sub ExecuteProvider(ByVal state As Object)
		Dim invokeState As Tuple(Of IFlightPriceProvider, ManualResetEvent) = DirectCast(state, Tuple(Of IFlightPriceProvider, ManualResetEvent))

		Dim result As FlightPriceResult = Nothing
		Dim currentProvider As IFlightPriceProvider = invokeState.Item1
		result = currentProvider.GetFlightPrice(FlightNumber)

		' entering a lock
        Dim lockTaken As Boolean = False
        Monitor.Enter(Sync, lockTaken)
		Try
			' only a thread can modify the List
			FlightResults.Add(result)
		Finally
            ' closing the lock, using a try...finally to avoid deadlocks
            If lockTaken Then
                Monitor.Exit(Sync)
            End If
		End Try

		Dim resetHandle As ManualResetEvent = invokeState.Item2
		resetHandle.Set()
	End Sub

	Private Sub GetProviderData(ByVal parameter As Object)
		Dim result As FlightPriceResult = Nothing
		Dim provider As IFlightPriceProvider = TryCast(parameter, IFlightPriceProvider)
		If provider IsNot Nothing Then
			result = provider.GetFlightPrice(FlightNumber)
		End If

        ' entering a lock
        Dim lockTaken As Boolean = False
        Monitor.Enter(Sync, lockTaken)
		Try
			' only a thread can modify the List
			FlightResults.Add(result)
		Finally
            ' closing the lock, using a try...finally to avoid deadlocks
            If lockTaken Then
                Monitor.Exit(Sync)
            End If
		End Try
	End Sub

	Private Function GetProviders() As IEnumerable(Of IFlightPriceProvider)
		' load from web.config
		Return New IFlightPriceProvider() {New FirstProvider(), New SecondProvider()}
	End Function
End Class