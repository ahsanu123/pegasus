Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Public Partial Class _DataList
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		Dim source = New String() {"Yogurt", "Beef", "Cheese", "Bread", "Biscuits", "Fish", _
  "Peanuts", "Pasta", "Pork", "Soy", "Other"}
        
        ProductList.DataSource = source
        ProductList.DataBind()
        
        ProductList2.DataSource = source
        ProductList2.DataBind()
    End Sub
End Class