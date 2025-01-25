Imports System
Imports System.Web
Imports System.Web.UI.WebControls.Adapters
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Collections.Generic

Namespace ASPNET4InPractice
    Public Class DropDownListAdapter
        Inherits WebControlAdapter
        Private uniqueID As String = Nothing
        
        Protected Overloads Overrides Sub RenderContents(ByVal writer As HtmlTextWriter)
            Dim list As DropDownList = TryCast(Me.Control, DropDownList)
            
            uniqueID = list.UniqueID
            
            Dim lastOptionGroup As String = Nothing
            Dim currentOptionGroup As String = Nothing
            For Each item As ListItem In list.Items
                currentOptionGroup = TryCast(item.Attributes("OptionGroup"), String)
                
                If currentOptionGroup IsNot Nothing Then
                    If lastOptionGroup Is Nothing OrElse Not lastOptionGroup.Equals(currentOptionGroup, StringComparison.InvariantCultureIgnoreCase) Then
                        If lastOptionGroup IsNot Nothing Then
                            RenderOptionGroupEndTag(writer)
                        End If
                        
                        RenderOptionGroupBeginTag(currentOptionGroup, writer)
                    End If
                    
                    lastOptionGroup = currentOptionGroup
                End If
                
                RenderListItem(item, writer)
            Next
            
            If lastOptionGroup IsNot Nothing Then
                RenderOptionGroupEndTag(writer)
            End If
        End Sub
        
        Private Sub RenderOptionGroupBeginTag(ByVal name As String, ByVal writer As HtmlTextWriter)
            writer.Indent += 1
            writer.WriteBeginTag("optgroup")
            writer.WriteAttribute("label", name)
            writer.Write(HtmlTextWriter.TagRightChar)
            writer.WriteLine()
        End Sub
        
        Private Sub RenderOptionGroupEndTag(ByVal writer As HtmlTextWriter)
            writer.WriteEndTag("optgroup")
            writer.WriteLine()
            writer.Indent -= 1
        End Sub
        
        Private Sub RenderListItem(ByVal item As ListItem, ByVal writer As HtmlTextWriter)
            writer.Indent += 1
            writer.WriteBeginTag("option")
            writer.WriteAttribute("value", item.Value, True)
            
            If item.Selected Then
                writer.WriteAttribute("selected", "selected", False)
            End If
            
            For Each key As String In item.Attributes.Keys
                If Not key.Equals("optiongroup", StringComparison.CurrentCultureIgnoreCase) Then
                    writer.WriteAttribute(key, item.Attributes(key))
                End If
            Next
            
            writer.Write(HtmlTextWriter.TagRightChar)
            
            If Page IsNot Nothing Then
                Page.ClientScript.RegisterForEventValidation(uniqueID, item.Value)
            End If
            
            HttpUtility.HtmlEncode(item.Text, writer)
            writer.WriteEndTag("option")
            writer.WriteLine()
            writer.Indent -= 1
        End Sub
    End Class
End Namespace