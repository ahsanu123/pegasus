Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Configuration
Imports VirtualFileSystemModel

Namespace ASPNET4InPractice
	Friend Module Utility
		Friend ReadOnly Property BasePath() As String
			Get
				Return If(ConfigurationManager.AppSettings("virtualDirectory"), "~/")
			End Get
		End Property

		Friend Function FileExists(ByVal virtualPath As String) As Boolean
			Using ctx As New VirtualFileSystemEntities()
				Return ctx.VirtualFiles.Count(Function(x) x.VirtualPath.Equals(virtualPath)) > 0
			End Using
		End Function

		Friend Function GetFileContents(ByVal virtualPath As String) As String
			Using ctx As New VirtualFileSystemEntities()
				Return ctx.VirtualFiles.First(Function(x) x.VirtualPath.Equals(virtualPath)).Contents
			End Using
		End Function

		Friend Function GetLastModifiedTimeStamp(ByVal virtualPath As String) As Byte()
			Using ctx As New VirtualFileSystemEntities()
				Return ctx.VirtualFiles.First(Function(x) x.VirtualPath.Equals(virtualPath)).LastUpdated
			End Using
		End Function
	End Module
End Namespace