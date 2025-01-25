using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Repository;

/// <summary>
/// Summary description for BasePage
/// </summary>
public class BasePage : Page {
	protected override void OnInit(EventArgs e) {
		base.OnInit(e);
		new CustomerRepository().CreateContext();
	}

	protected override void OnUnload(EventArgs e) {
		base.OnUnload(e);
		new CustomerRepository().DestroyContext();
	}
}