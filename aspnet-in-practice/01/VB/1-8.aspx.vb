
Partial Class _1_8
	Inherits System.Web.UI.Page

	Sub HandleSubmit(ByVal sender As Object, ByVal e As EventArgs)
		If Page.IsValid Then
			FormContainer.Visible = False
			FormResponse.Visible = True

			ResponseText.Text = String.Format("Hello {0} {1} from {2}", _
			   FirstName.Text, _
			   LastName.Text, _
			   Country.SelectedItem.Text)
		End If
	End Sub

End Class
