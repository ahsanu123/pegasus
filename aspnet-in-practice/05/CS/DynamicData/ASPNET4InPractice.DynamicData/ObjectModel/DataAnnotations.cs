using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ASPNET4InPractice.DynamicData.ObjectModel
{
	[MetadataType(typeof(CustomerMetaData))]
	public partial class Customer
	{ }

	[MetadataType(typeof(ProductMetadata))]
	public partial class Product
	{ }

	public class CustomerMetaData
	{
		[DataTypeAttribute(DataType.MultilineText)]
		public string Address { get; set; }

		[UIHintAttribute("Phone")]
		public string Phone { get; set; }
	}

	public class ProductMetadata
	{
		[DisplayFormat(ApplyFormatInEditMode = false,
					   DataFormatString = "{0:C}",
					   NullDisplayText = "not set")]
		[DisplayName("Price")]
		[Required]
  		[Range(0, 100, ErrorMessage="Valid only between 0 and 100")]
		public decimal UnitPrice { get; set; }
	}
}