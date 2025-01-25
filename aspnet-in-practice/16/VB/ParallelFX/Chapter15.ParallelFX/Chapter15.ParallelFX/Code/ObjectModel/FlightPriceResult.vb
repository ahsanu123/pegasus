Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web

Public Class FlightPriceResult
Private _FlightNumber As String
    Public Property FlightNumber() As String
        Get
            Return _FlightNumber
        End Get
        Set(ByVal value As String)
            _FlightNumber = value
        End Set
    End Property
Private _Price As Double
    Public Property Price() As Double
        Get
            Return _Price
        End Get
        Set(ByVal value As Double)
            _Price = value
        End Set
    End Property
End Class