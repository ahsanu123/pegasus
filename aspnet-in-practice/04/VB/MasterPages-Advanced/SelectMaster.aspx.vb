Imports System
Imports System.IO

Partial Public Class SelectMaster
	Inherits Page

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		If Not IsPostBack Then
			MasterList.DataSource = Directory.GetFiles(Server.MapPath("~/Masters/")).[Select](Function(x) x.Substring(x.LastIndexOf("\") + 1))
			MasterList.DataBind()

			Dim currentMaster As String = File.ReadAllText(Server.MapPath("~/App_Data/MasterPage.config"))
			MasterList.SelectedValue = currentMaster.Substring(currentMaster.LastIndexOf("/") + 1)
		End If
	End Sub

	Protected Sub SaveMasterPage(ByVal sender As Object, ByVal e As EventArgs)
		File.WriteAllText(Server.MapPath("~/App_Data/MasterPage.config"), "~/Masters/" & MasterList.SelectedValue)
	End Sub

End Class