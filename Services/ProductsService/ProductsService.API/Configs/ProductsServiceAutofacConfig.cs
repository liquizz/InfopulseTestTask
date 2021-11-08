using Autofac;

namespace ProductsService.API.Configs
{
    public class ProductsServiceAutofacConfig : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // builder.Register(c => new ConnectionStringHelper(c.Resolve<IConfiguration>())) 
            //     .As<IConnectionStringHelper>()
            //     .InstancePerLifetimeScope();
        }

        public static ContainerBuilder ContainerBuilderConfig(ContainerBuilder builder)
        {
            // builder.RegisterType<ConnectionStringHelper>();
            // builder.RegisterType<OrdersQueries>();
            // builder.RegisterType<OrdersReadService>();
            
            return builder;
        }
    }
}