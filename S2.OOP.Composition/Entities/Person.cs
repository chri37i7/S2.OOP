using System;
using System.Linq;

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
                (bool isValid, string errorMessage) = ValidateBirthDate(value);
                if(!isValid)
                {
                    throw new ArgumentOutOfRangeException(nameof(BirthDate), errorMessage);
                }
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

        public int CalculateAge()
        {
            // String for birthdate
            string birth = birthDate.ToString("yyyyMMdd");
            // String for now
            string now = DateTime.Now.ToString("yyyyMMdd");

            // Subtract birth from now, and keep the first 2 digits
            int result = ((Convert.ToInt32(now) - Convert.ToInt32(birth)) / 10000);

            // Return result
            return result;
        }

        public static (bool, string) ValidateName(string name)
        {
            if(!name.All(c => char.IsLetter(c)))
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

        public static (bool, string) ValidateBirthDate(DateTime date)
        {
            if(date >= DateTime.Now)
            {
                return (false, "The date is in the future");
            }
            if(date.Year < (DateTime.Now.Year - 100))
            {
                return (false, "The date cannot be more than 100 years ago"); 
            }
            else
            {
                return (true, string.Empty);
            }
        }
    }
}