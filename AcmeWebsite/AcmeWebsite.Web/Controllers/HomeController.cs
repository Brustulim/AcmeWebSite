using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using AcmeWebsite.Web.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AcmeWebsite.Web.Controllers
{
    public class HomeController : Controller
    {
        
        //private const string LocalityWebApiUrl = "http://localhost:12734/";
        //private const string AcmeWebsiteAppWebApiUrl = "http://localhost:55469/";
        
        public async Task<ActionResult> Index()
        {

            var statesList = new List<StateModel>();

            using (var client = new HttpClient())
            {
                
                var localityWebApiUrl = ConfigurationManager.AppSettings["LocalityWebApiUrl"];

                client.BaseAddress = new Uri(localityWebApiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync("api/v1/state/");
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
            var citiesList = new List<CityModel>();

            using (var client = new HttpClient())
            {
                var localityWebApiUrl = ConfigurationManager.AppSettings["LocalityWebApiUrl"];

                client.BaseAddress = new Uri(localityWebApiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync("api/v1/state/" + stateAcronym + "/city/");
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    citiesList = JsonConvert.DeserializeObject<List<CityModel>>(result);
                }
            }
            return Json(citiesList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<ActionResult> PostContactForm(ContactModel contactModel)
        {

            var captchaResponse = contactModel.ReCaptchaResponse;
            
            var secretKey = "6LfysB8UAAAAAPEj31MoXVLAR1NDo811EXvS0MGe";

            using (var client = new WebClient())
            {
                var result =
                    client.DownloadString(
                        string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}",
                            secretKey, captchaResponse));
                var obj = JObject.Parse(result);
                var success = (bool) obj.SelectToken("success");

                if (!success)
                    return Json(new { Success = "false", Message = "The captcha validation has failed! Plese, try again." });

            }

            using (var client = new HttpClient())
            {
                var acmeWebsiteAppWebApiUrl = ConfigurationManager.AppSettings["AcmeWebsiteAppWebApiUrl"];

                client.BaseAddress = new Uri(acmeWebsiteAppWebApiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var jSonContent = JsonConvert.SerializeObject(contactModel);
                var content = new StringContent(jSonContent, UTF8Encoding.UTF8, "application/json");
                
                var response = await client.PostAsync("api/v1/contact", content);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return Json(new { Success = "true", Message = "" });

                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    return Json(new { Success = "false", Message = error });

                }

            }
            
            //return RedirectToAction("Index");

        }

    }
}