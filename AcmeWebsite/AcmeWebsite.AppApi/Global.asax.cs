using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using AcmeWebsite.AppApi.App_Start;
using AcmeWebsite.Domain.IRepositories;
using AcmeWebsite.Domain.IServices;
using AcmeWebsite.Domain.Services;
using AcmeWebsite.Repositories;
using Autofac;
using Autofac.Integration.WebApi;

namespace AcmeWebsite.AppApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AutofacConfig.Init();

            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

    }

}
