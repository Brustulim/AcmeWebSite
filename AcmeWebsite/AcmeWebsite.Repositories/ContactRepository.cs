using System.Linq;
using AcmeWebsite.Domain.Entities;
using AcmeWebsite.Domain.IRepositories;
using AcmeWebsite.Domain.ValueObject;

namespace AcmeWebsite.Repositories
{

    public class ContactRepository : RepositoryBase<Contact>, IContactRepository
    {
        //For use base class/interface IRepository
        //Private force developer to call constructor to instantiate and cant change this reference

        /*
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
        */

        public ContactRepository(EfDbContext context) : base(context)
        {
        }

        public Contact GetByEmail(Email email)
        {
            return Get().FirstOrDefault(c => c.Email.Address == email.Address);
        }

        public void Save(Contact contact)
        {
            AddOrUpdate(contact);
            Commit();
        }

    
    }
}
