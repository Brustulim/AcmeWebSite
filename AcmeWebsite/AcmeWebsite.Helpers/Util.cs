using System;

namespace AcmeWebsite.Helpers
{
    public class Util
    {

        public static string ReturnOnlyDigits(string value)
        {

            if (string.IsNullOrEmpty(value))
                value = string.Empty;

            var digitsOnly = string.Empty;
            foreach (var c in value)
            {
                // Do not use IsDigit as it will include more than the characters 0 through to 9
                if (c >= '0' && c <= '9') digitsOnly += c;
            }

            return digitsOnly;
        }

        public static string FormatUsPhoneNumber(string value)
        {
            return string.Format("{0:(###) ###-####}", value);
        }

        public static string GenerateStringWithSpecificLength(int length)
        {
            var result = "";

            for (var cont = 1; cont <= length; cont++)
                result += "X";

            return result;

        }

    }
}
