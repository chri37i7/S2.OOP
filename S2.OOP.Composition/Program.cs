using System;
using System.Collections.Generic;

namespace S2.OOP.Composition
{
    class Program
    {
        static void Main()
        {
            (bool isTrue, ContactInformation contactInformation) = CreateContactInformation();
            if(isTrue)
            {
                (bool isValid, Person person) = CreatePerson(contactInformation);
                if(isValid)
                {
                    List<Person> persons = new List<Person>();

                    persons.Add(person);

                    (bool isCorrect, Address address) = CreateAddress(persons);
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
                            Console.WriteLine($"Person information:\n\n" +
                            $"Firstname: {resident.Firstname},\n" +
                            $"Lastname:  {resident.Lastname},\n" +
                            $"Birthdate: {resident.BirthDate.ToString("dd-MM-yyyy")},\n" +
                            $"Email:     {resident.ContactInformation.Mail},\n" +
                            $"Phone:     {resident.ContactInformation.Phone}\n\n");
                        }
                    }
                }
            }
        }

        static (bool, ContactInformation) CreateContactInformation()
        {
            try
            {
                ContactInformation contactInformation = new ContactInformation("ben@dover.co.ck", "+4576876576");

                return (true, contactInformation);
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);

                return (false, null);
            }
        }

        static (bool, Address) CreateAddress(List<Person> persons)
        {
            try
            {
                Address address = new Address("Vårager", "13", "7120", "Vejle", "Denmark", persons);

                return (true, address);
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return (false, null);
            }
        }

        static (bool, Person) CreatePerson(ContactInformation contactInformation)
        {
            try
            {
                Person person = new Person(
                    "Ben",
                    "Dover",
                    new DateTime(2001, 05, 02),
                    contactInformation);

                return (true, person);

                //int age = person.CalculateAge();

                //Console.WriteLine(
                //    $"Navn:            {person.Firstname} {person.Lastname}\n" +
                //    $"Fødselsdagsdato: {person.BirthDate.ToString("dd-MM-yyyy")}\n" +
                //    $"Alder:           {age}\n" +
                //    $"Email:           {person.ContactInformation.Mail}\n" +
                //    $"Phone:           {person.ContactInformation.Phone}");
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return (false, null);
            }
        }
    }
}