using System;
using Xunit;
using S2.OOP.Composition;
using System.Collections.Generic;

namespace S2.OOP.UnitTesting
{
    public class UnitTesting
    {
        [Fact]
        public void CreateObjects()
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
        }
    }
}
