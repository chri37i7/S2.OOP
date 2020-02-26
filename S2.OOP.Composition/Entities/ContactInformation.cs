using System;
using System.Collections.Generic;
using System.Text;

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
                (bool isValid, string errorMessage) = ValidateInformation(value);
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
                (bool isValid, string errorMessage) = ValidateInformation(value);
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

        public static (bool, string) ValidateInformation(string info)
        {
            if(string.IsNullOrEmpty(info))
            {
                return (false, "The value cannot be null, or empty");
            }
            else
            {
                return (true, string.Empty);
            }
        }
    }
}
