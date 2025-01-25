Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Hosting
Imports System.Collections

Namespace ASPNET4InPractice
	Public Class DatabaseDirectory
		Inherits VirtualDirectory
		Private _directories As New List(Of String)()
		Private _files As New List(Of String)()
		Private _children As New List(Of String)()

		Public Sub New(ByVal virtualPath As String)
			MyBase.New(virtualPath)
		End Sub

		Public Overloads Overrides ReadOnly Property Children() As IEnumerable
			Get
				Return _children
			End Get
		End Property

		Public Overloads Overrides ReadOnly Property Directories() As IEnumerable
			Get
				Return _directories
			End Get
		End Property

		Public Overloads Overrides ReadOnly Property Files() As IEnumerable
			Get
				Return _files
			End Get
		End Property
	End Class
End Namespace