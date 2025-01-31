using System;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Web;
using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using SqlKata;
using WingtipToys.Builder;
using WingtipToys.Builder.Application;
using WingtipToys.Builder.Extension;
using WingtipToys.Builder.Services;
using WingtipToys.Logic;
using WingtipToys.Models;
using WingtipToys.Routes;
using WingtipToys.WintipMigration;

namespace WingtipToys
{
    public class Global : HttpApplication, IContainerProviderAccessor
    {
        public static IContainerProvider _containerProvider;
        public IContainerProvider ContainerProvider
        {
            get { return _containerProvider; }
        }

        void BuildDependencyInjector()
        {
            var builder = new ContainerBuilder();

            builder.AddCustomBuilder();
            var buildServices = builder.Build();

            _containerProvider = new ContainerProvider(buildServices);
        }

        void SeedDb(IServiceProvider provider)
        {
            var connection = _containerProvider.ApplicationContainer.Resolve<ISqliteConnectionProvider>();
            var CheckForVegetables_Query = new Query(nameof(Product));

            using (var conn = connection.CreateConnection())
            {
                var vegeOnDb = conn.QuerySqlKataAsync<Product>(CheckForVegetables_Query).GetAwaiter().GetResult();
                if(vegeOnDb.Count() == 0)
                {
                    ProductSeed.PredefinedProduct.ForEach(item =>
                    {
                        conn.InsertToDatabase(item,true).GetAwaiter().GetResult();
                    });
                }
            }

        }

        void PrepareApplication()
        {
            var provider = _containerProvider.ApplicationContainer.Resolve<IServiceProvider>();
            provider.UseFluentMigrator();
            SeedDb(provider);   
        }

        void Application_Start(object sender, EventArgs e)
        {
            BuildDependencyInjector();
            PrepareApplication();

            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Add Routes.
            RegisterCustomRoutes(RouteTable.Routes);

            // Initialize the product database.
            //Database.SetInitializer(new ProductDatabaseInitializer());

            // Create the administrator role and user.
            //RoleActions roleActions = new RoleActions();
            //roleActions.createAdmin();

        }

        void RegisterCustomRoutes(RouteCollection routes)
        {
            ApplicationRoute.AppRoutes.ForEach(route =>
            {
                routes.MapPageRoute(route.Name, route.Url, route.PhysicalPath);
            });

            //routes.MapPageRoute("management", "management", "~/Pages/Management.aspx");

            // routes.MapPageRoute(
            //     "ProductsByCategoryRoute",
            //     "Category/{categoryName}",
            //     "~/ProductList.aspx"
            // );
            // routes.MapPageRoute(
            //     "ProductByNameRoute",
            //     "Product/{productName}",
            //     "~/ProductDetails.aspx"
            // );
        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs.

            // Get last error from the server
            Exception exc = Server.GetLastError();

            if (exc is HttpUnhandledException)
            {
                if (exc.InnerException != null)
                {
                    exc = new Exception(exc.InnerException.Message);
                    Server.Transfer(
                        "~/Pages/ErrorPage.aspx?handler=Application_Error%20-%20Global.asax",
                        true
                    );
                }
            }
        }
    }
}
