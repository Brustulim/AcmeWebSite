using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using AcmeWebsite.LocalityWebApi.Services;

namespace AcmeWebsite.LocalityWebApi.Controllers
{
    [RoutePrefix("api/v1/state")]
    public class StateController : ApiController
    {
        private readonly AzureConnector _azureConnector;

        public StateController()
        {
            _azureConnector = new AzureConnector();
        }


        [HttpGet]
        public Task<HttpResponseMessage> GetStates()
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                /*
                List<State> states = new List<State>();
                states.Add(new State("CA", "California"));
                states.Add(new State("NJ", "New Jersey"));
                states.Add(new State("KA", "Kansas"));
                */
                var states = _azureConnector.GetStates();
                response = Request.CreateResponse(HttpStatusCode.OK, states);
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            var tcs = new TaskCompletionSource<HttpResponseMessage>();
            tcs.SetResult(response);
            return tcs.Task;
        }

        [HttpGet]
        [Route("{stateAcronym}/city")]
        public Task<HttpResponseMessage> GetCities(string stateAcronym)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                /*
                List<City> cities = new List<City>();
                cities.Add(new City("CA", "Los Bambas", 1));
                cities.Add(new City("NW", "New Blo", 2));
                cities.Add(new City("KA", "Kansita", 3));
                */

                var cities = _azureConnector.GetCities(stateAcronym);
                response = Request.CreateResponse(HttpStatusCode.OK, cities);
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
