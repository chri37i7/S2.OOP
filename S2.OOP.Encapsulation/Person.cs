using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace S2.OOP.Encapsulation
{
    /// <summary>
    /// Gender of a <see cref="Person"/> object
    /// </summary>
    public enum Gender
    {
        Male,
        Female,
        Unspecified
    }

    public class Person
    {
        // Fields
        private string firstname;
        private string lastname;
        private DateTime birthdate;
        private string cpr;
        private Gender gender;


        /// <summary>
        /// Creates a new <see cref="Person"/> with the provided <see cref="firstname"/>, <see cref="lastname"/>, <see cref="cpr"/>, and <see cref="gender"/>
        /// </summary>
        /// <param name="firstname">The persons firstname</param>
        /// <param name="lastname">The persons lastname</param>
        /// <param name="cpr">The persons CPR-number</param>
        /// <param name="gender">The persons gender</param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public Person(string firstname, string lastname, string cpr, Gender gender)
        {
            Firstname = firstname;
            Lastname = lastname;
            Cpr = cpr;
            Gender = gender;
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
                (bool isValid, string errorMessage) validationResult = ValidateName(value);
                if(!validationResult.isValid)
                {
                    throw new ArgumentException(nameof(Firstname), validationResult.errorMessage);
                }
                if(value != firstname)
                {
                    firstname = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets value of <see cref="lastname"/>
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
                (bool isValid, string errorMessage) validationResult = ValidateName(value);
                if(!validationResult.isValid)
                {
                    throw new ArgumentException(nameof(Lastname), validationResult.errorMessage);
                }
                if(value != lastname)
                {
                    lastname = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the value of <see cref="cpr"/>
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        public string Cpr
        {
            get
            {
                return cpr;
            }
            set
            {
                (bool isValid, string errorMessage) validationResult = ValidateCpr(value);
                if(!validationResult.isValid)
                {
                    throw new ArgumentOutOfRangeException(nameof(Cpr), validationResult.errorMessage);
                }
                if(cpr != value)
                {
                    cpr = value;
                }
            }
        }

        /// <summary>
        /// Gets the value of <see cref="birthdate"/>
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public DateTime Birthdate
        {
            get
            {
                (bool isValid, string errorMessage) validationResult = ValidateCpr(Cpr);
                if(!validationResult.isValid)
                {
                    throw new ArgumentOutOfRangeException(nameof(Birthdate), validationResult.errorMessage);
                }
                else
                {
                    DateTime.TryParseExact(Cpr.Substring(0, 6), "ddMMyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date);

                    birthdate = date;

                    return birthdate;
                }
            }
        }

        /// <summary>
        /// Gets or sets the value of <see cref="gender"/>
        /// </summary>
        public Gender Gender
        {
            get
            {
                return gender;
            }
            set
            {
                if(gender != value)
                {
                    gender = value;
                }
            }
        }

        /// <summary>
        /// Validates the input parameter to see if its a valid CPR-number
        /// </summary>
        public static (bool, string) ValidateCpr(string cpr)
        {
            if(cpr.Length != 10)
            {
                return (false, "A CPR-number must be 10 digits");
            }
            if(cpr.Any(c => Char.IsLetter(c)))
            {
                return (false, "A CPR-number cannot containt letters");
            }
            if(!DateTime.TryParseExact(cpr.Substring(0, 6), "ddMMyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
            {
                return (false, "The first six digits are an invalid date");
            }
            if(date > DateTime.Now)
            {
                return (false, "The first six digits are in the future");
            }
            else
            {
                return (true, String.Empty);
            }
        }

        /// <summary>
        /// Validates the input parameter to see if its a valid name
        /// </summary>
        public static (bool, string) ValidateName(string name)
        {
            if(name.Any(c => Char.IsWhiteSpace(c)))
            {
                return (false, "The name must not contain spaces");
            }
            if(name.Any(c => Char.IsNumber(c)))
            {
                return (false, "The name must not contain numbers");
            }
            if(string.IsNullOrEmpty(name))
            {
                return (false, "The name cannot be empty");
            }
            if(name.Length < 1)
            {
                return (false, "The name cannot be lower than one character");
            }
            else
            {
                return (true, String.Empty);
            }
        }
    }
}