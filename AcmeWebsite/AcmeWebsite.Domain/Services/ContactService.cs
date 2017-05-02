using System.Collections.Generic;
using System.Linq;
using AcmeWebsite.Domain.Entities;
using AcmeWebsite.Domain.IRepositories;
using AcmeWebsite.Domain.IServices;
using AcmeWebsite.Domain.ValueObject;

namespace AcmeWebsite.Domain.Services
{
    public class ContactService : IContactService
    {

        private readonly IContactRepository _contactRepository;

        public ContactService(IContactRepository contactRepository)         
        {
            _contactRepository = contactRepository;
        }


        public List<Contact> GetAll()
        {
            return _contactRepository.Get().ToList();
        }

        public Contact GetByEmail(Email email)
        {
            return _contactRepository.GetByEmail(email);
        }

        public void Save(Contact contact)
        {
            _contactRepository.Save(contact);
            _contactRepository.Commit();
        }

        public void InsertNew(Contact contact)
        {
            //Validate rules for contact

            _contactRepository.Add(contact);
            _contactRepository.Commit();
        }        
    }
}
