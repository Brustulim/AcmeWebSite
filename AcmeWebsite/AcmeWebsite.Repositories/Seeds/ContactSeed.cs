using System.Linq;
using AcmeWebsite.Domain.Entities;
using AcmeWebsite.Domain.ValueObject;

namespace AcmeWebsite.Repositories.Seeds
{
    public class ContactSeed
    {

        public static void Seed(EfDbContext context)
        {
            //Ususing dbSet Contact
            if(!context.Contacts.Any(c => c.Name == "John"))
                context.Contacts. Add(new Contact("John", "Doe", new Email("johndoe@mailinator.com"), new Phone("(321) 654-9874"), "AL", 34, "Teste Message John - Seed"));

            if (!context.Contacts.Any(c => c.Name == "Jane"))
                context.Contacts.Add(new Contact("Jane", "Simons", new Email("janejungle@mailinator.com"), new Phone("(154) 963-8521"), "PE", 34, "Teste Message Jane - Seed"));


        }

    }
}
