using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.IO;

public class BasePage: Page
{
    protected override void OnPreInit(EventArgs e)
    {
        string masterPage = File.ReadAllText(Server.MapPath("~/App_Data/MasterPage.config"));
        if (!string.IsNullOrEmpty(masterPage))
        {
            MasterPageFile = masterPage;
        }

        base.OnPreInit(e);
    }
}