using Autofac;
using Microsoft.Extensions.Configuration;
using ProductsService.Logic.Queries;
using ProductsService.Logic.Queries.Interfaces;
using ProductsService.Logic.Services;
using ProductsService.Logic.Services.Interfaces;
using WebPortal.Database.Repositories.Interfaces;

namespace ProductsService.API.Configs
{
    public class ProductsServiceAutofacConfig : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new ProductsQueries(c.Resolve<IConfiguration>())) 
                .As<IProductsQueries>()
                .InstancePerLifetimeScope();
            
            builder.Register(c => new ProductsReadService(c.Resolve<IProductsQueries>())) 
                .As<IProductsReadService>()
                .InstancePerLifetimeScope();
            
            builder.Register(c => new ProductsWriteService(c.Resolve<IProductsRepository>())) 
                .As<IProductsWriteService>()
                .InstancePerLifetimeScope();
        }

        public static ContainerBuilder ContainerBuilderConfig(ContainerBuilder builder)
        {
            builder.RegisterType<ProductsQueries>();
            builder.RegisterType<ProductsReadService>();
            builder.RegisterType<ProductsWriteService>();

            return builder;
        }
    }
}