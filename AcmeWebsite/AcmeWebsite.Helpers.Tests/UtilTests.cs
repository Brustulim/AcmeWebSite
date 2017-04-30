using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AcmeWebsite.Helpers.Tests
{
    [TestClass]
    public class UtilTests
    {
        //Methods start with the class name for easy identification in TestExplorer list

        
        [TestMethod]
        public void Util_ReturnOnlyDigits_Null_value_Without_Error()
        {
            Util.ReturnOnlyDigits(null);
        }

        [TestMethod]
        public void Util_ReturnOnlyDigits_Empty_value_Without_Error()
        {
            Util.ReturnOnlyDigits("");
        }

        [TestMethod]
        public void Util_ReturnOnlyDigits_Ok_Cases()
        {
            Assert.AreEqual(Util.ReturnOnlyDigits("1jh2jhhj3hjjh4k5jj6"),"123456","Error - Start an finish with digits");
            Assert.AreEqual(Util.ReturnOnlyDigits("jh2jhhj3hjjh4k5jj6"),"23456","Error - Finish with digits");
            Assert.AreEqual(Util.ReturnOnlyDigits("jh2jhhj3hjjh4k5jj"), "2345", "Error - Not start or finish with digits");
            Assert.AreEqual(Util.ReturnOnlyDigits("jbnfsduifjhkfsdhj"), "", "Error - Don´t have digits");
            Assert.AreEqual(Util.ReturnOnlyDigits("32321"), "32321", "Error - Only Digits");
            Assert.AreEqual(Util.ReturnOnlyDigits("1"), "1", "Error - Only one Digits");
        }


        [TestMethod]
        public void Util_ReturnOnlyDigits_Wrong_Response()
        {
            //Wrong execution
            Assert.AreNotEqual(Util.ReturnOnlyDigits("1jh2jhhj3hjjh4k5jj6"), "0");
        }

        //Due to my availability of time it will not be possible to implement all the tests as would be the correct for a real application
        //TODO: Pendent Unit Tests for FormatUsPhoneNumber
        //TODO: Pendent Unit Tests for GenerateStringWithSpecificLength

    }
}