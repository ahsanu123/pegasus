Imports System.Data.Objects.DataClasses

Public Class CategoriesModelBinder
    Implements IModelBinder

    Public Function BindModel(ByVal controllerContext As ControllerContext, ByVal bindingContext As ModelBindingContext) As Object Implements IModelBinder.BindModel
        If controllerContext Is Nothing Then
            Throw New ArgumentNullException("controllerContext")
        End If

        If bindingContext Is Nothing Then
            Throw New ArgumentNullException("bindingContext")
        End If

        Dim source As EntityCollection(Of Category) =
            TryCast(bindingContext.Model, EntityCollection(Of Category))

        If Not source Is Nothing Then
            Dim fromRequest As IEnumerable(Of Category) =
                Me.GetPostedCategories(bindingContext)

            If Not fromRequest Is Nothing Then
                Me.UpdateOriginalCategories(source, fromRequest)
            End If
        End If

        Return Nothing
    End Function

    Private Function GetPostedCategories(ByVal bindingContext As ModelBindingContext) As IEnumerable(Of Category)
        Dim postedValue = bindingContext.ValueProvider.GetValue(
            bindingContext.ModelName + ".values")

        If postedValue Is Nothing Then
            Return Nothing
        End If

        Return GetCategoriesFromString(postedValue.AttemptedValue)
    End Function

    Private Function GetCategoriesFromString(ByVal stringValues As String) As IEnumerable(Of Category)
        Dim values = stringValues.Split(CChar(";"))

        Dim res As New List(Of Category)

        For Each item In values
            Dim id = Integer.Parse(item)
            res.Add(ObjectContextModule.CurrentContext.CategorySet.
                    Where(Function(c) c.Id = id).Single)
        Next

        Return res
    End Function

    Private Sub UpdateOriginalCategories(
        ByVal source As EntityCollection(Of Category),
        ByVal fromRequest As IEnumerable(Of Category))
        Dim toRemove = source.Where(Function(c) Not fromRequest.Any(Function(c1) c1.Id = c.Id)).ToList
        Dim toAdd = fromRequest.Where(Function(c) Not source.Any(Function(c1) c1.Id = c.Id)).ToList

        toRemove.ForEach(Sub(c) source.Remove(c))
        toAdd.ForEach(Sub(c) source.Add(c))
    End Sub
End Class