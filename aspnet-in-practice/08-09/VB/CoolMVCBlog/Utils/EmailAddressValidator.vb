Public Class EmailAddressValidator
    Inherits DataAnnotationsModelValidator(Of EmailAddressAttribute)

    Public Sub New(ByVal metadata As ModelMetadata,
                   ByVal context As ControllerContext, ByVal attribute As EmailAddressAttribute)
        MyBase.New(metadata, context, attribute)
    End Sub

    Public Overrides Function GetClientValidationRules() As IEnumerable(Of ModelClientValidationRule)
        Dim rule = New ModelClientValidationRegexRule(
                   Me.ErrorMessage, EmailAddressAttribute.EmailRegex)

        Return New ModelClientValidationRule() {rule}
    End Function
End Class