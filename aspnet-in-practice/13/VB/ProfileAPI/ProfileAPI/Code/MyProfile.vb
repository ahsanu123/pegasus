Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Profile

Public Class MyProfile
	Inherits ProfileBase
	' anonymous support is enabled
	<SettingsAllowAnonymous(True)>
	Public Property FirstName() As String
		Get
			Return TryCast(Me("FirstName"), String)
		End Get
		Set(ByVal value As String)
			Me("FirstName") = value
		End Set
	End Property

	<SettingsAllowAnonymous(True)>
	Public Property LastName() As String
		Get
			Return TryCast(MyBase.Item("LastName"), String)
		End Get
		Set(ByVal value As String)
			MyBase.Item("LastName") = value
		End Set
	End Property

	<SettingsAllowAnonymous(False)>
	Public Property BirthDay() As System.Nullable(Of DateTime)
		Get
			Return DirectCast(MyBase.Item("BirthDay"), System.Nullable(Of DateTime))
		End Get
		Set(ByVal value As System.Nullable(Of DateTime))
			MyBase.Item("BirthDay") = value
		End Set
	End Property
End Class