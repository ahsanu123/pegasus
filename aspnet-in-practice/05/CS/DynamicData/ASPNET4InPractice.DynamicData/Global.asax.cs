using System;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.DynamicData;
using System.Web.Routing;
using ASPNET4InPractice.DynamicData.ObjectModel;

namespace ASPNET4InPractice.DynamicData
{
	public class Global : System.Web.HttpApplication
	{
		private static MetaModel s_defaultModel = new MetaModel();
		public static MetaModel DefaultModel
		{
			get
			{
				return s_defaultModel;
			}
		}

		public static void RegisterRoutes(RouteCollection routes)
		{
			ContextConfiguration config = new ContextConfiguration()
			{
				ScaffoldAllTables = true
			};
			DefaultModel.RegisterContext(typeof(NorthwindEntities), config);


			routes.Add(new DynamicDataRoute("{table}/{action}.aspx")
			{
				Constraints = new RouteValueDictionary(new { action = "List|Details|Edit|Insert" }),
				Model = DefaultModel
			});

		}

		void Application_Start(object sender, EventArgs e)
		{
			RegisterRoutes(RouteTable.Routes);
		}

	}
}
