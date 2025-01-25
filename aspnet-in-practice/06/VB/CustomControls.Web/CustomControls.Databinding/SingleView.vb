Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.ComponentModel
Imports System.Web.UI.WebControls
Imports System.Collections
Imports System.Web.UI

<ParseChildren(True)>
Public Class SingleView
	Inherits CompositeDataBoundControl
	Implements INamingContainer
	<Bindable(True)>
	Public Overrides Property DataSource() As Object

	<Browsable(False), PersistenceMode(PersistenceMode.InnerProperty), DefaultValue(GetType(ITemplate), ""), TemplateContainer(GetType(RepeaterItem), BindingDirection.TwoWay)>
	Public Property ItemTemplate() As ITemplate

	<Browsable(False), PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(GetType(RepeaterItem)), DefaultValue(DirectCast(Nothing, String))>
	Public Property EmptyTemplate() As ITemplate

	' this methods will prevent any container tag
	Public Overrides Sub RenderBeginTag(ByVal writer As HtmlTextWriter)
	End Sub

	Public Overrides Sub RenderEndTag(ByVal writer As HtmlTextWriter)
	End Sub
	' ***********

	Protected Overrides Function CreateChildControls(ByVal dataSource__1 As IEnumerable, ByVal dataBinding As Boolean) As Integer
		If ItemTemplate Is Nothing Then
			Throw New ArgumentNullException("ItemTemplate")
		End If

		' we need a control container
		Dim container As New RepeaterItem(0, ListItemType.Item)
		Me.Controls.Add(container)
		ItemTemplate.InstantiateIn(container)

		' if databinding is requested, perform it
		If dataBinding Then
			' check for DataSource and EmptyTemplate
			If DataSource Is Nothing Then
				If EmptyTemplate IsNot Nothing Then
					Me.Controls.Clear()
					EmptyTemplate.InstantiateIn(Me)
				End If
			Else
				container.DataItem = DataSource
				If Not Page.IsPostBack Then
					container.DataBind()
				End If
				container.DataItem = Nothing
			End If
		End If

		Return 1
	End Function


End Class