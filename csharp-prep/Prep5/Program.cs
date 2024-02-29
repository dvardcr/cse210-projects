using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();

        string fullName = PromptUserName();
        int number = PromptUserNumber();
        int squaredNumber = SquareNumber(number);

        DisplayResult(fullName, squaredNumber);
    }

        static void DisplayWelcome()
        {
            Console.WriteLine("Welcome to the Program!");
        }

        static string PromptUserName()
        {
            Console.Write("Please enter your name: ");
            string fullName = Console.ReadLine();
            return fullName;
        }

        static int PromptUserNumber()
        {
            Console.Write("Please enter your favorite number: ");
            string numberInput = Console.ReadLine();
            int number = int.Parse(numberInput);
            return number;
        }

        static int SquareNumber(int number)
        {
            return number * number;
        }

        static void DisplayResult(string fullName, int squaredNumber)
        {
            Console.WriteLine($"{fullName}, the square of your number is {squaredNumber}");
    }
}