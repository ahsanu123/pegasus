Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web

Public Interface IFlightPriceProvider
	Function GetFlightPrice(ByVal flightNumber As String) As FlightPriceResult
End Interface