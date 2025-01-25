Imports System
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel

<MetadataType(GetType(CustomerMetaData))>
Partial Public Class Customer
End Class

<MetadataType(GetType(ProductMetadata))>
Partial Public Class Product
End Class

Public Class CustomerMetaData
	<DataTypeAttribute(DataType.MultilineText)>
	Public Property Address() As String

	<UIHintAttribute("Phone")>
	Public Property Phone() As String
End Class

Public Class ProductMetadata
	<DisplayFormat(ApplyFormatInEditMode:=False, DataFormatString:="{0:C}", NullDisplayText:="not set")>
	<DisplayName("Price")>
	<Required()>
	<Range(0, 100, ErrorMessage:="Valid only between 0 and 100")>
	Public Property UnitPrice() As Decimal
End Class