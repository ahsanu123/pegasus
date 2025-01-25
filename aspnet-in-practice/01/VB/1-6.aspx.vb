
Partial Class _1_6
    Inherits System.Web.UI.Page

	Sub HandleSubmit(ByVal sender As Object, ByVal e As EventArgs)
		ResponseText.Text = String.Format("Hello {0} {1} from {2}", _
		  FirstName.Text, _
		  LastName.Text, _
		  Country.SelectedItem.Text)
	End Sub

End Class
