using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace S2.OOP.Encapsulation
{
    class Person
    {
        // Fields
        private string firstname;
        private string lastname;
        private DateTime birthday;
        private string cpr;


        // Constructor
        public Person(string firstname, string lastname, string cpr)
        {
            Firstname = firstname;
            Lastname = lastname;
            Cpr = cpr;
        }

        // Properties
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
                    throw new ArgumentOutOfRangeException(nameof(Firstname), validationResult.errorMessage);
                }
                if(value != firstname)
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
                (bool isValid, string errorMessage) validationResult = ValidateName(value);
                if(!validationResult.isValid)
                {
                    throw new ArgumentOutOfRangeException(nameof(Lastname), validationResult.errorMessage);
                }
                if(value != lastname)
                {
                    lastname = value;
                }
            }
        }

        public string Cpr
        {
            get
            {
                return cpr;
            }
            set
            {
                cpr = value;
            }
        }

        public DateTime Birthday
        {
            get
            {
                return birthday;
            }
            set
            {
                (bool isValid, string errorMessage) validationResult = Person.ValidateCpr(cpr);
                if(!validationResult.isValid)
                {
                    // stuff
                }
                else
                { // 310501  
                   // Birthday = new DateTime(Convert.ToInt64(cpr.Substring(0, 2)), Convert.ToInt64(cpr.Substring(2, 4), Convert.ToInt64(cpr.Substring(2, 4));
                }
            }
        }

        public enum Gender
        {
            Male,
            Female,
            Unspecified
        }

        public static (bool, string) ValidateCpr(string cpr)
        {
            if(cpr.Length != 10)
            {
                return (false, "Cpr must be 10 digits");
            }
            DateTime date;
            if(!DateTime.TryParseExact(cpr.Substring(0, 6), "ddMMyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
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

        public static (bool, string) ValidateName(string name)
        {
            if(name.Any(c => Char.IsWhiteSpace(c)))
            {
                return (false, "The name must not contain spaces");
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