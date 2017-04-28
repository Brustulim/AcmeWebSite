using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeWebsite.Helpers
{
    public class Util
    {

        public static string ReturnOnlyDigits(string value)
        {

            if (String.IsNullOrEmpty(value))
                value = String.Empty;

            string digitsOnly = String.Empty;
            foreach (char c in value)
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
            string result = "";

            for (int cont = 1; cont <= length; cont++)
                result += "X";

            return result;

        }

    }
}
