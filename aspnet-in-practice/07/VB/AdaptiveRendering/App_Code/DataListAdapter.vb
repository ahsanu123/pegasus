Imports System
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.Adapters

Namespace ASPNET4InPractice
    Public Class DataListAdapter
        Inherits WebControlAdapter
        Private _repeatColumns As Integer = -1
        Private ReadOnly Property RepeatColumns() As Integer
            Get
                If _repeatColumns = -1 Then
                    _repeatColumns = 1
                    Dim dataList As DataList = TryCast(Control, DataList)
                    
                    If dataList IsNot Nothing Then
                        If dataList.RepeatColumns = 0 Then
                            If dataList.RepeatDirection = RepeatDirection.Horizontal Then
                                _repeatColumns = dataList.Items.Count
                            End If
                        Else
                            _repeatColumns = dataList.RepeatColumns
                        End If
                    End If
                End If
                Return _repeatColumns
            End Get
        End Property
        
        Protected Overloads Overrides Sub RenderContents(ByVal writer As HtmlTextWriter)
            Dim dataList As DataList = TryCast(Control, DataList)
            If dataList IsNot Nothing Then
                ' header
                If dataList.HeaderTemplate IsNot Nothing Then
                    RenderHeader(writer, dataList)
                End If
                
                ' ItemTemplate && AlternatingItemTemplate
                If dataList.ItemTemplate IsNot Nothing OrElse dataList.AlternatingItemTemplate IsNot Nothing Then
                    RenderItem(writer, dataList)
                    
                    If dataList.RepeatDirection = RepeatDirection.Horizontal Then
                        Exit Sub
                    End If
                End If
                
                ' close the last div
                If (dataList.Items.Count Mod RepeatColumns) <> 0 Then
                    writer.Indent -= 1
                    writer.WriteLine()
                    writer.WriteEndTag("div")
                    
                End If
            End If
            
            writer.Indent -= 1
            writer.WriteLine()
            
            ' FooterTemplate
            If dataList.FooterTemplate IsNot Nothing Then
                RenderFooter(writer, dataList)
            End If
        End Sub
        
        Private Sub RenderFooter(ByVal writer As HtmlTextWriter, ByVal dataList As DataList)
            writer.WriteLine()
            writer.WriteBeginTag("div")
            
            ' restore style
            Dim style As CssStyleCollection = GetStyleFromTemplate(dataList, dataList.FooterStyle)
            style.Add("clear", "both")
            writer.WriteAttribute("style", style.Value)
            
            writer.Write(HtmlTextWriter.TagRightChar)
            writer.Indent += 1
            
            Dim container As New PlaceHolder()
            dataList.FooterTemplate.InstantiateIn(container)
            container.DataBind()
            container.RenderControl(writer)
            
            writer.Indent -= 1
            writer.WriteLine()
            writer.WriteEndTag("div")
        End Sub
        
        Private Sub RenderItem(ByVal writer As HtmlTextWriter, ByVal dataList As DataList)
            ' get Data Items
            Dim items As DataListItemCollection = dataList.Items
            
            writer.WriteLine()
            Dim currentItem As DataListItem
            
			Dim itemsPerColumn As Integer = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(dataList.Items.Count) / Convert.ToDouble(RepeatColumns)))

			Dim rowIndex As Integer = 0, columnIndex As Integer = 0, currentIndex As Integer = 0


			Page.Trace.Write("itemsPerColumn", itemsPerColumn)

			' enumerate rows
			For index As Integer = 0 To dataList.Items.Count - 1
				rowIndex = Convert.ToInt32(Math.Floor(Convert.ToDouble(index) / Convert.ToDouble(RepeatColumns)))
				columnIndex = index Mod RepeatColumns
				currentIndex = index

				' calcutate the real DataItem index
				If dataList.RepeatDirection = RepeatDirection.Vertical Then
					currentIndex = Convert.ToInt32((columnIndex * itemsPerColumn)) + rowIndex
				End If

				' get the DataItem
				currentItem = items(currentIndex)

				If (index Mod RepeatColumns) = 0 Then
					writer.WriteLine()
					writer.WriteBeginTag("div")

					writer.WriteAttribute("style", "clear:both")

					writer.Write(HtmlTextWriter.TagRightChar)
					writer.Indent += 1
				End If

				writer.WriteLine()

				writer.WriteBeginTag("div")

				' restore original style
				Dim style As TableItemStyle = If((currentItem.ItemType = ListItemType.Item), dataList.ItemStyle, (If(dataList.AlternatingItemStyle Is Nothing, dataList.ItemStyle, dataList.AlternatingItemStyle)))

				' RepeatColumns Width support
				style.Width = New Unit(CInt(Math.Abs(CDbl(100) / RepeatColumns)), UnitType.Percentage)

				Dim finalStyle As CssStyleCollection = GetStyleFromTemplate(dataList, style)
				If dataList.RepeatColumns > 1 Then
					finalStyle.Add("float", "left")
				End If

				writer.WriteAttribute("style", finalStyle.Value)

				writer.Write(HtmlTextWriter.TagRightChar)
				writer.Indent += 1

				For Each itemCtrl As Control In currentItem.Controls
					itemCtrl.RenderControl(writer)
				Next

				writer.Indent -= 1
				writer.WriteLine()
				writer.WriteEndTag("div")

				If ((index + 1) Mod RepeatColumns) = 0 Then
					writer.Indent -= 1
					writer.WriteLine()
					writer.WriteEndTag("div")
				End If
			Next
        End Sub
        
        Private Sub RenderHeader(ByVal writer As HtmlTextWriter, ByVal dataList As DataList)
            writer.WriteBeginTag("div")
            
            ' restore style
            Dim style As CssStyleCollection = GetStyleFromTemplate(dataList, dataList.HeaderStyle)
            
            If Not [String].IsNullOrEmpty(style.Value) Then
                writer.WriteAttribute("style", style.Value)
            End If
            
            writer.Write(HtmlTextWriter.TagRightChar)
            
            Dim container As New PlaceHolder()
            dataList.HeaderTemplate.InstantiateIn(container)
            container.DataBind()
            
            If (container.Controls.Count = 1) AndAlso GetType(LiteralControl).IsInstanceOfType(container.Controls(0)) Then
                writer.WriteLine()
                
                Dim literalControl As LiteralControl = TryCast(container.Controls(0), LiteralControl)
                writer.Write(literalControl.Text.Trim())
            Else
                container.RenderControl(writer)
            End If
            
            writer.WriteEndTag("div")
        End Sub
        
        Protected Overloads Overrides Sub RenderBeginTag(ByVal writer As HtmlTextWriter)
            Dim dataList As DataList = TryCast(Control, DataList)
            
            writer.WriteBeginTag("div")
            
            If dataList.Style.Value IsNot Nothing Then
                writer.WriteAttribute("style", dataList.Style.Value)
            End If
            
            If Not [String].IsNullOrEmpty(dataList.CssClass) Then
                writer.WriteAttribute("class", dataList.CssClass)
            End If
            
            writer.Write(HtmlTextWriter.TagRightChar)
            writer.Indent += 1
        End Sub
        
        Protected Overloads Overrides Sub RenderEndTag(ByVal writer As HtmlTextWriter)
            writer.WriteEndTag("div")
        End Sub
        
        Private Function GetStyleFromTemplate(ByVal dataList As DataList, ByVal style As TableItemStyle) As CssStyleCollection
            Dim finalStyle As CssStyleCollection = style.GetStyleAttributes(dataList)
            Return finalStyle
        End Function
        
    End Class
End Namespace