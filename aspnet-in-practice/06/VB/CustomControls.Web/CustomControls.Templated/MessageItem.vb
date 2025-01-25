Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Web.UI

Public Class MessageItem
	Inherits Control
	Implements INamingContainer
	Private parentControl As Message
	Public Sub New(ByVal parent As Message)
		parentControl = parent
	End Sub

	Public ReadOnly Property Text() As String
		Get
			Return parentControl.Text
		End Get
	End Property
End Class