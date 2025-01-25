Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Threading

Partial Public Class _Default
	Inherits System.Web.UI.Page
	Protected Sub StartWork_Click(ByVal sender As Object, ByVal e As EventArgs)
		' let's start a new instance, and then save in session
		Dim engine As New PriceEngine(FlightNumber.Text)

		Session("engine") = engine

		' the thread will start the work and immediately execute the next statement
		ThreadPool.QueueUserWorkItem(AddressOf Execute, engine)

		' redirect on a waiting page
		Response.Redirect("results.aspx")
	End Sub

	Protected Sub Execute(ByVal state As Object)
		Dim priceEngine As PriceEngine = DirectCast(state, PriceEngine)
		priceEngine.GetFlightPrices()
	End Sub
End Class