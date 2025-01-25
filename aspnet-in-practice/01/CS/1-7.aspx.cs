using System;
using System.Web;

partial class _1_7 : System.Web.UI.Page
{

    public void HandleSubmit(object sender, EventArgs e)
    {
        FormContainer.Visible = false;
        FormResponse.Visible = true;

        ResponseText.Text = string.Format("Hello {0} {1} from {2}", FirstName.Text, LastName.Text, Country.SelectedItem.Text);
    }

}