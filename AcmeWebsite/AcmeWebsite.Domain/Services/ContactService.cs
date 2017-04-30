using AcmeWebsite.Domain.Entities;
using AcmeWebsite.Domain.IRepositories;
using AcmeWebsite.Domain.IServices;
using AcmeWebsite.Domain.ValueObject;

namespace AcmeWebsite.Domain.Services
{
    public class ContactService : ServiceBase<Contact>, IContactService
    {

        private readonly IContactRepository _contactRepository;

        public ContactService(IContactRepository contactRepository)
         : base(contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public Contact GetByEmail(Email email)
        {
            return _contactRepository.GetByEmail(email);
        }

        public void Save(Contact contact)
        {
            _contactRepository.Save(contact);
        }


    }
}
