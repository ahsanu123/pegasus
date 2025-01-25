using Microsoft.Extensions.DependencyInjection;
using WingtipToys.Repository;

namespace WingtipToys.Builder.Services
{
    public static class AddServiceCollectionExtension { 
        public static IServiceCollection AddServiceCollection(this IServiceCollection services)
        {

            services.AddFluentMigratorProvider();
            return services;

        }
    }
}
