using System;
using AcmeWebsite.Domain.ValueObject;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AcmeWebsite.Domain.Tests.ValueObject
{


    [TestClass]
    public class EmailTests
    {
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Email_New_Email_Error_Empty()
        {
            var email = new Email("");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Email_New_Email_Error_Null()
        {
            var email = new Email(null);
        }

        [TestMethod]
        public void Email_New_Email_Valid()
        {
            var address = "brustulim@gmail.com";
            var email = new Email(address);
            Assert.AreEqual(address, email.Address);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Email_New_Email_Invalid()
        {
            var email = new Email("123456789");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Email_New_Email_Error_MaxLength()
        {
            var address = "";
            while (address.Length < Email.AddressMaxLength + 1)
            {
                address = address + ",brustulim@gmail.com.br";
            }

            new Email(address);
        }



    }
}
