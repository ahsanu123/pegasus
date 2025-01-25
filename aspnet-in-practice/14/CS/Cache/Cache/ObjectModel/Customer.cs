using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

[Serializable]
public class Customer
{
	DateTime _savedDate = DateTime.Now;

	public Customer()
	{
	}

	public string FirstName { get; set; }
	public string LastName { get; set; }
	public DateTime SavedDate
	{
		get
		{
			return _savedDate;
		}

	}
}