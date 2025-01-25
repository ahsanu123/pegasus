Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Hosting
Imports System.IO

Namespace ASPNET4InPractice
	Public Class DatabaseFile
		Inherits VirtualFile
		Public Sub New(ByVal virtualPath As String)
			MyBase.New(virtualPath)
		End Sub

		Public ReadOnly Property LastModifiedTimeStamp() As Byte()
			Get
				Return Utility.GetLastModifiedTimeStamp(VirtualPathUtility.ToAppRelative(VirtualPath))
			End Get
		End Property

		Public Overloads Overrides Function Open() As Stream
			' get file contents and write to the stream
			Dim fileContents As String = Utility.GetFileContents(VirtualPathUtility.ToAppRelative(VirtualPath))
			Dim stream As Stream = New MemoryStream()
			If Not String.IsNullOrEmpty(fileContents) Then
				Dim writer As New StreamWriter(stream)
				writer.Write(fileContents)
				writer.Flush()
				stream.Seek(0, SeekOrigin.Begin)
			End If
			Return stream
		End Function
	End Class
End Namespace