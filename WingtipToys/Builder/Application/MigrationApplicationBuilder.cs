using System;
using FluentMigrator;
using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using WingtipToys.WintipMigration;

namespace WingtipToys.Builder.Application
{
    public static class MigrationApplicationBuilder
    {
        public const int MIGRATION_VERSION = 2;

        public const string MIGRATION_DESCRIPTION = "Webform with services";

        public static bool UpdateForeignKey = false;

        public static IServiceProvider UseFluentMigrator(this IServiceProvider provider)
        {
            using (var scope = provider.CreateScope())
            {
                var runner = scope.ServiceProvider.GetService<IMigrationRunner>();
                var versionLoader = scope.ServiceProvider.GetService<IVersionLoader>();

                runner.ListMigrations();

                if (
                    MigrationApplicationBuilder.MIGRATION_VERSION
                    > versionLoader.VersionInfo.Latest()
                )
                {
                    runner.Down(new MainMigration());

                    runner.MigrateUp(MigrationApplicationBuilder.MIGRATION_VERSION);

                    // this is for update foreign key
                    // after table is established in database
                    // MigrationExtension.UpdateForeignKey = true;

                    MigrationApplicationBuilder.UpdateForeignKey = true;
                    runner.Up(new MainMigration());
                }
            }

            return provider;
        }

        public static Migration DeleteTableIfExists(this Migration migration, Type type)
        {
            migration.Delete.Table(type.Name).IfExists();

            return migration;
        }
    }
}
