using Autofac;
using CustomersService.Logic.Queries;
using CustomersService.Logic.Queries.Interfaces;
using CustomersService.Logic.Services;
using CustomersService.Logic.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using WebPortal.Database.Repositories.Interfaces;

namespace CustomersService.API.Configs
{
    public class CustomersServiceAutofacConfig : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new CustomersQueries(c.Resolve<IConfiguration>())) 
                .As<ICustomersQueries>()
                .InstancePerLifetimeScope();
            
            builder.Register(c => new CustomersReadService(c.Resolve<ICustomersQueries>())) 
                .As<ICustomersReadService>()
                .InstancePerLifetimeScope();
            
            builder.Register(c => new CustomersWriteService(c.Resolve<ICustomerRepository>())) 
                .As<ICustomersWriteService>()
                .InstancePerLifetimeScope();
            
        }

        public static ContainerBuilder ContainerBuilderConfig(ContainerBuilder builder)
        {
            builder.RegisterType<CustomersQueries>();
            builder.RegisterType<CustomersReadService>();
            builder.RegisterType<CustomersWriteService>();

            return builder;
        }
    }
}