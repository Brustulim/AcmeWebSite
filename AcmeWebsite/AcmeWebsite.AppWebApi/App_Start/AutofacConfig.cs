using System.Reflection;
using System.Web.Http;
using AcmeWebsite.Domain.IRepositories;
using AcmeWebsite.Domain.IServices;
using AcmeWebsite.Domain.Services;
using AcmeWebsite.Repositories;
using Autofac;
using Autofac.Integration.WebApi;

namespace AcmeWebsite.AppWebApi.App_Start
{
    public class AutofacConfig
    {
        public static void Init()
        {
            var builder = new ContainerBuilder();

            var config = GlobalConfiguration.Configuration;

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterWebApiFilterProvider(config);

            RegisterDependencies(builder);

            var container = builder.Build();
            
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver((IContainer)container);

        }

        private static void RegisterDependencies(ContainerBuilder builder)
        {
            builder.RegisterType<EfDbContext>().InstancePerLifetimeScope();
            builder.RegisterType<ContactRepository>().As<IContactRepository>();
            builder.RegisterType<ContactService>().As<IContactService>();
        }
    }
}