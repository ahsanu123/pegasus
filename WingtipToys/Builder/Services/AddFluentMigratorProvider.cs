using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using FluentMigrator.Runner;
using WingtipToys.Builder.Extension;
using WingtipToys.Constant;

namespace WingtipToys.Builder.Services { 

    public static class AddFluentMigratorProviderBuilder
    {
        public static IServiceCollection AddFluentMigratorProvider(this IServiceCollection services)
        {
                    services
                        .AddFluentMigratorCore()
                        .ConfigureRunner(runnerBuilder =>
                            runnerBuilder
                                // .AddSQLite()
                                .AddSQLiteWithCompatibilityMode(
                                    false,
                                    false,
                                    CompatibilityMode.LOOSE
                                )
                                .WithGlobalConnectionString(ConfigurationConstant.Sqlite)
                                .ScanIn(Assembly.GetExecutingAssembly())
                                .For.All()
                        )
                        // Enable logging to console in the FluentMigrator way
                        .AddLogging(loggingBuilder => loggingBuilder.AddFluentMigratorConsole())
                        .Configure<FluentMigratorLoggerOptions>(options =>
                        {
                            options.ShowSql = true;
                            options.ShowElapsedTime = true;
                        })
                        // Build the service provider
                        .BuildServiceProvider(false);
            return services;
        }
    }

}
