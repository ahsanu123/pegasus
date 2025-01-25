Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class SuperDropDownList
	Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
		If Not IsPostBack Then
			Countries.DataSource = New String() {"Italy", "U.S.A.", "U.K.", "Spain"}
			Countries.DataBind()
		End If
	End Sub
End Class