Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Collections
Imports System.ComponentModel

<DefaultEvent("SelectedValueChanged")>
 Public Class SuperDropDownList
	Inherits CompositeControl
	Implements INamingContainer
	Public Property Description() As String
		Get
			Return TryCast(ViewState("Description"), String)
		End Get
		Set(ByVal value As String)
			ViewState("Description") = value
		End Set
	End Property

	Public Property DataSource() As IList
		Get
			' this will ensure that the child controls are ready to be used
			EnsureChildControls()
			Return TryCast(DirectCast(Controls(3), DropDownList).DataSource, IList)
		End Get

		Set(ByVal value As IList)
			EnsureChildControls()
			DirectCast(Controls(3), DropDownList).DataSource = value
		End Set
	End Property

	Public Property SelectedValue() As String
		Get
			EnsureChildControls()
			Return DirectCast(Controls(3), DropDownList).SelectedValue
		End Get

		Set(ByVal value As String)
			EnsureChildControls()
			DirectCast(Controls(3), DropDownList).SelectedValue = value
		End Set
	End Property

	Public Property AutoPostBack() As Boolean
		Get
			EnsureChildControls()
			Return DirectCast(Controls(3), DropDownList).AutoPostBack
		End Get

		Set(ByVal value As Boolean)
			EnsureChildControls()
			DirectCast(Controls(3), DropDownList).AutoPostBack = value
		End Set
	End Property

	' event
	Public Event SelectedValueChanged As EventHandler

	Protected Sub OnSelectedValueChanged(ByVal e As EventArgs)
		RaiseEvent SelectedValueChanged(Me, e)
	End Sub

	Protected Overrides Sub CreateChildControls()
		If ChildControlsCreated Then
			Return
		End If

		Controls.Clear()

		Controls.Add(New LiteralControl("<p>"))

		Dim labelText As New Label()
		labelText.Text = Description

		Controls.Add(labelText)

		Controls.Add(New LiteralControl(If(String.IsNullOrEmpty(Description), String.Empty, ": ")))

		Dim listControl As New DropDownList()

		AddHandler listControl.SelectedIndexChanged, Sub(sender As Object, e As EventArgs)
														 OnSelectedValueChanged(e)
													 End Sub

		Controls.Add(listControl)

		ChildControlsCreated = True
	End Sub
End Class