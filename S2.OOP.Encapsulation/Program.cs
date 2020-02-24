using System;

namespace S2.OOP.Encapsulation
{
    class Program
    {
        static void Main()
        {
            try
            {
                Person person = new Person("Ben", "Dover", "240369-8765", Gender.Male);

                Console.WriteLine($"{person.Firstname}, {person.Lastname}, {person.Cpr}, {person.Gender}, {person.Birthdate}");

                Console.ReadLine();
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);

                Console.ReadLine();
            }
        }
    }
}