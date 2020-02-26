using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S2.OOP.Composition
{
    class Person
    {
        private string firstname;
        private string lastname;
        private DateTime birthDate;
        private ContactInformation contactInformation;

        public Person(string firstname, string lastname, DateTime birthDate, ContactInformation contactInformation)
        {
            Firstname = firstname;
            Lastname = lastname;
            BirthDate = birthDate;
            ContactInformation = contactInformation;
        }

        public string Firstname
        {
            get
            {
                return firstname;
            }
            set
            {
                (bool isValid, string errorMessage) = ValidateName(value);
                if(!isValid)
                {
                    throw new ArgumentException(errorMessage, nameof(Firstname));
                }
                if(firstname != value)
                {
                    firstname = value;
                }
            }
        }

        public string Lastname
        {
            get
            {
                return lastname;
            }
            set
            {
                (bool isValid, string errorMessage) = ValidateName(value);
                if(!isValid)
                {
                    throw new ArgumentException(errorMessage, nameof(Lastname));
                }
                if(lastname != value)
                {
                    lastname = value;
                }
            }
        }

        public DateTime BirthDate
        {
            get
            {
                return birthDate;
            }
            set
            {
                if(birthDate != value)
                {
                    birthDate = value;
                }
            }
        }

        public ContactInformation ContactInformation
        {
            get
            {
                return contactInformation;
            }
            set
            {
                (bool isValid, string errorMessage) = ValidateContactInformation(value);
                if(!isValid)
                {
                    throw new ArgumentException(errorMessage, nameof(ContactInformation));
                }
                if(contactInformation != value)
                {
                    contactInformation = value;
                }
            }
        }

        public static (bool, string) ValidateName(string name)
        {
            if(!name.Any(c => char.IsLetter(c)))
            {
                return (false, "The name must only contain letters");
            }
            else
            {
                return (true, string.Empty);
            }
        }

        public static (bool, string) ValidateContactInformation(ContactInformation contactInformation)
        {
            if(string.IsNullOrEmpty(contactInformation.Mail))
            {
                return (false, "The property \"Mail\" cannot be null, or empty");
            }
            if(string.IsNullOrEmpty(contactInformation.Phone))
            {
                return (false, "The property \"Phone\" cannot be null, or empty");
            }
            else
            {
                return (true, string.Empty);
            }
        }
    }
}
