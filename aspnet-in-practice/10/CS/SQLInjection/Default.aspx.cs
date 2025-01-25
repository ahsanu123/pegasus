using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
	protected void SubmitButton_Click(object sender, EventArgs e)
	{
		StringBuilder sql = new StringBuilder("SELECT * FROM Products WHERE Category IN (");
		string[] categories = Request["Categories"].Split(',');

		SqlParameter[] paramters = new SqlParameter[categories.Length];
		
		for (int i = 0; i < categories.Length; i++)
		{
			sql.AppendFormat("@p{0}, ", i);
			paramters[i] = new SqlParameter(string.Format("@p{0}", i), categories[i]);
		}
		sql.Append("0)");

		Response.Write(sql.ToString());
	}
}
