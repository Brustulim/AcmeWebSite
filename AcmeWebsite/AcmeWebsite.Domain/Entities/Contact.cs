using System;
using System.Runtime.Remoting;
using AcmeWebsite.Domain.ValueObject;
using AcmeWebsite.Helpers;
using AcmeWebsite.Helpers.Resources;

namespace AcmeWebsite.Domain.Entities
{
    public class Contact : EntityBase
    {

        public const int NameMinLength = 3;
        public const int NameMaxLength = 10;
        public string Name { get; private set; }

        public const int LastNameMinFragmentLength = 2;
        public const int LastNameMaxLength = 30;
        public string LastName { get; private set; }

        //ValueObject used here
        public Email Email { get; private set; }

        //ValueObject used here
        public Phone Phone { get; private set; }

        public const int StateMaxLength = 2;
        public string State { get; private set; }

        public int City { get; private set; }

        public const int MessageMinLength = 5;
        public const int MessageMaxLength = 255;
        public string Message { get; private set; }


        protected Contact()
        {
            // For EF
        }


        public Contact(string name, string lastName, Email email, Phone phone, string state, int city, string message)
        {
            SetName(name);
            SetLastName(lastName);
            SetEmail(email);
            SetPhone(phone);
            SetState(state);
            SetCity(city);
            SetMessage(message);
        }


        #region Set Properties
        public void SetName(string name)
        {
            Validator.ForNullOrEmptyDefaultMessage(name, "Name");
            Validator.StringLengthDefaultMessage("Name", name, NameMinLength, NameMaxLength);
            Validator.ForContainWhiteSpace(name, Error.NameCannotContainWhiteSpaces) ;

            Name = name;
        }

        public void SetLastName(string lastName)
        {
            Validator.ForNullOrEmptyDefaultMessage(lastName, "Last Name");
            Validator.StringLengthDefaultMessage("Last Name", lastName, LastNameMinFragmentLength, LastNameMaxLength);

            //Verify if don´t exist fragments with less than const LastNameMinFragmentLength
            //if (Regex.Match(lastName, @"^[a-zA-Z0-9]{3,30}$").Success)
            //if (Regex.Match(lastName, @"\b.{1," + LastNameMinFragmentLength + @"}\b").Success)

            string[] fragments = lastName.Split(' ');
            if (Array.FindAll(fragments, f => f.Length < LastNameMinFragmentLength).Length > 0)
                throw new Exception("The Last Name cannot contain fragments with less than " + LastNameMinFragmentLength + " characters");

            LastName = lastName;
        }

        public void SetEmail(Email email)
        {

            if (email == null)
                throw new Exception(Error.EmailRequired);

            Email = email;
        }

        public void SetPhone(Phone phone)
        {
            if (phone != null)
                Phone = phone;
        }

        public void SetState(string state)
        {
            Validator.ForNullOrEmptyDefaultMessage(state, "State");
            Validator.StringMaxLengthDefaultMessage("State", state, StateMaxLength);
            State = state;
        }

        public void SetCity(int city)
        {
            if (city.Equals(null) || city.Equals(0))
                throw new Exception(Error.CityRequired);

            City = city;
        }

        public void SetMessage(string message)
        {
            Validator.ForNullOrEmptyDefaultMessage(message, "Message");
            Validator.StringLengthDefaultMessage("Message", message, MessageMinLength, MessageMaxLength);

            Message = message;
        }

        #endregion






    }
}
