using System;
using System.Collections.Generic;

namespace S2.OOP.Composition
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Person list
                List<Person> persons = new List<Person>();


                // Contact informations
                ContactInformation firstInformation = new ContactInformation("ben@dover.co.ck", "+4576876576");
                ContactInformation secondInformation = new ContactInformation("tony@dover.co.ck", "+4576876576");

                // Persons
                Person firstPerson = new Person("Ben", "Dover", new DateTime(2001, 05, 02), firstInformation);
                Person secondPerson = new Person("Tony", "Dover", new DateTime(2000, 07, 12), secondInformation);

                // Add persons to list
                persons.Add(firstPerson);
                persons.Add(secondPerson);


                // Address
                Address address = new Address("Vårager", "13", "7120", "Vejle", "Denmark", persons);


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
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}