Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class [Default]
	Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		If Not IsPostBack Then
			Dim profile As MyProfile = TryCast(MyProfile.Create(User.Identity.Name), MyProfile)

			FirstName.Text = profile.FirstName

			BirthDay.Text = profile.BirthDay.GetValueOrDefault().ToShortDateString()
		End If

	End Sub

	Protected Sub Unnamed1_Click(ByVal sender As Object, ByVal e As EventArgs)
		Dim profile As MyProfile = TryCast(MyProfile.Create(User.Identity.Name), MyProfile)
		profile.BirthDay = (If(String.IsNullOrEmpty(BirthDay.Text), DirectCast(Nothing, System.Nullable(Of DateTime)), Convert.ToDateTime(BirthDay.Text)))
		profile.FirstName = FirstName.Text
		profile.Save()
	End Sub
End Class
