using AcmeWebsite.Domain.Entities;
using AcmeWebsite.Domain.ValueObject;

namespace AcmeWebsite.App.IServices
{
    public interface IContactAppService : IAppServiceBase<Contact>
    {
        //Contact Get(int id);
        Contact GetByEmail(Email email);
        void Save(Contact contact);
    }
}
