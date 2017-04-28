using AcmeWebsite.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcmeWebsite.Domain.Entities;
using AcmeWebsite.Domain.ValueObject;

namespace AcmeWebsite.Repositories
{

    // Implement the interface on Domain project
    public class ContactRepository : RepositoryBase<Contact>, IContactRepository
    {
        //For use base class/interface IRepository
        //Private force developer to call constructor to instantiate and cant chage this reference
        private readonly IRepositoryBase<Contact> _contactRepository;

        public ContactRepository(IRepositoryBase<Contact> contactRepository) : base()
        {
            _contactRepository = contactRepository;
        }
        
        //Needed for RespositoryForTests that use in Memory list
        public Contact Get(int id)
        {
            return _contactRepository.Get(id);
        }
        

        public Contact GetByEmail(Email email)
        {
            return _contactRepository.Get().FirstOrDefault(c => c.Email.Address == email.Address);
        }

        public void Save(Contact contact)
        {
            _contactRepository.AddOrUpdate(contact);
            _contactRepository.Commit();
        }
    }
}
