using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
	protected void AddToRole_Click(object sender, EventArgs e)
	{
		string roleName = "administrators";
		if (!Roles.RoleExists(roleName))
			Roles.CreateRole(roleName);

		if (!Roles.IsUserInRole(roleName))
			Roles.AddUserToRole(User.Identity.Name, roleName);

		Response.Redirect("admin/");
	}
}
