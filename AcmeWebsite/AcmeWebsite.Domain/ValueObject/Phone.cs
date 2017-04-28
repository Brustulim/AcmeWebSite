using AcmeWebsite.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AcmeWebsite.Domain.ValueObject
{

    public class Phone
    {
        public const int PhoneMaxLength = 10;
        public string Number { get; private set; }

        
        protected Phone()
        {
            //For EF
        }

        public Phone(string number)
        {

            if (string.IsNullOrEmpty(number))
                number = "";
            else
                Validator.ValidateUsPhoneNumber(number);

            Number = Util.ReturnOnlyDigits(number);
        }


        public string GetPhoneFormatted()
        {
            if (string.IsNullOrEmpty(Number))
                return "";

            return string.Format("({0}) {1}-{2}", Number.Substring(0, 3), Number.Substring(3, 3), Number.Substring(6, 4));
        }


    }
    
}
