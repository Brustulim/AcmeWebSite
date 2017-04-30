using System;
using System.Text.RegularExpressions;
using AcmeWebsite.Helpers;

namespace AcmeWebsite.Domain.ValueObject
{
    public class Email
    {
        public const int AddressMaxLength = 254;
        public string Address { get; private set; } //DDD require private set

        //Constructor without parameter for EntityFramework use (secured through "protected")
        protected Email()
        {
            //For EF use only
        }

        public Email(string address)
        {

            Validator.ForNullOrEmptyDefaultMessage(address, "E-mail");
            Validator.StringMaxLengthDefaultMessage("E-mail", address, AddressMaxLength);

            if (IsValid(address) == false)
                throw new Exception("Invalid e-mail!");

            Address = address;
        }

        private static bool IsValid(string email)
        {
            var regexEmail = new Regex(@"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");
            return regexEmail.IsMatch(email);
        }
    }
}
