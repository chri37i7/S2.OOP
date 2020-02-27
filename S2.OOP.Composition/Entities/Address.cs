using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S2.OOP.Composition
{
    class Address
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



        public (bool, string) ValidateZip(string zip)
        {
            if(string.IsNullOrEmpty(zip))
            {
                return (false, "The value cannot be null, or empty");
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