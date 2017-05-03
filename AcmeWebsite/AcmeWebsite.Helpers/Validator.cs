using System;
using System.Text.RegularExpressions;

namespace AcmeWebsite.Helpers
{
    public class Validator
    {
        public static void ForNullOrEmpty(string value, string message)
        {
            if (string.IsNullOrEmpty(message))
                throw new Exception("Message cannot be empty!");

            if (string.IsNullOrEmpty(value))
                throw new Exception(message);
        }
                
        public static void ForNullOrEmptyDefaultMessage(string value, string propName)
        {
            if (string.IsNullOrEmpty(propName))
                throw new Exception("Property name cannot be empty!");

            if (string.IsNullOrEmpty(value))
                throw new Exception($"{propName} is required!");
        }

        public static void ForContainWhiteSpace(string value, string message)
        {
            if (Regex.Match(value, @"(\s)").Success)
                throw new Exception(message);
        }

        public static void StringMaxLength(string stringValue, int maximum, string message)
        {

            if (string.IsNullOrEmpty(message))
                throw new Exception("Message cannot be empty!");

            if (string.IsNullOrEmpty(stringValue))
                stringValue = string.Empty;

            var length = stringValue.Length;
            if (length > maximum)
            {
                throw new Exception(message);
            }
        }

        public static void StringMaxLengthDefaultMessage(string propName, string stringValue, int maximum)
        {
            if (string.IsNullOrEmpty(propName))
                throw new Exception("Property name cannot be empty!");
            var message = $"{propName} may not be greater than {maximum} characters!";

            StringMaxLength(stringValue, maximum, message);
        }

        public static void StringLength(string stringValue, int minimum, int maximum, string message)
        {

            if (string.IsNullOrEmpty(message))
                throw new Exception("Message cannot be empty!");

            if (string.IsNullOrEmpty(stringValue))
                stringValue = string.Empty;

            var length = stringValue.Length;
            if (length < minimum || length > maximum)
            {
                throw new Exception(message);
            }
        }

        public static void StringLengthDefaultMessage(string propName, string stringValue, int minimum, int maximum)
        {
            if (string.IsNullOrEmpty(propName))
                throw new Exception("Property name cannot be empty!");

            var message = $"{propName} must be the {minimum} to {maximum} characters!";

            StringLength(stringValue, minimum, maximum, message);
        }
        
        public static void AreEqual(string a, string b, string message)
        {
            if (string.IsNullOrEmpty(message))
                throw new Exception("Message cannot be empty!");

            if (a != b)
                throw new Exception(message);
        }
        
        public static void ValidateUsPhoneNumber(string number)
        {
                if (!Regex.Match(number, @"([(]\d{3}[)][\s]\d{3}[-]\d{4})").Success)
                    throw new Exception(number + " Is a invalid US Phone Number!");
        }

        

    }
}
