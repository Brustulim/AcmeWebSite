using System.Web;
using System.Web.Http;
using AcmeWebsite.AppWebApi.App_Start;

namespace AcmeWebsite.AppWebApi
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AutofacConfig.Init();

            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

    }

}
