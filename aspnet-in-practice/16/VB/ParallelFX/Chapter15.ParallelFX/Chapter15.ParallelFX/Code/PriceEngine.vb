Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Threading
Imports System.Collections.Concurrent
Imports System.Threading.Tasks

Namespace ASPNET4InPractice.Chapter15
	Public Class PriceEngine
		Public Sub New(ByVal flightNumber__1 As String)
			FlightNumber = flightNumber__1
			FlightResults = New ConcurrentQueue(Of FlightPriceResult)()
		End Sub

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

		Private _FlightResults As ConcurrentQueue(Of FlightPriceResult)
		Public Property FlightResults() As ConcurrentQueue(Of FlightPriceResult)
			Get
				Return _FlightResults
			End Get
			Private Set(ByVal value As ConcurrentQueue(Of FlightPriceResult))
				_FlightResults = value
			End Set
		End Property

		Public Sub GetFlightPrices()
			StartTime = DateTime.Now
			Dim providers As IFlightPriceProvider() = GetProviders().ToArray()
			Dim tasks As Task() = New Task(providers.Length - 1) {}

			For i As Integer = 0 To providers.Length - 1
				tasks(i) = Task.Factory.StartNew(Function(currentProvider)
													 Return DirectCast(currentProvider, IFlightPriceProvider).GetFlightPrice(FlightNumber)
												 End Function,
				 providers(i))
			Next

			Task.Factory.ContinueWhenAll(tasks.ToArray(), Sub(currentTasks)
															  For Each currentTask As Task(Of FlightPriceResult) In currentTasks
																  FlightResults.Enqueue(currentTask.Result)
															  Next

															  EndTime = DateTime.Now
															  Completed = True
														  End Sub)
		End Sub

		Private Function GetProviders() As IEnumerable(Of IFlightPriceProvider)
			' load from configirutation
			Return New IFlightPriceProvider() {New FirstProvider(), New SecondProvider(), New FirstProvider(), New SecondProvider(), New FirstProvider(), New SecondProvider(), _
			New FirstProvider(), New SecondProvider(), New FirstProvider(), New SecondProvider(), New FirstProvider(), New SecondProvider(), _
			New FirstProvider(), New SecondProvider()}
		End Function
	End Class
End Namespace