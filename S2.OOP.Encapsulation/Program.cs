using System;

namespace S2.OOP.Encapsulation
{
    class Program
    {
        static void Main()
        {
            try
            {
                Person employee = new Person("Fuq", "Yu", "3105018765", Gender.Male);

                Console.WriteLine($"{employee.Firstname}, {employee.Lastname}, {employee.Cpr}, {employee.Birthdate}");
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}