using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.WindowsAzure.Storage.Table;

namespace AcmeWebsite.LocalityWebApi.Controllers
{
    [RoutePrefix("api/v1/admin")]
    public class AdminController : ApiController
    {

        [HttpPost]
        public Task<HttpResponseMessage> InsertState(string acronym, string name)
        {
            CloudTable cloudTable = new CloudTable();

            

        }
            
    }
}
