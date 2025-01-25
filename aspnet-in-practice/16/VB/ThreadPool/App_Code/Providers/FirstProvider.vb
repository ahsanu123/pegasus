Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Threading

Public Class FirstProvider
	Implements IFlightPriceProvider
	Public Function GetFlightPrice(ByVal flightNumber As String) As FlightPriceResult Implements IFlightPriceProvider.GetFlightPrice
		' let's simulate a call to a remote resource
		Thread.Sleep(2000)

		' and return a fixed value
		Dim result As New FlightPriceResult()
		result.FlightNumber = flightNumber
		result.Price = 560
		Return result
	End Function

End Class