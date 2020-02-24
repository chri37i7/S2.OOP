using System;

namespace S2.OOP.Encapsulation
{
    class Program
    {
        static void Main()
        {
            try
            {
                Person person = new Person("Ben", "Dover", "2403698765", Gender.Male);

                Console.WriteLine($"{person.Firstname}, {person.Lastname}, {person.Cpr}, {person.Gender}, {person.Birthdate}");
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}