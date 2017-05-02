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

        public void InsertNew(string name, string lastName, string email, string phone, string state, int city, string message)
        {


            Save(new Contact(name,lastName, new Email(email),new Phone(phone),state,city,message) );
        }

    }
}
