Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports ObjectModel

Public Class ObjectContextModule
	Implements IHttpModule

	Public Sub Dispose() Implements IHttpModule.Dispose
		' nothing
	End Sub

	Public Sub Init(ByVal context As HttpApplication) Implements IHttpModule.Init
		AddHandler context.BeginRequest, AddressOf context_BeginRequest
		AddHandler context.EndRequest, AddressOf context_EndRequest
		AddHandler context.Error, AddressOf context_EndRequest
	End Sub

	Private Sub context_EndRequest(ByVal sender As Object, ByVal e As EventArgs)
		If HttpContext.Current.Items("ObjectContext") IsNot Nothing Then
			TryCast(HttpContext.Current.Items("ObjectContext"), NorthwindEntities).Dispose()
		End If
	End Sub

	Private Sub context_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)
		HttpContext.Current.Items("ObjectContext") = New NorthwindEntities()
	End Sub
End Class