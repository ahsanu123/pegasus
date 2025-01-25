Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports ObjectModel

Public Class ApplicationObjectContext
	Public Shared ReadOnly Property Current() As NorthwindEntities
		Get
			Return TryCast(HttpContext.Current.Items("ObjectContext"), NorthwindEntities)
		End Get
	End Property
End Class