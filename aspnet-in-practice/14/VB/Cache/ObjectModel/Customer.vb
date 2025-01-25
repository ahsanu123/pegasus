Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web

<Serializable>
Public Class Customer
	Private _savedDate As DateTime = DateTime.Now

	Public Sub New()
	End Sub

	Public Property FirstName() As String
	Public Property LastName() As String
	Public ReadOnly Property SavedDate() As DateTime
		Get
			Return (_savedDate)
		End Get
	End Property

End Class
