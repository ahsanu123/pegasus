Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.IO

Public Class BasePage
	Inherits Page
	Protected Overloads Overrides Sub OnPreInit(ByVal e As EventArgs)
		Dim masterPage As String = File.ReadAllText(Server.MapPath("~/App_Data/MasterPage.config"))
		If Not String.IsNullOrEmpty(masterPage) Then
			MasterPageFile = masterPage
		End If

		MyBase.OnPreInit(e)
	End Sub
End Class