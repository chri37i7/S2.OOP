using System;
using System.Collections.Generic;
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
                birthday = value;
            }
        }

        public enum Gender
        {
            Male,
            Female,
            Unspecified
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