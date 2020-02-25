using System;

namespace S2.OOP.Encapsulation
{
    class Program
    {
        static void Main()
        {
            try
            {
                Person person = new Person("ʙᴇɴ", "𝕯𝖔𝖛𝖊𝖗", "2412048764", Gender.Male);

                Console.WriteLine($"{person.Firstname} {person.Lastname}, {person.Cpr}, {person.Gender}, {person.Birthdate}");

                Console.ReadLine();
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);

                Console.ReadLine();
            }
            try
            {
                Account account = new Account("XD42069420", "X125", -69.0m);

                Console.WriteLine($"{account.AccountNumber}, {account.DepartmentNumber}, {account.Balance}");

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