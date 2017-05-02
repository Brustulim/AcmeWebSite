using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcmeWebsite.Domain.Entities;
using AcmeWebsite.Domain.Enums;
using AcmeWebsite.Domain.Exceptions;
using AcmeWebsite.Domain.Services;
using AcmeWebsite.Domain.ValueObject;
using AcmeWebsite.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AcmeWebsite.Domain.Tests.Services
{
    [TestClass]
    public class ContactServiceTests
    {
        private ContactService _contactService;

        public ContactServiceTests()
        {
            _contactService = new ContactService(null);
        }

        private Contact GetContactMock()
        {
            return new Contact
            {
                Name = "Herminio",
                LastName = "Brustulim",
                Email = new Email("brustulim@gmail.com"),
                Phone = new Phone("(123) 456-7890"),
                State = "IL",
                City = 1,
                Message = "Test Message",
            };
        }


        [TestMethod]
        public void ValidateContact_when_name_null_must_return_error()
        {            
            var contact = GetContactMock();
            contact.Name = null;
            
            var results = _contactService.ValidateContact(contact);
                        
            Assert.AreEqual(results.First().Field, nameof(Contact.Name));
            Assert.AreEqual(results.First().ValidationType, ValidationType.NullOrEmpty);
        }

        [TestMethod]
        public void ValidateContact_when_name_empty_must_return_error()
        {
            var contact = GetContactMock();
            contact.Name = "";

            var results = _contactService.ValidateContact(contact);

            Assert.AreEqual(results.Count, 1);
            Assert.AreEqual(results.First().Field, nameof(Contact.Name));
            Assert.AreEqual(results.First().ValidationType, ValidationType.NullOrEmpty);
        }

        [TestMethod]
        public void ValidateContact_when_name_contain_whitespace_must_return_error()
        {
            var contact = GetContactMock();
            contact.Name = "John Doo";

            var results = _contactService.ValidateContact(contact);

            Assert.AreEqual(results.Count, 1);
            Assert.AreEqual(results.First().Field, nameof(Contact.Name));
            Assert.AreEqual(results.First().ValidationType, ValidationType.WhiteSpaces);
        }

        [TestMethod]
        public void ValidateContact_when_name_length_less_minLength_must_return_error()
        {
            var contact = GetContactMock();
            contact.Name = Util.GenerateStringWithSpecificLength(Contact.NameMinLength - 1);

            var results = _contactService.ValidateContact(contact);

            Assert.AreEqual(results.Count, 1);
            Assert.AreEqual(results.First().Field, nameof(Contact.Name));
            Assert.AreEqual(results.First().ValidationType, ValidationType.BetweenLength);
        }

        [TestMethod]
        public void ValidateContact_when_name_length_greater_maxLength_must_return_error()
        {
            var contact = GetContactMock();
            contact.Name = Util.GenerateStringWithSpecificLength(Contact.NameMaxLength + 1);

            var results = _contactService.ValidateContact(contact);

            Assert.AreEqual(results.Count, 1);
            Assert.AreEqual(results.First().Field, nameof(Contact.Name));
            Assert.AreEqual(results.First().ValidationType, ValidationType.BetweenLength);
        }

        [TestMethod]
        public void ValidateContact_when_lastname_null_must_return_error()
        {
            var contact = GetContactMock();
            contact.LastName = null;

            var results = _contactService.ValidateContact(contact);

            Assert.AreEqual(results.Count, 1);
            Assert.AreEqual(results.First().Field, nameof(Contact.LastName));
            Assert.AreEqual(results.First().ValidationType, ValidationType.NullOrEmpty);
        }

        [TestMethod]
        public void ValidateContact_when_lastname_empty_must_return_error()
        {
            var contact = GetContactMock();
            contact.LastName = "";

            var results = _contactService.ValidateContact(contact);

            Assert.AreEqual(results.Count, 1);
            Assert.AreEqual(results.First().Field, nameof(Contact.LastName));
            Assert.AreEqual(results.First().ValidationType, ValidationType.NullOrEmpty);
        }

        [TestMethod]
        public void ValidateContact_when_lastname_invalid_length_must_return_error()
        {
            var contact = GetContactMock();
            contact.LastName = Util.GenerateStringWithSpecificLength(Contact.LastNameMaxLength + 1);

            var results = _contactService.ValidateContact(contact);

            Assert.AreEqual(results.Count, 1);
            Assert.AreEqual(results.First().Field, nameof(Contact.LastName));
            Assert.AreEqual(results.First().ValidationType, ValidationType.MaxLength);
        }

        [TestMethod]
        public void ValidateContact_when_lastname_invalid_fragment_length_must_return_error()
        {
            var contact = GetContactMock();
            contact.LastName = string.Format("John {0} Doe",  Util.GenerateStringWithSpecificLength(Contact.LastNameMinFragmentLength -1));

            var results = _contactService.ValidateContact(contact);

            Assert.AreEqual(results.Count, 1);
            Assert.AreEqual(results.First().Field, nameof(Contact.LastName));
            Assert.AreEqual(results.First().ValidationType, ValidationType.FragmentLength);
        }

        [TestMethod]
        public void ValidateContact_when_email_null_must_return_error()
        {
            var contact = GetContactMock();
            contact.Email = null;

            var results = _contactService.ValidateContact(contact);

            Assert.AreEqual(results.Count, 1);
            Assert.AreEqual(results.First().Field, nameof(Contact.Email));
            Assert.AreEqual(results.First().ValidationType, ValidationType.Null);
        }

        [TestMethod]
        public void ValidateContact_when_state_null_must_return_error()
        {
            var contact = GetContactMock();
            contact.State = null;

            var results = _contactService.ValidateContact(contact);

            Assert.AreEqual(results.Count, 1);
            Assert.AreEqual(results.First().Field, nameof(Contact.State));
            Assert.AreEqual(results.First().ValidationType, ValidationType.NullOrEmpty);
        }

        [TestMethod]
        public void ValidateContact_when_state_empty_must_return_error()
        {
            var contact = GetContactMock();
            contact.State = "";

            var results = _contactService.ValidateContact(contact);

            Assert.AreEqual(results.Count, 1);
            Assert.AreEqual(results.First().Field, nameof(Contact.State));
            Assert.AreEqual(results.First().ValidationType, ValidationType.NullOrEmpty);
        }

        [TestMethod]
        public void ValidateContact_when_state_invalid_length_return_error()
        {
            var contact = GetContactMock();
            contact.State = Util.GenerateStringWithSpecificLength(Contact.StateMaxLength + 1);

            var results = _contactService.ValidateContact(contact);

            Assert.AreEqual(results.Count, 1);
            Assert.AreEqual(results.First().Field, nameof(Contact.State));
            Assert.AreEqual(results.First().ValidationType, ValidationType.MaxLength);
        }

        [TestMethod]
        public void ValidateContact_when_city_zero_must_return_error()
        {
            var contact = GetContactMock();
            contact.City = 0;

            var results = _contactService.ValidateContact(contact);

            Assert.AreEqual(results.Count, 1);
            Assert.AreEqual(results.First().Field, nameof(Contact.City));
            Assert.AreEqual(results.First().ValidationType, ValidationType.Empty);
        }

        [TestMethod]
        public void ValidateContact_when_message_null_must_return_error()
        {
            var contact = GetContactMock();
            contact.Message = null;

            var results = _contactService.ValidateContact(contact);

            Assert.AreEqual(results.Count, 1);
            Assert.AreEqual(results.First().Field, nameof(Contact.Message));
            Assert.AreEqual(results.First().ValidationType, ValidationType.NullOrEmpty);
        }

        [TestMethod]
        public void ValidateContact_when_message_empty_must_return_error()
        {
            var contact = GetContactMock();
            contact.Message = "";

            var results = _contactService.ValidateContact(contact);

            Assert.AreEqual(results.Count, 1);
            Assert.AreEqual(results.First().Field, nameof(Contact.Message));
            Assert.AreEqual(results.First().ValidationType, ValidationType.NullOrEmpty);
        }

        [TestMethod]
        public void ValidateContact_when_message_length_less_minLength_must_return_error()
        {
            var contact = GetContactMock();
            contact.Message = Util.GenerateStringWithSpecificLength(Contact.MessageMinLength - 1);

            var results = _contactService.ValidateContact(contact);

            Assert.AreEqual(results.Count, 1);
            Assert.AreEqual(results.First().Field, nameof(Contact.Message));
            Assert.AreEqual(results.First().ValidationType, ValidationType.BetweenLength);
        }

        [TestMethod]
        public void ValidateContact_when_message_length_greater_maxLength_must_return_error()
        {
            var contact = GetContactMock();
            contact.Message = Util.GenerateStringWithSpecificLength(Contact.MessageMaxLength + 1);

            var results = _contactService.ValidateContact(contact);

            Assert.AreEqual(results.Count, 1);
            Assert.AreEqual(results.First().Field, nameof(Contact.Message));
            Assert.AreEqual(results.First().ValidationType, ValidationType.BetweenLength);
        }
        

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void InsertNew_when_invalid_contact_must_throw_business_exception()
        {
            var contact = new Contact()
            {
                Name = "H",
                LastName = "Brustulim Brustulim Brustulim Brustulim Brustulim Brustulim Brustulim Brustulim",
                Email = new Email("brustulim@gmail.com"),
                Phone = new Phone("(123) 456-7890"),
                State = null,
                City = 0,
                Message = "123"
            };

            _contactService.InsertNew(contact);
        }
    }
}
