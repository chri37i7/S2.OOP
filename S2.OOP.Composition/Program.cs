using System;
using System.Collections.Generic;

namespace S2.OOP.Composition
{
    class Program
    {
        static void Main()
        {
            //(bool isTrue, ContactInformation contactInformation) = CreateContactInformation();
            //if(isTrue)
            //{
            //    (bool isValid, Person person) = CreatePerson();
            //    if(isValid)
            //    {
            //        List<Person> persons = new List<Person>();

            //        persons.Add(person);

            //        (bool isCorrect, Address address) = CreateAddress();
            //        if(isCorrect)
            //        {
            //            Console.WriteLine(
            //                $"Addres information:\n\n" +
            //                $"Street name:  {address.StreetName},\n" +
            //                $"Street number:{address.StreetNumber},\n" +
            //                $"Zip code:     {address.Zip},\n" +
            //                $"City:         {address.City},\n" +
            //                $"Country:      {address.Country},\n" +
            //                $"Residents:    {address.Persons.Count}\n\n");

            //            foreach(Person resident in persons)
            //            {
            //                int age = resident.CalculateAge();

            //                Console.WriteLine($"Person information:\n\n" +
            //                $"Firstname: {resident.Firstname},\n" +
            //                $"Lastname:  {resident.Lastname},\n" +
            //                $"Age:       {age},\n" +
            //                $"Birthdate: {resident.BirthDate.ToString("dd-MM-yyyy")},\n" +
            //                $"Email:     {resident.ContactInformation.Mail},\n" +
            //                $"Phone:     {resident.ContactInformation.Phone}\n\n");
            //            }
            //        }
            //    }
            //}
        }

        static ContactInformation CreateContactInformation()
        {
            try
            {
                ContactInformation contactInformation = new ContactInformation("ben@dover.co.ck", "+4576876576");

                return contactInformation;
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }

        static Address CreateAddress(List<Person> persons)
        {
            try
            {
                Address address = new Address("Vårager", "13", "7120", "Vejle", "Denmark", persons);

                return address;
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        static Person CreatePerson(ContactInformation contactInformation)
        {
            try
            {
                Person person = new Person("Ben", "Dover", new DateTime(2001, 05, 02), contactInformation);

                return person;
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}