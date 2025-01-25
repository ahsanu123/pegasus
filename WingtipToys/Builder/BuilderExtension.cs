using System;
using System.Configuration;
using System.Reflection;
using Autofac;
using FluentMigrator.Runner;
using Microsoft.Ajax.Utilities;
using Microsoft.Extensions.DependencyInjection;
using WingtipToys.Builder.Extension;
using WingtipToys.Builder.Services;
using WingtipToys.Constant;
using WingtipToys.Repository;

namespace WingtipToys.Builder
{
    public static class BuilderExtension
    {
        public static ContainerBuilder AddCustomBuilder(this ContainerBuilder builder)
        {
            // TODO: make configuration service

            builder
                .Register(context =>
                {
                    var services = new ServiceCollection();
                    services.AddServiceCollection();

                    var provider = services.BuildServiceProvider();
                    return provider;
                })
                .As<IServiceProvider>();

            builder
                .Register(context =>
                {
                    return new SqliteConnectionProvider(ConfigurationConstant.Sqlite);
                })
                .As<ISqliteConnectionProvider>();

            builder.RegisterType<ProductRepository>().As<IProductRepository>();
            builder.RegisterType<DummyServices>().As<IDummyServices>();

            return builder;
        }
    }
}
