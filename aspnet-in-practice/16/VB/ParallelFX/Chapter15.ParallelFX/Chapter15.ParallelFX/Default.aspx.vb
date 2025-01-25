Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Threading
Imports Chapter15.ParallelFX.ASPNET4InPractice.Chapter15

Partial Public Class _Default
	Inherits System.Web.UI.Page
	Protected Sub StartWork_Click(ByVal sender As Object, ByVal e As EventArgs)
		' let's start a new instance, and then save in session
		Dim engine As New PriceEngine(FlightNumber.Text)
		engine.GetFlightPrices()

		Session("engine") = engine

		' redirect on a waiting page
		Response.Redirect("results.aspx")
	End Sub

End Class