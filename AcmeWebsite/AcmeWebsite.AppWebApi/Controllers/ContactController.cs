using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using AcmeWebsite.AppWebApi.Model;
using AcmeWebsite.Domain.Entities;
using AcmeWebsite.Domain.IServices;
using AcmeWebsite.Domain.ValueObject;


namespace AcmeWebsite.AppWebApi.Controllers
{
    [RoutePrefix("api/v1/contact")]
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
            var response = new HttpResponseMessage();

            try
            {
                var contacts = _contactService.GetAll();
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
        public Task<HttpResponseMessage> AddContact([FromBody]ContactModel contactModel)
        {
            var response = new HttpResponseMessage();

            try
            {
                
                var contact = new Contact(
                    contactModel.Name, 
                    contactModel.LastName,
                    new Email(contactModel.Email),
                    new Phone(contactModel.Phone),
                    contactModel.State,
                    contactModel.City,
                    contactModel.Message);
                
                _contactService.InsertNew(contact);
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
        
        [HttpPost]
        [Route("createmock")]
        public Task<HttpResponseMessage> AddContactMock()
        {
            var response = new HttpResponseMessage();

            try
            {
                //Mock
                //_contactService.InsertNew("Joel", "Santana", "joels@mailinator.com", "(098) 765-4321", "NW", 12, "Message from Joel");
                //_contactService.InsertNew("Julia", "Sagan","professional@mailinator.com", "(123) 123-4321", "TX", 22, "Message from ");
                //_contactService.InsertNew("Carl", "Nova", "Galatic@mailinator.com", "(342) 213-4321", "KA", 11, "Message from ");
                //_contactService.InsertNew("Chuck", "Roberts", "CRguy@mailinator.com", "(343) 967-4321", "NJ", 33, "Message from ");
                //_contactService.InsertNew("Melina", "Amaro", "mwitch@mailinator.com", "(753) 234-4321", "CA", 21, "Message from ");
                //_contactService.InsertNew("Arnold", "Smith", "brute@mailinator.com", "(786) 232-4321", "LI", 17, "Message from ");
                //_contactService.InsertNew("Michael", "Stone", "theking@mailinator.com", "(234) 743-4321", "MN", 15, "Message from ");
                //_contactService.InsertNew("Eddie", "Simpson", "edsimpson@mailinator.com", "(233) 295-4321", "AR", 13, "Message from ");

                response = Request.CreateResponse(HttpStatusCode.OK, "Mock Created");
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
