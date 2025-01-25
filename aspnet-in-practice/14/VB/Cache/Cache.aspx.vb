Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports Cache

Partial Public Class CachePage
	Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		ProviderName.Text = CacheFactory.Instance.Name
		CustomerList.DataSource = GetCustomers()
		CustomerList.DataBind()
	End Sub

	Private Shared lockObject As New Object()

	Public Function GetCustomers() As List(Of Customer)
		Dim cacheKey As String = "customers"
		Dim customers As List(Of Customer) = TryCast(CacheFactory.Instance(cacheKey), List(Of Customer))

		If customers Is Nothing Then
			SyncLock lockObject
				customers = TryCast(CacheFactory.Instance(cacheKey), List(Of Customer))
				If customers Is Nothing Then
					customers = New List(Of Customer)() From {
				  New Customer() With {
				   .FirstName = "Daniele",
				   .LastName = "Bochicchio"
				  },
				  New Customer() With {
				   .FirstName = "Marco",
				   .LastName = "De Sanctis"
				  },
				  New Customer() With {
				   .FirstName = "Stefano",
				   .LastName = "Mostarda"
				  }
				 }

					CacheFactory.Instance(cacheKey) = customers
				End If
			End SyncLock
		End If
		Return customers
	End Function

End Class
