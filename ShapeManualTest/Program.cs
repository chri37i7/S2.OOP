using System;
using ShapeEntities;

namespace ShapeManualTest
{
    class Program
    {
        static void Main()
        {
            // Print menu
            PrintMenu();

            // Take input
            string input = Console.ReadLine();
            int.TryParse(input, out int choice);

            // Handle choice
            HandleUserChoice(choice);
        }

        static void PrintMenu()
        {
            Console.Write(
                "Hvilke af følgende former ønsker du at oprette?\n\n" +
                " 1) Cirkel\n" +
                " 2) Rektangel\n" +
                " 3) Kvadrat\n\n" +
                "Indtast valg: ");
        }

        static void HandleUserChoice(int choice)
        {
            if(choice == 1)
            {
                // Clear console before creating circle
                Console.Clear();
                CreateCircle();
            }
            else if(choice == 2)
            {
                // Clear console before creating rectangle
                Console.Clear();
                CreateRectangle();
            }
            else if(choice == 3)
            {
                // Clear console before creating square
                Console.Clear();
                CreateSquare();
            }
            else
            {
                // Clear console before restart
                Console.Clear();
                Main();
            }
        }

        static void CreateCircle()
        {
            Console.Write("Indtast position x: ");
            string inputX = Console.ReadLine();
            int.TryParse(inputX, out int x);

            Console.Write("Indtast position y: ");
            string inputY = Console.ReadLine();
            int.TryParse(inputY, out int y);

            Console.Write("Indtast radius: ");
            string inputRadius = Console.ReadLine();
            int.TryParse(inputRadius, out int radius);

            Circle circle = new Circle(x, y, radius);

            Console.Clear();

            double area = circle.CalculateArea();
            double circumference = circle.CalculateCircumference();

            Console.WriteLine(
                $"{circle}\n" +
                $"Area: {area}\n" +
                $"Circumference: {circumference}");
        }

        static void CreateRectangle()
        {

        }

        static void CreateSquare()
        {

        }
    }
}