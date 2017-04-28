using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AcmeWebsite.Helpers.Tests
{
    [TestClass]
    public class ValidatorTests
    {
        //Methods start with the class name for easy identification in TestExplorer list

        // I have not implemented all the possible tests, but I believe that the examples below will already allow you to analyze that I have the skills to implement a complete test unit

        #region ForNullOrEmpty
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Validator_ForNullOrEmpty_Error_When_Empty()
        {
            Validator.ForNullOrEmpty("", "Value cannot be empty!");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Validator_ForNullOrEmpty_Error_When_Null()
        {
            Validator.ForNullOrEmpty(null, "Value cannot be null!");
        }

        [TestMethod]
        public void Validator_ForNullOrEmpty_When_Ok()
        {
            Validator.ForNullOrEmpty("test", "Test message");
        }

        //Pending tests:
        //Empty Message
        //Null Message
        #endregion


        #region ForNullOrEmptyDefaultMessage
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Validator_ForNullOrEmptyDefaultMessage_Error_When_Empty()
        {
            Validator.ForNullOrEmptyDefaultMessage("", "property");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Validator_ForNullOrEmptyDefaultMessage_Error_When_Null()
        {
            Validator.ForNullOrEmptyDefaultMessage(null, "property");
        }

        [TestMethod]
        public void Validator_ForNullOrEmptyDefaultMessage_When_Ok()
        {
            Validator.ForNullOrEmptyDefaultMessage("test", "property");
        }

        //Pending tests:
        //Empty propName
        //Null propName
        #endregion

        #region StringMaxLength
        [TestMethod]
        public void Validator_StringMaxLength_Ok()
        {
            Validator.StringMaxLength("12345", 5, "Test Message!");
        }

        [TestMethod]
        public void Validator_StringMaxLength_Ok_With_value_Null()
        {
            //if null the method need understand as empty and can´t raise errors
            Validator.StringMaxLength(null, 5, "Teste");
            //Do´n´t need asserts
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Validator_StringMaxLength_Error_When_value_Exceed_limit()
        {
            Validator.StringMaxLength("1234567", 5, "");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Validator_StringMaxLength_Error_When_message_Empty()
        {
            Validator.StringMaxLength("1234", 5, "");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Validator_StringMaxLength_Error_When_message_Null()
        {
            Validator.StringMaxLength("1234", 5, null);
        }
        #endregion


        #region StringMaxLengthDefaultMessage
        [TestMethod]
        public void Validator_StringMaxLengthDefaultMessage_Ok()
        {
            Validator.StringMaxLengthDefaultMessage("property", "1234", 5);
        }

        [TestMethod]
        public void Validator_StringMaxLengthDefaultMessage_Ok_With_stringValue_Null()
        {
            Validator.StringMaxLengthDefaultMessage("property", null, 5);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Validator_StringMaxLengthDefaultMessage_Error_When_value_Exceed_limit()
        {
            Validator.StringMaxLengthDefaultMessage("property", "123456", 5);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Validator_StringMaxLengthDefaultMessage_Error_When_propName_Empty()
        {
            Validator.StringMaxLengthDefaultMessage("", "12345", 5);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Validator_StringMaxLengthDefaultMessage_Error_When_propName_Null()
        {
            Validator.StringMaxLengthDefaultMessage(null, "12345", 5);
        }
        #endregion


        #region ValidateUsPhoneNumber
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Validator_ValidateUsPhoneNumber_Not_Valid_Small()
        {
            Validator.ValidateUsPhoneNumber("123");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Validator_ValidateUsPhoneNumber_Not_Valid_Large()
        {
            Validator.ValidateUsPhoneNumber("12113456789021");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Validator_ValidateUsPhoneNumber_Not_Valid_Wrong()
        {
            Validator.ValidateUsPhoneNumber("(979)778-0978");
        }


        [TestMethod]
        public void Validator_ValidateUsPhoneNumber_Valid()
        {
            //Assert.IsTrue(Validator.ValidateUsPhoneNumber("3087774825"), "Error validating: " + "3087774825");
            
            Validator.ValidateUsPhoneNumber("(281) 388-0388");
            Validator.ValidateUsPhoneNumber("(979) 778-0978");
            Validator.ValidateUsPhoneNumber("(281) 934-2479");
            Validator.ValidateUsPhoneNumber("(281) 934-2479");
        }

        #endregion



        #region StringMaxLengthDefaultMessage
        //Pending tests:
        //Sucess
        //Sucess_With_Null_value
        //Error_When_value_Exceed_limit
        //Empty propName
        //Null propName
        #endregion


        //Complete pending tests:
        //StringLength
        //StringLengthDefaultMessage
        //AreEqual
        //ForContainWhiteSpace


    }
}
