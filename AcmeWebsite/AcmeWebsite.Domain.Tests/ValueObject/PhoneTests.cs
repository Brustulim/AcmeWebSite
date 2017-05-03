using System;
using AcmeWebsite.Domain.ValueObject;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AcmeWebsite.Domain.Tests.ValueObject
{
    [TestClass]
    public class PhoneTests
    {
        [TestMethod]
        public void Phone_New_Phone_Ok()
        {
            var phone = new Phone("(979) 778-0978");
        }

        [TestMethod]
        public void Phone_New_Phone_Empty_Without_Error()
        {
            var phone = new Phone("");
        }

        [TestMethod]
        public void Phone_New_Phone_Null_Without_Error()
        {
            var phone = new Phone(null);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Phone_New_Phone_Error_Invalid_Number_Small()
        {
            var phone = new Phone("123456");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Phone_New_Phone_Error_Invalid_Number_Bigger()
        {
            var phone = new Phone("12345678911");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Phone_New_Phone_Erro_Invalid_Spaces()
        {
            var phone = new Phone("(979) 778 - 0978");
        }



        [TestMethod]
        public void Phone_GetPhoneFormated_Ok()
        {
            var phone = new Phone("(979) 778-0978");
            var formatted = phone.GetPhoneFormatted();
            Assert.AreEqual("(979) 778-0978", formatted);

        }

        [TestMethod]
        public void Phone_GetPhoneFormated_Ok_Only_Digits()
        {
            var phone = new Phone("(979) 778-0978");
            Assert.AreEqual("9797780978", phone.Number);
        }

        [TestMethod]
        public void Phone_GetPhoneFormated_Verify_NotEqual()
        {
            var phone = new Phone("(979) 778-0978");
            Assert.AreNotEqual("(111) 111-1111", phone.GetPhoneFormatted());
        }


    }
}
