using System.Linq;
using AcmeWebsite.Domain.Entities;
using AcmeWebsite.Domain.IRepositories;
using AcmeWebsite.Domain.ValueObject;

namespace AcmeWebsite.Repositories
{

    public class ContactRepository : RepositoryBase<Contact>, IContactRepository
    {

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
