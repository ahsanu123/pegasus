Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class OutputCache
	Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		CustomerList.DataSource = GetCustomers()
		CustomerList.DataBind()
	End Sub

	Public Function GetCustomers() As List(Of Customer)
		Return New List(Of Customer)() From {
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
	End Function
End Class