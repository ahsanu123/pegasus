using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class SelectMaster : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            MasterList.DataSource = Directory.GetFiles(Server.MapPath("~/Masters/")).Select(x => x.Substring(x.LastIndexOf("\\")+1));
            MasterList.DataBind();

            string currentMaster = File.ReadAllText(Server.MapPath("~/App_Data/MasterPage.config"));
            MasterList.SelectedValue = currentMaster.Substring(currentMaster.LastIndexOf("/") + 1);
        }
    }

    protected void SaveMasterPage(object sender, EventArgs e)
    {
        File.WriteAllText(Server.MapPath("~/App_Data/MasterPage.config"),
            "~/Masters/" + MasterList.SelectedValue);
    }
}