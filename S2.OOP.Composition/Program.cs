using System;
using System.Collections.Generic;

namespace S2.OOP.Composition
{
    class Program
    {
        static void Main()
        {
            (bool isTrue, ContactInformation contactInformation) = CreateContactInformation("ben@dover.co.ck", "+4576876576");
            if(isTrue)
            {
                (bool isValid, Person person) = CreatePerson("Ben", "Dover", new DateTime(2001, 05, 02), contactInformation);
                if(isValid)
                {
                    List<Person> persons = new List<Person>();

                    persons.Add(person);

                    (bool isCorrect, Address address) = CreateAddress("Vårager", "13", "7120", "Vejle", "Denmark", persons);
                    if(isCorrect)
                    {
                        Console.WriteLine(
                            $"Addres information:\n\n" +
                            $"Street name:  {address.StreetName},\n" +
                            $"Street number:{address.StreetNumber},\n" +
                            $"Zip code:     {address.Zip},\n" +
                            $"City:         {address.City},\n" +
                            $"Country:      {address.Country},\n" +
                            $"Residents:    {address.Persons.Count}\n\n");

                        foreach(Person resident in persons)
                        {
                            int age = resident.CalculateAge();

                            Console.WriteLine($"Person information:\n\n" +
                            $"Firstname: {resident.Firstname},\n" +
                            $"Lastname:  {resident.Lastname},\n" +
                            $"Age:       {age},\n" +
                            $"Birthdate: {resident.BirthDate.ToString("dd-MM-yyyy")},\n" +
                            $"Email:     {resident.ContactInformation.Mail},\n" +
                            $"Phone:     {resident.ContactInformation.Phone}\n\n");
                        }
                    }
                }
            }
        }

        static (bool, ContactInformation) CreateContactInformation(string email, string phone)
        {
            try
            {
                ContactInformation contactInformation = new ContactInformation(email, phone);

                return (true, contactInformation);
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);

                return (false, null);
            }
        }

        static (bool, Address) CreateAddress(string streetName, string streetNumber, string zip, string city, string country, List<Person> persons)
        {
            try
            {
                Address address = new Address(streetName, streetNumber, zip, city, country, persons);

                return (true, address);
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return (false, null);
            }
        }

        static (bool, Person) CreatePerson(string firstname, string lastname, DateTime birthDate, ContactInformation contactInformation)
        {
            try
            {
                Person person = new Person(firstname, lastname, birthDate, contactInformation);

                return (true, person);
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return (false, null);
            }
        }
    }
}