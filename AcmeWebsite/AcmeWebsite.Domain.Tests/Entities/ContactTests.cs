using System;
using AcmeWebsite.Domain.Entities;
using AcmeWebsite.Domain.ValueObject;
using AcmeWebsite.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AcmeWebsite.Domain.Tests.Entities
{
    [TestClass]
    public class ContactTests
    {

        private string Name { get; set; }
        private string LastName { get; set; }
        private Email Email { get; set; }
        private Phone Phone { get; set; }
        private string State { get; set; }
        private int City { get; set; }
        private string Message { get; set; }

        private Contact Contact { get; set; }

        public ContactTests()
        {
            Name = "Herminio";
            LastName = "Brustulim";
            Email = new Email("brustulim@gmail.com");
            Phone = new Phone("(123) 456-7890");
            State = "IL";
            City = 1;
            Message = "Test Message";

            Contact = new Contact(Name, LastName, Email, Phone, State, City, Message);
        }


        #region TestConstructor

        #region Name
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Contact_New_Error_Name_Null()
        {
            new Contact(null, LastName, Email, Phone, State, City, Message);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Contact_New_Error_Name_Empty()
        {
            new Contact("", LastName, Email, Phone, State, City, Message);
        }
        #endregion

        #region LastName
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Contact_New_Error_LastName_Null()
        {
            new Contact(Name, null, Email, Phone, State, City, Message);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Contact_New_Error_LastName_Empty()
        {
            new Contact(Name, "", Email, Phone, State, City, Message);
        }
        #endregion

        #region Email
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Contact_New_Error_Email_Null()
        {
            new Contact(Name, LastName, null, Phone, State, City, Message);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Contact_New_Error_Email_Empty()
        {
            new Contact(Name, LastName, new Email(""), Phone, State, City, Message);
        }
        #endregion

        #region Phone
        [TestMethod]
        public void Contact_New_Phone_Null_Without_Error()
        {
            new Contact(Name, LastName, Email, null, State, City, Message);
        }
        #endregion

        #region State
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Contact_New_Error_State_Null()
        {
            new Contact(Name, LastName, Email, Phone, null, City, Message);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Contact_New_Error_State_Empty()
        {
            new Contact(Name, LastName, Email, Phone, "", City, Message);
        }
        #endregion

        #region City
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Contact_New_Error_City_Zero()
        {
            new Contact(Name, LastName, Email, Phone, State, 0, Message);
        }
        #endregion

        #region Message
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Contact_New_Error_Message_Null()
        {
            new Contact(Name, LastName, Email, Phone, State, City, null);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Contact_New_Error_Message_Empty()
        {
            new Contact(Name, LastName, Email, Phone, State, City, "");
        }
        #endregion

        #endregion


        #region TestValues
        [TestMethod]
        public void Contact_New_Name()
        {
            var contact = new Contact(Name, LastName, Email, Phone, State, City, Message);
            Assert.AreEqual(Name, contact.Name);
        }

        [TestMethod]
        public void Contact_New_LastName()
        {
            var contact = new Contact(Name, LastName, Email, Phone, State, City, Message);
            Assert.AreEqual(LastName, contact.LastName);
        }

        [TestMethod]
        public void Contact_New_Email()
        {
            var contact = new Contact(Name, LastName, Email, Phone, State, City, Message);
            Assert.AreEqual(Email, contact.Email);
        }

        [TestMethod]
        public void Contact_New_Phone()
        {
            var contact = new Contact(Name, LastName, Email, Phone, State, City, Message);
            Assert.AreEqual(Phone, contact.Phone);
        }

        [TestMethod]
        public void Contact_New_State()
        {
            var contact = new Contact(Name, LastName, Email, Phone, State, City, Message);
            Assert.AreEqual(State, contact.State);
        }

        [TestMethod]
        public void Contact_New_City()
        {
            var contact = new Contact(Name, LastName, Email, Phone, State, City, Message);
            Assert.AreEqual(City, contact.City);
        }

        [TestMethod]
        public void Contact_New_Message()
        {
            var contact = new Contact(Name, LastName, Email, Phone, State, City, Message);
            Assert.AreEqual(Message, contact.Message);
        }

        #endregion


        #region TestEspecificRules
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Contact_Name_Error_Min_Length()
        {
            Contact.SetName( Util.GenerateStringWithSpecificLength(Contact.NameMinLength - 1));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Contact_Name_Error_Max_Length()
        {
            Contact.SetName(Util.GenerateStringWithSpecificLength(Contact.NameMaxLength + 1));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Contact_Name_Error_White_Space()
        {
            Contact.SetName("John Doe");
        }


        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Contact_LastName_Error_Min_Fragment_Size()
        {
            Contact.SetLastName("Jo D Master");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Contact_LastName_Error_Max_Length()
        {
            Contact.SetLastName(Util.GenerateStringWithSpecificLength(Contact.LastNameMaxLength + 1));
        }

        [TestMethod]
        public void Contact_LastName_Ok()
        {
            Contact.SetLastName("John Do");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Contact_State_Error_Max_Length()
        {
            Contact.SetState(Util.GenerateStringWithSpecificLength(Contact.StateMaxLength + 1));
        }


        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Contact_Message_Error_Min_Length()
        {
            Contact.SetMessage(Util.GenerateStringWithSpecificLength(Contact.MessageMinLength - 1));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Contact_Message_Error_Max_Length()
        {
            Contact.SetMessage(Util.GenerateStringWithSpecificLength(Contact.MessageMaxLength + 1));
        }




        #endregion

    }
}
