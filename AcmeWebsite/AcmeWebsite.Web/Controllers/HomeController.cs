using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using AcmeWebsite.Web.Models;
using Newtonsoft.Json;

namespace AcmeWebsite.Web.Controllers
{
    public class HomeController : Controller
    {
        
        //private const string LocalityWebApiUrl = "http://localhost:12734/";
        //private const string AcmeWebsiteAppWebApiUrl = "http://localhost:55469/";
        
        public async Task<ActionResult> Index()
        {
            List<StateModel> statesList = new List<StateModel>();

            using (var client = new HttpClient())
            {
                
                var localityWebApiUrl = ConfigurationManager.AppSettings["LocalityWebApiUrl"];

                client.BaseAddress = new Uri(localityWebApiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/v1/state/");
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    statesList = JsonConvert.DeserializeObject<List<StateModel>>(result);
                }
                
                ViewBag.States = statesList;
                
            }

            return View();
        }

        [Route("Home/GetCityJson/{stateAcronym}")]
        public async Task<ActionResult> GetCityJson(string stateAcronym)
        {
            List<CityModel> citiesList = new List<CityModel>();

            using (var client = new HttpClient())
            {
                var localityWebApiUrl = ConfigurationManager.AppSettings["LocalityWebApiUrl"];

                client.BaseAddress = new Uri(localityWebApiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/v1/state/" + stateAcronym + "/city/");
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    citiesList = JsonConvert.DeserializeObject<List<CityModel>>(result);

                    //ViewBag.Cities = citiesList;
                }
            }
            return Json(citiesList, JsonRequestBehavior.AllowGet);
        }

        
        public async Task<ActionResult> PostContactForm(ContactModel contactModel)
        {
            using (var client = new HttpClient())
            {
                var acmeWebsiteAppWebApiUrl = ConfigurationManager.AppSettings["AcmeWebsiteAppWebApiUrl"];

                client.BaseAddress = new Uri(acmeWebsiteAppWebApiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var jSonContent = JsonConvert.SerializeObject(contactModel);
                var content = new StringContent(jSonContent, UTF8Encoding.UTF8, "application/json");
                
                HttpResponseMessage response = await client.PostAsync("api/v1/contact", content);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    ViewBag.Sucess = true;
                    return Content("<script language='javascript' type='text/javascript'>alert('Your message has been sent successfully!'); window.location='/home';</script>");
                    
                }
                else
                {
                    //ViewBag.Sucess = false;
                    //ViewBag.ErrorMessage = await response.Content.ReadAsStringAsync();
                    var error = await response.Content.ReadAsStringAsync();
                    //return Content(string.Format("<script language='javascript' type='text/javascript'>alert('There was an error sending your contact: {0}');</script>", ViewBag.ErrorMessage));
                    return Content(string.Format("<script language='javascript' type='text/javascript'>alert('There was an error sending your contact: {0}');<script language='javascript' type='text/javascript'>", error));
                    
                }

            }
            //return View();
            //return RedirectToAction("Index");
            
            return new EmptyResult();

        }

    }
}