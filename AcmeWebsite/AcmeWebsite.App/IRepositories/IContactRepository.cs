using AcmeWebsite.Domain.Entities;
using AcmeWebsite.Domain.ValueObject;

namespace AcmeWebsite.Domain.IRepositories
{
    public interface IContactRepository : IRepositoryBase<Contact>
    {
        Contact Get(int id);
        Contact GetByEmail(Email email);
        void Save(Contact contact);
    }
}
