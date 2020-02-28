using System;
using System.Linq;

namespace S2.OOP.Composition
{
    /// <summary>
    /// Represents a <see cref="Person"/> object, containing <see cref="firstname"/>, <see cref="lastname"/>, <see cref="birthDate"/>, and <see cref="contactInformation"/>
    /// </summary>
    public class Person
    {
        // Fields
        private string firstname;
        private string lastname;
        private DateTime birthDate;
        private ContactInformation contactInformation;

        /// <summary>
        /// Creates a new <see cref="Person"/> with the provided <see cref="firstname"/>, <see cref="lastname"/>, <see cref="birthDate"/>, and <see cref="contactInformation"/>
        /// </summary>
        /// <param name="firstname"></param>
        /// <param name="lastname"></param>
        /// <param name="birthDate"></param>
        /// <param name="contactInformation"></param>
        public Person(string firstname, string lastname, DateTime birthDate, ContactInformation contactInformation)
        {
            Firstname = firstname;
            Lastname = lastname;
            BirthDate = birthDate;
            ContactInformation = contactInformation;
        }

        /// <summary>
        /// Gets or sets the value of <see cref="firstname"/>
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
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

        /// <summary>
        /// Gets or sets the value of <see cref="lastname"/>
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
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

        /// <summary>
        /// Gets or sets the value of <see cref="birthDate"/>
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
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

        /// <summary>
        /// Gets or sets the value of <see cref="contactInformation"/>
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
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

        /// <summary>
        /// Calculates the age of a <see cref="Person"/> object
        /// </summary>
        /// <returns></returns>
        public int CalculateAge()
        {
            // String for birthdate
            string birth = birthDate.ToString("yyyyMMdd");
            // String for now
            string now = DateTime.Now.ToString("yyyyMMdd");

            // Subtract birth from now, and keep the first 2 digits (20020227-20200226)/10000
            int result = ((Convert.ToInt32(now) - Convert.ToInt32(birth)) / 10000);

            // Return result
            return result;
        }

        /// <summary>
        /// Validates the input parameter to see if it only contains letters
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Validates the input parameter to see if its not <see langword="null"/>, or empty
        /// </summary>
        /// <param name="contactInformation"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Validates the input parameter to see if it is before <see cref="DateTime.Now"/>, and not more than 100 years ago
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static (bool, string) ValidateBirthDate(DateTime date)
        {
            if(date.Year >= DateTime.Now.Year)
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