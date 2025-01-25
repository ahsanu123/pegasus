Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Web.UI
Imports System.Web.UI.WebControls

' base class, used to handle the parts in a similar way
Public Class CMSPartBase
	Inherits WebControl
	Protected Sub New()

		MyBase.New()
	End Sub

	' more common properties here - use ViewState if needed
	Public Overridable Property PageSize() As Integer

	Public Property Title() As String
End Class