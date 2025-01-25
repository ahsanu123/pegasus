Public Class PostModelBinder
    Inherits DefaultModelBinder

    Public Overrides Function BindModel(ByVal controllerContext As ControllerContext, ByVal bindingContext As ModelBindingContext) As Object
        If controllerContext Is Nothing Then
            Throw New ArgumentNullException("controllerContext")
        End If

        If bindingContext Is Nothing Then
            Throw New ArgumentNullException("bindingContext")
        End If

        If bindingContext.Model Is Nothing Then
            Dim valueProviderResult = bindingContext.ValueProvider.GetValue("Id")

            If Not String.IsNullOrEmpty(valueProviderResult.AttemptedValue) Then
                Dim id = DirectCast(valueProviderResult.ConvertTo(GetType(Integer)), Integer)
                bindingContext.ModelMetadata.Model =
                    ObjectContextModule.CurrentContext.
                    PostSet.Include("Categories").Include("Author").
                    Where(Function(p) p.Id = id).Single

            End If
        End If

        Return MyBase.BindModel(controllerContext, bindingContext)
    End Function
End Class