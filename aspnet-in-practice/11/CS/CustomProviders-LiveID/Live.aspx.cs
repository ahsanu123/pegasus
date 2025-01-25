using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using WindowsLive;

public partial class Live : Page
{
	protected override void OnLoad(EventArgs e)
	{
		base.OnLoad(e);

		string action = Request["action"] ?? "login";

		// get the user token
		WindowsLiveLogin wll = new WindowsLiveLogin(true);
		WindowsLiveLogin.User user = wll.ProcessLogin(Request.Form);

		switch (action)
		{
			case "logout":
				// logout
				FormsAuthentication.SignOut();
				Response.Redirect("/");
				break;

			case "clearcookie":
				// logout
				FormsAuthentication.SignOut();

				// 1x1 transparent GIF
				string type;
				byte[] content;
				wll.GetClearCookieResponse(out type, out content);
				Response.ContentType = type;
				Response.OutputStream.Write(content, 0, content.Length);
				Response.End();

				break;

			default:

				// token to user association
				// get the user token in the login
				if (user == null && Request.Cookies["LiveID"] != null && !string.IsNullOrEmpty(Request.Cookies["LiveID"]["token"]))
				{
					string token = Request.Cookies["LiveID"]["token"];
					user = wll.ProcessToken(token);
				}

				// no live ID user, redirect to login
				if (user == null)
				{
					FormsAuthentication.RedirectToLoginPage("LiveID=1");
					return;
				}

				string userID = user.Id;
				string returnUrl = user.Context;
				bool persistent = user.UsePersistentCookie;

				// the role name will be based on the userID.
				string roleName = string.Concat("Live-", userID);

				// the user is authenticated, so I can associate him to Live ID
				if (Request.IsAuthenticated)
				{
					// check for the association
					if (!Roles.IsUserInRole(roleName))
					{
						if (!Roles.RoleExists(roleName))
							Roles.CreateRole(roleName);

						Roles.AddUserToRole(User.Identity.Name, roleName);
					}

					// delete the temporary cookie
					Response.Cookies.Remove("LiveID");

					Login(User.Identity.Name, persistent);
				}

				// login via Live
				else
				{
					// the user exists
					if (Roles.RoleExists(roleName))
					{
						string username = Roles.GetUsersInRole(roleName)[0];

						Login(username, persistent);
					}
					// we need to associate the user
					else
					{
						// the token will be used later
						Response.Cookies["LiveID"]["token"] = user.Token;
						FormsAuthentication.RedirectToLoginPage(string.Concat("LiveID=1&ReturnUrl=", Request.Url.ToString()));
					}

				}

				// in case, back to login
				FormsAuthentication.RedirectToLoginPage();

				break;
		}
	}

	private void Login(string username, bool persistent)
	{
		// FormsAuthentication login
		FormsAuthentication.RedirectFromLoginPage(username, persistent);
		Response.End();
	}
}