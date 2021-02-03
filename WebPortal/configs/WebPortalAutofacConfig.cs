using Autofac;
using Microsoft.Extensions.Configuration;
using WebPortal.Database;
using WebPortal.Database.Models;
using WebPortal.Database.Repositories;
using WebPortal.Database.Repositories.Interfaces;
using WebPortal.Logic.Helpers.Sql;
using WebPortal.Logic.Queries;
using WebPortal.Logic.Queries.Interfaces;
using WebPortal.Logic.ReadServices;
using WebPortal.Logic.ReadServices.Interfaces;
using WebPortal.Logic.WriteServices;
using WebPortal.Logic.WriteServices.Interfaces;


namespace WebPortal.configs
{
    public class WebPortalAutofacConfig : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new ConnectionStringHelper(c.Resolve<IConfiguration>())) 
                .As<IConnectionStringHelper>()
                .InstancePerLifetimeScope();

            builder.Register(c => new OrdersQueries(c.Resolve<IConnectionStringHelper>())) 
                .As<IOrdersQueries>()
                .InstancePerLifetimeScope();

            builder.Register(c => new OrdersReadService(c.Resolve<IOrdersQueries>())) 
                .As<IOrdersReadService>()
                .InstancePerLifetimeScope();

            builder.Register(c => new CustomerQueries(c.Resolve<IConnectionStringHelper>())) 
                .As<ICustomersQueries>()
                .InstancePerLifetimeScope();

            builder.Register(c => new CustomerReadService(c.Resolve<ICustomersQueries>())) 
                .As<ICustomersReadService>()
                .InstancePerLifetimeScope();

            builder.Register(c => new ProductsQueries(c.Resolve<IConnectionStringHelper>()))
                .As<IProductsQueries>()
                .InstancePerLifetimeScope();

            builder.Register(c => new ProductsReadService(c.Resolve<IProductsQueries>()))
                .As<IProductsReadService>()
                .InstancePerLifetimeScope();

            builder.Register(c => new WebPortalContext())
                .As<IWebPortalContext>()
                .InstancePerLifetimeScope();

            builder.Register(c => new CustomerRepository(c.Resolve<IWebPortalContext>()))
                .As<ICustomerRepository>()
                .InstancePerLifetimeScope();

            builder.Register(c => new CustomersWriteService(c.Resolve<ICustomerRepository>()))
                .As<ICustomersWriteService>()
                .InstancePerLifetimeScope();

            builder.Register(c => new OrdersRepository(c.Resolve<IWebPortalContext>()))
                .As<IOrdersRepository>()
                .InstancePerLifetimeScope();

            builder.Register(c => new ProductsRepository(c.Resolve<IWebPortalContext>()))
                .As<IProductsRepository>()
                .InstancePerLifetimeScope();

            builder.Register(c => new OrdersWriteService(c.Resolve<IProductsRepository>(), c.Resolve<IOrdersRepository>(), c.Resolve<ICustomerRepository>()))
                .As<IOrdersWriteService>()
                .InstancePerLifetimeScope();

            builder.Register(c => new ProductsWriteService(c.Resolve<IProductsRepository>()))
                .As<IProductsWriteService>()
                .InstancePerLifetimeScope();
        }

        public static ContainerBuilder ContainerBuilderConfig(ContainerBuilder builder)
        {
            builder.RegisterType<ConnectionStringHelper>();
            builder.RegisterType<OrdersQueries>();
            builder.RegisterType<OrdersReadService>();

            return builder;
        }
    }
}