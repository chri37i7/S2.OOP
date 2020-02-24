using System;

namespace S2.OOP.Encapsulation
{
    class Program
    {
        static void Main()
        {
            try
            {
                Person person = new Person("ʙᴇɴ", "𝕯𝖔𝖛𝖊𝖗", "2103698765", Gender.Male);

                Console.WriteLine($"{person.Firstname} {person.Lastname}, {person.Cpr}, {person.Gender}, {person.Birthdate}");

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