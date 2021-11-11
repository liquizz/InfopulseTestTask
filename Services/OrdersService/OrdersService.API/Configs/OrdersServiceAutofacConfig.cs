using Autofac;
using Microsoft.Extensions.Configuration;
using OrdersService.Logic.Queries;
using OrdersService.Logic.Queries.Interfaces;
using OrdersService.Logic.Services;
using OrdersService.Logic.Services.Interfaces;
using WebPortal.Database.Repositories.Interfaces;

namespace OrdersService.API.Configs
{
    public class OrdersServiceAutofacConfig : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new OrdersQueries(c.Resolve<IConfiguration>())) 
                .As<IOrdersQueries>()
                .InstancePerLifetimeScope();
            
            builder.Register(c => new OrdersReadService(c.Resolve<IOrdersQueries>())) 
                .As<IOrdersReadService>()
                .InstancePerLifetimeScope();
            
            builder.Register(c => new OrdersWriteService(
                    c.Resolve<IProductsRepository>(),
                    c.Resolve<IOrdersRepository>(), 
                    c.Resolve<ICustomerRepository>())) 
                .As<IOrdersReadService>()
                .InstancePerLifetimeScope();
        }

        public static ContainerBuilder ContainerBuilderConfig(ContainerBuilder builder)
        {
            builder.RegisterType<OrdersQueries>();
            builder.RegisterType<OrdersReadService>();
            builder.RegisterType<OrdersWriteService>();

            return builder;
        }
    }
}