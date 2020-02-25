using System;

namespace S2.OOP.Encapsulation
{
    class Program
    {
        static void Main()
        {
            CreatePerson();

            CreateAccount();

            CreateField();
        }

        static void CreatePerson()
        {
            // Person class
            try
            {
                Person person = new Person("Ben", "Dover", "2412048764", Gender.Male);

                Console.WriteLine(
                    $"\n\nPerson Class Object:\n\n" +
                    $"Name:      {person.Firstname} {person.Lastname}\n" +
                    $"CPR:       {person.Cpr}\n" +
                    $"Gender:    {person.Gender}\n" +
                    $"Birthdate: {person.Birthdate.ToString("dd-MM-yyyy")}\n");

                Console.WriteLine();
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);

                Console.ReadLine();
            }
        }

        static void CreateAccount()
        {
            // Account class
            try
            {
                Account account = new Account("XD42069420", "X125", 69.0m);

                Console.WriteLine(
                    $"Account Class Object:\n\n" +
                    $"Account Number:    {account.AccountNumber}\n" +
                    $"Department Number: {account.DepartmentNumber}\n" +
                    $"Balance:           {account.Balance:c}\n");

                Console.WriteLine();
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);

                Console.ReadLine();
            }
        }

        static void CreateField()
        {
            // Field class
            try
            {
                Field field = new Field(5, 6, Crop.Wheat);

                Console.WriteLine(
                    $"Field Class Object:\n\n" +
                    $"Length: {field.Length}\n" +
                    $"Width:  {field.Width}\n" +
                    $"Area:   {field.Area}\n" +
                    $"Crop:   {field.Crop}\n" +
                    $"Yield:  {field.Yield}\n");

                Console.ReadLine();
            }
            catch(ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}