using System;
using System.Web;

partial class _1_4 : System.Web.UI.Page
{
    public void HandleSubmit(object sender, EventArgs e)
    {
        ResponseText.Text = "Your name is: " + Name.Text;
    }

}