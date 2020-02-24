using System;

namespace S2.OOP.Encapsulation
{
    class Program
    {
        static void Main()
        {

            string input = "3105018765";

            (bool isValid, string errorMessage) validationResult = Person.ValidateCpr(input);
            if(!validationResult.isValid)
            {
                Console.WriteLine(validationResult.errorMessage);
            }
            else
            {
                Person employee = new Person("Fuq", "Yu", input, Gender.Male);

                Console.WriteLine($"{employee.Firstname}, {employee.Lastname}, {employee.Cpr}, {employee.Birthdate}");
            }
        }
    }
}
