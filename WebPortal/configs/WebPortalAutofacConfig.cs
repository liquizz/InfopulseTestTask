using Autofac;
using Microsoft.Extensions.Configuration;
using WebPortal.Logic.Helpers.Sql;


namespace WebPortal.configs
{
    public class WebPortalAutofacConfig : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new ConnectionStringHelper(c.Resolve<IConfiguration>())) // ConfigurationManager.ConnectionStrings["CabinetConnection"].ConnectionString
                .As<IConnectionStringHelper>()
                .InstancePerLifetimeScope();
        }

        public static ContainerBuilder ContainerBuilderConfig(ContainerBuilder builder)
        {
            return builder;
        }
    }
}