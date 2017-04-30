using AcmeWebsite.AppApi.IServices;
using AcmeWebsite.AppApi.Services;
using AcmeWebsite.Domain.Entities;
using AcmeWebsite.Domain.IServices;
using AcmeWebsite.Domain.ValueObject;
using AcmeWebsite.Repositories;

namespace AcmeWebsite.AppApi.Services
{
    public class ContactAppService : AppServiceBase<Contact>, IContactAppService
    {

        private readonly IContactService _contactService;
       // private ContactRepository _contactRepository = new ContactRepository();


        public ContactAppService(IContactService contactService)
  : base(contactService)
        {
            _contactService = contactService;
        }

        public Contact GetByEmail(Email email)
        {
            return _contactService.GetByEmail(email);
        }

        public void Save(Contact contact)
        {
            _contactService.Save(contact);
        }


    }
}
