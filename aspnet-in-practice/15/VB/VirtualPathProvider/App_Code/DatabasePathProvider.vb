Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Hosting
Imports System.Configuration
Imports System.Web.Caching

Namespace ASPNET4InPractice
	Public Class DatabasePathProvider
		Inherits VirtualPathProvider
		Public Sub New()
			MyBase.New()
		End Sub

		Public Overloads Overrides Function GetCacheDependency(ByVal virtualPath As String, ByVal virtualPathDependencies As System.Collections.IEnumerable, ByVal utcStart As DateTime) As System.Web.Caching.CacheDependency
			If IsVirtualPath(virtualPath) Then
				Return Nothing
			End If

			Return MyBase.GetCacheDependency(virtualPath, virtualPathDependencies, utcStart)
		End Function

		Public Overloads Overrides Function GetFileHash(ByVal virtualPath As String, ByVal virtualPathDependencies As System.Collections.IEnumerable) As String
			Dim myHashCodeCombiner As New HashCodeCombiner()

			Dim unrecognizedDependencies As New List(Of String)()

			For Each virtualDependency As String In virtualPathDependencies
				If IsVirtualPath(virtualDependency) Then
					Dim file As DatabaseFile = DirectCast(GetFile(virtualDependency), DatabaseFile)
					myHashCodeCombiner.AddObject(file.LastModifiedTimeStamp)
				Else
					unrecognizedDependencies.Add(virtualDependency)
				End If
			Next

			Dim result As String = myHashCodeCombiner.CombinedHashString

			If unrecognizedDependencies.Count > 0 Then
				result += Previous.GetFileHash(virtualPath, unrecognizedDependencies)
			End If

			Return result
		End Function

		Private Function IsVirtualPath(ByVal virtualPath As String) As Boolean
			Return VirtualPathUtility.ToAppRelative(virtualPath).StartsWith(Utility.BasePath, StringComparison.InvariantCultureIgnoreCase)
		End Function

		Public Overloads Overrides Function FileExists(ByVal virtualPath As String) As Boolean
			If IsVirtualPath(virtualPath) AndAlso Utility.FileExists(VirtualPathUtility.ToAppRelative(virtualPath)) Then
				Return True
			End If

			Return Previous.FileExists(virtualPath)
		End Function

		Public Overloads Overrides Function DirectoryExists(ByVal virtualDir As String) As Boolean
			If IsVirtualPath(virtualDir) Then
				Return True
			End If

			Return Previous.DirectoryExists(virtualDir)
		End Function

		Public Overloads Overrides Function GetFile(ByVal virtualPath As String) As VirtualFile
			If IsVirtualPath(virtualPath) Then
				Return New DatabaseFile(virtualPath)
			Else
				Return Previous.GetFile(virtualPath)
			End If
		End Function

		Public Overloads Overrides Function GetDirectory(ByVal virtualDir As String) As VirtualDirectory
			If IsVirtualPath(virtualDir) Then
				Return New DatabaseDirectory(virtualDir)
			Else
				Return Previous.GetDirectory(virtualDir)
			End If
		End Function


	End Class
End Namespace