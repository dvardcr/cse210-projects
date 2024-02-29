using System;

class Program
{
    static void Main(string[] args)
    {   
        // Ask the user to input their last name and save it in a variable.
        Console.Write("What is your first name? ");
        string firstName = Console.ReadLine();

        // Ask the user to input their last name and save it in a variable.
        Console.Write("What is your last name? ");
        string lastName = Console.ReadLine();

        // The first name and last name will be displayed in the terminal.
        Console.Write($"Your name is {lastName}, {firstName} {lastName}.");
    }
}