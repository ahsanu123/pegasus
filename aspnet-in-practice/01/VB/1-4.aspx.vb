
Partial Class _1_4
	Inherits System.Web.UI.Page

	Sub HandleSubmit(ByVal sender As Object, ByVal e As EventArgs)
		ResponseText.Text = "Your name is: " & Name.Text
	End Sub

End Class