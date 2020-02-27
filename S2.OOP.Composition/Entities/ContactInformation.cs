using System;
using System.Text.RegularExpressions;

namespace S2.OOP.Composition
{
    class ContactInformation
    {
        private string mail;
        private string phone;

        public ContactInformation(string mail, string phone)
        {
            Mail = mail;
            Phone = phone;
        }

        public string Mail
        {
            get
            {
                return mail;
            }
            set
            {
                (bool isValid, string errorMessage) = ValidateEmail(value);
                if(!isValid)
                {
                    throw new ArgumentException(errorMessage, nameof(Mail));
                }
                if(mail != value)
                {
                    mail = value;
                }
            }
        }

        public string Phone
        {
            get
            {
                return phone;
            }
            set
            {
                (bool isValid, string errorMessage) = ValidatePhoneNumber(value);
                if(!isValid)
                {
                    throw new ArgumentException(errorMessage, nameof(Phone));
                }
                if(phone != value)
                {
                    phone = value;
                }
            }
        }

        public static (bool, string) ValidatePhoneNumber(string number)
        {
            string regex = @"^\+(?:[0-9]●?){6,14}[0-9]$";

            if(!Regex.IsMatch(number, regex))
            {
                return (false, "The value is not a valid international phone number");
            }
            else
            {
                return (true, string.Empty);
            }
        }

        public static (bool, string) ValidateEmail(string email)
        {
            if(string.IsNullOrEmpty(email))
            {
                return (false, "The value cannot be null, or empty");
            }
            if(!email.Contains("@"))
            {
                return (false, "The email must contain an \"@\"");
            }
            else
            {
                return (true, string.Empty);
            }
        }
    }
}