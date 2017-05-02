using AcmeWebsite.Domain.Entities;
using AcmeWebsite.Domain.ValueObject;

namespace AcmeWebsite.Domain.IServices
{
    public interface IContactService : IServiceBase<Contact>
    {
        //Contact Get(int id);
        Contact GetByEmail(Email email);
        void Save(Contact contact);
        void InsertNew(string name, string lastName, string email, string phone, string state, int city, string message);
    }
}
