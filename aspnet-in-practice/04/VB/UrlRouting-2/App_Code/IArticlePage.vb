Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Web
Imports System.Web.UI

Public Interface IArticlePage
	Inherits IHttpHandler
	Property Id() As Integer
	Property Description() As String
End Interface