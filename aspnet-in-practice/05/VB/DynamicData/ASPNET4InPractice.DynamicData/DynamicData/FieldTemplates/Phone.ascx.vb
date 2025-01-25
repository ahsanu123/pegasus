Imports System
Imports System.Collections.Specialized
Imports System.ComponentModel.DataAnnotations
Imports System.Web.DynamicData
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class PhoneField
	Inherits System.Web.DynamicData.FieldTemplateUserControl
	Protected Overloads Overrides Sub OnDataBinding(ByVal e As EventArgs)
		HyperLinkUrl.NavigateUrl = GetUrl(FieldValueString)
	End Sub

	Private Function GetUrl(ByVal phone As String) As String
		Return If(String.IsNullOrEmpty(phone), "#", String.Concat("callto:", phone))
	End Function

	Public Overloads Overrides ReadOnly Property DataControl() As Control
		Get
			Return HyperLinkUrl
		End Get
	End Property
End Class