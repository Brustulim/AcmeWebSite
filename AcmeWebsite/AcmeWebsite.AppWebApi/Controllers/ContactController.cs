using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using AcmeWebsite.AppWebApi.Model;
using AcmeWebsite.Domain.IServices;


namespace AcmeWebsite.AppWebApi.Controllers
{
    public class ContactController : ApiController
    {
        private readonly IContactService _contactService;
        
        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public Task<HttpResponseMessage> GetContacts()
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                var contacts = _contactService.Get();
                response = Request.CreateResponse(HttpStatusCode.OK, contacts);
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
        public Task<HttpResponseMessage> AddContact(Contact contact)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {

                _contactService.Add();
                response = Request.CreateResponse(HttpStatusCode.OK, "Message Sent");
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            var tcs = new TaskCompletionSource<HttpResponseMessage>();
            tcs.SetResult(response);
            return tcs.Task;
        }

        /*
        [HttpPost]
        [Route("CreateMock")]
        public Task<HttpResponseMessage> AddContactMock()
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                _contactService.Add(new Contact("Joel", "Santana", new Email("joels@mailinator.com"), new Phone("(098) 765-4321"), "NW", 12, "Message from Joel"));
                _contactService.Add(new Contact("Julia", "Sagan", new Email("professional@mailinator.com"), new Phone("(123) 123-4321"), "TX", 22, "Message from "));
                _contactService.Add(new Contact("Carl", "Nova", new Email("Galatic@mailinator.com"), new Phone("(342) 213-4321"), "KA", 11, "Message from "));
                _contactService.Add(new Contact("Chuck", "Roberts", new Email("CRguy@mailinator.com"), new Phone("(343) 967-4321"), "NJ", 33, "Message from "));
                _contactService.Add(new Contact("Melina", "Amaro", new Email("mwitch@mailinator.com"), new Phone("(753) 234-4321"), "CA", 21, "Message from "));
                _contactService.Add(new Contact("Arnold", "Smith", new Email("brute@mailinator.com"), new Phone("(786) 232-4321"), "LI", 17, "Message from "));
                _contactService.Add(new Contact("Michael", "Stone", new Email("theking@mailinator.com"), new Phone("(234) 743-4321"), "MN", 15, "Message from "));
                _contactService.Add(new Contact("Eddie", "Simpson", new Email("edsimpson@mailinator.com"), new Phone("(233) 295-4321"), "AR", 13, "Message from "));

                response = Request.CreateResponse(HttpStatusCode.OK, "Mock Created Sent");
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            var tcs = new TaskCompletionSource<HttpResponseMessage>();
            tcs.SetResult(response);
            return tcs.Task;
        }
        */



    }



}
