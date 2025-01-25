using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WindowsLive;

public partial class Login : System.Web.UI.Page
{
	string _appID;
	protected string AppID
	{
		get
		{
			return _appID;
		}
	}

    protected void Page_Init(object sender, EventArgs e)
    {
		LiveID.Visible = !string.IsNullOrEmpty(Request["LiveID"]);

		WindowsLiveLogin wll = new WindowsLiveLogin(true);
		_appID = wll.AppId;
    }
}
