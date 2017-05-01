using AcmeWebsite.App.IServices;
using AcmeWebsite.Domain.Entities;
using AcmeWebsite.Domain.IServices;
using AcmeWebsite.Domain.ValueObject;

namespace AcmeWebsite.AppApi.Services
{
    public class ContactAppService : AppServiceBase<Contact>, IContactAppService
    {

        private readonly IContactService _contactService;

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
