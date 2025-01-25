using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProfileAPI
{
	public partial class Default : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				MyProfile profile = MyProfile.Create(User.Identity.Name) as MyProfile;

				FirstName.Text = profile.FirstName;
				BirthDay.Text = profile.BirthDay.GetValueOrDefault().ToShortDateString();

				
			}

		}

		protected void Unnamed1_Click(object sender, EventArgs e)
		{
			MyProfile profile = MyProfile.Create(User.Identity.Name) as MyProfile;
			profile.BirthDay = (string.IsNullOrEmpty(BirthDay.Text)?null as DateTime?:Convert.ToDateTime(BirthDay.Text));
			profile.FirstName = FirstName.Text;
			profile.Save();
		}
	}
}