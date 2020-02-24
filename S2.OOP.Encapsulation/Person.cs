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
        public Person(string firstname, string lastname, DateTime birthday, string cpr)
        {
            Firstname = firstname;

            Birthday = birthday;
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
                if(value.All(c => Char.IsWhiteSpace(c)))
                {
                    throw new ArgumentException("The name must not be all spaces", nameof(firstname));
                }
                if(string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(nameof(firstname), "The name cannot be empty");
                }
                if(value.Length < 1)
                {
                    throw new ArgumentOutOfRangeException(nameof(firstname), "The name cannot be lower than one character");
                }
                if(value != firstname)
                {
                    value = firstname;
                }
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

        public enum Gender
        {
            Male,
            Female,
            Unspecified
        }
    }
}