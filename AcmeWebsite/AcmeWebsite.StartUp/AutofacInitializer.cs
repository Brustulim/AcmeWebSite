using System;
using AcmeWebsite.Domain.IServices;
using AcmeWebsite.Domain.Services;
using AcmeWebsite.Repositories;
using Autofac;

namespace AcmeWebsite.StartUp
{

    public static class AutofacInitializer
    {
        public static void Initialize()
        {
            /*
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            
            builder.RegisterFilterProvider();

            
            builder.RegisterSource(new ViewRegistrationSource());

            builder.RegisterType<EfDbContext>().AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType<ContactRepository>().AsImplementedInterfaces();
            builder.RegisterType<ContactService>().AsImplementedInterfaces();
            builder.Build();
            */
            
        }

    }
}
