﻿using System;
using System.Globalization;
using System.Linq;

namespace S2.OOP.Encapsulation
{
    /// <summary>
    /// <see cref="Gender"/> of a <see cref="Person"/> class object
    /// </summary>
    public enum Gender
    {
        Male,
        Female,
        Unspecified
    }

    /// <summary>
    /// Represents a <see cref="Person"/> object, containing <see cref="firstname"/>, <see cref="lastname"/>, <see cref="birthdate"/>, <see cref="cpr"/>, and <see cref="gender"/>
    /// </summary>
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
                (bool isValid, string errorMessage) = ValidateName(value);
                if(!isValid)
                {
                    throw new ArgumentException(errorMessage, nameof(Firstname));
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
                (bool isValid, string errorMessage) = ValidateName(value);
                if(!isValid)
                {
                    throw new ArgumentException(errorMessage, nameof(Lastname));
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
                (bool isValid, string errorMessage) = ValidateCpr(value);
                if(!isValid)
                {
                    throw new ArgumentOutOfRangeException(nameof(Cpr), errorMessage);
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
                (bool isValid, string errorMessage) = ValidateCpr(Cpr);
                if(!isValid)
                {
                    throw new ArgumentOutOfRangeException(nameof(Birthdate), errorMessage);
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
        ///  Used to validate a <see cref="cpr"/> to see if its a valid CPR-number
        /// </summary>
        /// <param name="cpr"></param>
        /// <returns></returns>
        public static (bool, string) ValidateCpr(string cpr)
        {
            if(cpr.Length != 10)
            {
                return (false, "A CPR-number must be 10 digits");
            }
            if(cpr.Any(c => char.IsLetter(c)))
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
                return (true, string.Empty);
            }
        }

        /// <summary>
        /// Used to validate a <see cref="firstname"/>, or <see cref="lastname"/> to see if its a valid name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static (bool, string) ValidateName(string name)
        {
            if(!name.All(c => char.IsLetter(c)))
            {
                return (false, "The name must only consist of letters");
            }
            else
            {
                return (true, string.Empty);
            }
        }
    }
}