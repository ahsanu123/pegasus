Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Public Partial Class CustomerList
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        CustomerView.DataSource = ApplicationObjectContext.Current.Customers
        CustomerView.DataBind()
    End Sub
End Class