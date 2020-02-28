using System;
using System.Collections.Generic;
using System.Linq;

namespace S2.OOP.Composition
{
    public class Address
    {
        private string streetName;
        private string streetNumber;
        private string zip;
        private string city;
        private string country;
        private List<Person> persons;

        public Address(string streetName, string streetNumber, string zip, string city, string country, List<Person> persons)
        {
            StreetName = streetName;
            StreetNumber = streetNumber;
            Zip = zip;
            City = city;
            Country = country;
            Persons = persons;
        }

        public string StreetName
        {
            get
            {
                return streetName;
            }
            set
            {
                (bool isValid, string errorMessage) = ValidateString(value);
                if(!isValid)
                {
                    throw new ArgumentException(errorMessage, nameof(StreetName));
                }
                if(streetName != value)
                {
                    streetName = value;
                }
            }
        }

        public string StreetNumber
        {
            get
            {
                return streetNumber;
            }
            set
            {
                (bool isValid, string errorMessage) = ValidateString(value);
                if(!isValid)
                {
                    throw new ArgumentException(errorMessage, nameof(StreetNumber));
                }
                if(streetNumber != value)
                {
                    streetNumber = value;
                }
            }
        }

        public string Zip
        {
            get
            {
                return zip;
            }
            set
            {
                (bool isValid, string errorMessage) = ValidateString(value);
                if(!isValid)
                {
                    throw new ArgumentException(errorMessage, nameof(Zip));
                }
                if(zip != value)
                {
                    zip = value;
                }
            }
        }

        public string City
        {
            get
            {
                return city;
            }
            set
            {
                (bool isValid, string errorMessage) = ValidateCity(value);
                if(!isValid)
                {
                    throw new ArgumentException(errorMessage, nameof(City));
                }
                if(city != value)
                {
                    city = value;
                }
            }
        }

        public string Country
        {
            get
            {
                return country;
            }
            set
            {
                (bool isValid, string errorMessage) = ValidateCountry(value);
                if(!isValid)
                {
                    throw new ArgumentException(errorMessage, nameof(Country));
                }
                if(country != value)
                {
                    country = value;
                }
            }
        }

        public List<Person> Persons
        {
            get
            {
                return persons;
            }
            set
            {
                if(persons != value)
                {
                    persons = value;
                }
            }
        }

        public int GetNumberOfPeople()
        {
            return persons.Count();
        }

        public (bool, string) ValidateString(string input)
        {
            if(string.IsNullOrEmpty(input))
            {
                return (false, "The value cannot be null, or empty");
            }
            else
            {
                return (true, string.Empty);
            }
        }

        public static (bool, string) ValidatePersons(List<Person> persons)
        {
            if(persons.Count < 1)
            {
                return (false, "The list must contain 1, or more objects");
            }
            else
            {
                return (true, string.Empty);
            }
        }

        public (bool, string) ValidateCity(string city)
        {
            if(string.IsNullOrEmpty(city))
            {
                return (false, "The value cannot be null, or empty");
            }
            if(!city.All(c => char.IsLetter(c)))
            {
                return (false, "The value must not contain letters");
            }
            else
            {
                return (true, string.Empty);
            }
        }

        public (bool, string) ValidateCountry(string country)
        {
            if(string.IsNullOrEmpty(country))
            {
                return (false, "The value cannot be null, or empty"); 
            }
            if(!country.All(c => char.IsLetter(c)))
            {
                return (false, "The value must not contain numbers");
            }
            if(country.Length < 4)
            {
                return (false, "The value cannot be shorter than 4 letters");
            }
            else
            {
                return (true, string.Empty);
            }
        }
    }
}