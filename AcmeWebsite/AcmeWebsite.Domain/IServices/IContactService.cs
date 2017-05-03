using System.Collections.Generic;
using AcmeWebsite.Domain.Entities;
using AcmeWebsite.Domain.ValueObject;

namespace AcmeWebsite.Domain.IServices
{
    public interface IContactService
    {
        List<Contact> GetAll();
        Contact GetByEmail(Email email);
        void Save(Contact contact);
        void InsertNew(Contact contact);
    }
}
