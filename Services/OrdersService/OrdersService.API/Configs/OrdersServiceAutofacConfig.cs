using Autofac;

namespace OrdersService.API.Configs
{
    public class OrdersServiceAutofacConfig : Module
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