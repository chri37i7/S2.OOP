using System;

namespace S2.OOP.Composition
{
    class Program
    {
        static void Main()
        {
            try
            {
                Person person = new Person(
                    "Ben",
                    "Dover",
                    new DateTime(2001, 05, 02),
                    new ContactInformation(
                        "ben@dover.co.ck",
                        "+4576876576"));

                int age = person.CalculateAge();

                Console.WriteLine(
                    $"Navn:            {person.Firstname} {person.Lastname}\n" +
                    $"Fødselsdagsdato: {person.BirthDate.ToString("dd-MM-yyyy")}\n" +
                    $"Alder:           {age}\n" +
                    $"Email:           {person.ContactInformation.Mail}\n" +
                    $"Phone:           {person.ContactInformation.Phone}");
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
