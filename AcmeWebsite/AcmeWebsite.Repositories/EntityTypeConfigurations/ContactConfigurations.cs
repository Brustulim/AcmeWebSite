using System.Data.Entity.ModelConfiguration;
using AcmeWebsite.Domain.Entities;
using AcmeWebsite.Domain.ValueObject;

namespace AcmeWebsite.Repositories.EntityTypeConfigurations
{
    public class ContactConfigurations : EntityTypeConfiguration<Contact>
    {

        public ContactConfigurations()
        {
            HasKey(x => x.Id);

            Property(x => x.Name)
                .HasColumnName("Name")
                .HasMaxLength(Contact.NameMaxLength)
                .IsRequired();

            Property(x => x.LastName)
                .HasColumnName("LastName")
                .HasMaxLength(Contact.LastNameMaxLength)
                .IsRequired();

            Property(x => x.Email.Address)
                .HasColumnName("Email")
                .HasMaxLength(Email.AddressMaxLength)
                .IsRequired();

            Property(x => x.Phone.Number)
                .HasColumnName("Phone")
                .HasMaxLength(Phone.PhoneMaxLength);

            Property(x => x.State)
                .HasColumnName("State")
                .HasMaxLength(Contact.StateMaxLength)
                .IsRequired();

            Property(x => x.City)
                .HasColumnName("City")
                .IsRequired();

            Property(x => x.Message)
                .HasColumnName("Message")
                .HasMaxLength(Contact.MessageMaxLength)
                .IsRequired();

        }


    }
}
