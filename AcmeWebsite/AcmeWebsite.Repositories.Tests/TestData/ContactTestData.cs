using System.Collections.Generic;
using AcmeWebsite.Domain.Entities;
using AcmeWebsite.Domain.IRepositories;
using AcmeWebsite.Domain.ValueObject;

namespace AcmeWebsite.Repositories.Tests.TestData
{
    public class ContactTestData
    {

        public static List<Contact> Get()
        {
            List<Contact> contacts = new List<Contact>();
            
            //Here we can change data and "re-run" unit tests wich diferent data

            contacts.Add(new Contact("Joel", "Santana", new Email("joels@mailinator.com"), new Phone("(098) 765-4321"), "NW", 12, "Message from Joel"));
            contacts.Add(new Contact("Julia", "Sagan", new Email("professional@mailinator.com"), new Phone("(123) 123-4321"), "TX", 22, "Message from "));
            contacts.Add(new Contact("Carl", "Nova", new Email("Galatic@mailinator.com"), new Phone("(342) 213-4321"), "KA", 11, "Message from "));
            contacts.Add(new Contact("Chuck", "Roberts", new Email("CRguy@mailinator.com"), new Phone("(343) 967-4321"), "NJ", 33, "Message from "));
            contacts.Add(new Contact("Melina", "Amaro", new Email("mwitch@mailinator.com"), new Phone("(753) 234-4321"), "CA", 21, "Message from "));
            contacts.Add(new Contact("Arnold", "Smith", new Email("brute@mailinator.com"), new Phone("(786) 232-4321"), "LI", 17, "Message from "));
            contacts.Add(new Contact("Michael", "Stone", new Email("theking@mailinator.com"), new Phone("(234) 743-4321"), "MN", 15, "Message from "));
            contacts.Add(new Contact("Eddie", "Simpson", new Email("edsimpson@mailinator.com"), new Phone("(233) 295-4321"), "AR", 13, "Message from "));

            return contacts;

        }

        public static void AddOrUpdateTestData(IRepositoryBase<Contact> contactRepository)
        {
            List<Contact> contacts = Get();

            foreach (Contact contact in contacts)
                contactRepository.AddOrUpdate(contact);




        }


    }
}
