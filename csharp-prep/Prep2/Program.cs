using System;

class Program
{   
    static void Main(string[] args)
    {
        // The user enters the respective percentage grade.
        Console.Write("What is your grade? ");
        string userInput = Console.ReadLine();
        int number = int.Parse(userInput);

        // Variables
        string letter = "";
        string newLetter = "";

        // The number is run through different conditions to get a letter grade as result.
        if (number >= 90)
        {
            letter = "A";
        }


        else if (number < 90 && number >= 80)
        {
            letter = "B";
        }


        else if (number < 80 && number >= 70)
        {
            letter = "C";
        }


        else if (number < 70 && number >= 60)
        {
            letter = "D";
        }

        else
        {
            letter = "F";
        }

        // STRETCH
        // Determine the sign based on the last digit of the percentage grade
        int lastDigit = number % 10;

        if (lastDigit >= 7 && (letter != "A" && letter != "F"))
        {
            newLetter = letter + "+";
        }
        else if (lastDigit < 3 && letter != "F")
        {
            newLetter = letter + "-";
        }
        else
        {
            newLetter = letter;
        }
        // STRETCH

        // The letter grade is printed.
        Console.WriteLine($"Your grade is {newLetter}.");

        // The number is run through a condition to determine if the student passed with 70+ percentage. A different statement is printed based on the result.
        if (number >= 70)
        {
            Console.WriteLine("Congratulations! Your determination paid off.");
        }

        else
        {
            Console.WriteLine("Don't give up! You can do better next time.");
        }

    }
}