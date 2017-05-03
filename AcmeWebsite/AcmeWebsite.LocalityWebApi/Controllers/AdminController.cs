using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using AcmeWebsite.LocalityWebApi.Services;

namespace AcmeWebsite.LocalityWebApi.Controllers
{
    [RoutePrefix("api/v1/admin")]
    public class AdminController : ApiController
    {


        [HttpGet]
        public Task<HttpResponseMessage> CreateTables()
        {
            var response = new HttpResponseMessage();

            try
            {
                var admin = new Admin();
                admin.CreateTables();

                response = Request.CreateResponse(HttpStatusCode.OK, "Tables created");
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            var tcs = new TaskCompletionSource<HttpResponseMessage>();
            tcs.SetResult(response);
            return tcs.Task;
        }


        [HttpPost]
        public Task<HttpResponseMessage> InsertState(string acronym, string name)
        {
            var response = new HttpResponseMessage();

            try
            {
                var admin = new Admin();
                admin.CreateTables();

                response = Request.CreateResponse(HttpStatusCode.OK, "Tables created");
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            var tcs = new TaskCompletionSource<HttpResponseMessage>();
            tcs.SetResult(response);
            return tcs.Task;


        }
            
    }
}
