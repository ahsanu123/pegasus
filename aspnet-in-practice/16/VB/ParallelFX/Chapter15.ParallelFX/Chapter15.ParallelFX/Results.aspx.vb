Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports Chapter15.ParallelFX.ASPNET4InPractice.Chapter15

Partial Public Class Results
	Inherits Page

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
		Dim engine As PriceEngine = TryCast(Session("engine"), PriceEngine)
		If engine Is Nothing Then
			Response.Redirect("./")
		End If

		If engine.Completed Then
			ResultsPanel.Visible = True
			ResultList.DataSource = engine.FlightResults
			ResultList.DataBind()

			Feedback.Text = String.Format("Elapsed time: {0}", engine.EndTime.Subtract(engine.StartTime))
		Else
			WaitingPanel.Visible = True

			' programmatically add a refresh meta tag
			Dim meta As New HtmlMeta()
			meta.HttpEquiv = "refresh"
			meta.Content = "2"
			Header.Controls.Add(meta)
		End If
	End Sub
End Class