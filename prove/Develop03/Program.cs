using System;
using System.Collections.Generic;

//Exceeding Requirements// 
//As a stretch challenge, added the code to randomly select from only the words that are not already hidden.
//Added code in Scripture.cs

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();

        // Build Reference object
        Reference reference = new Reference("Proverbs", 3, 5, 6);

        // Build Scripture object
        string verseText = "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths.";
        Scripture scriptures = new Scripture(reference, verseText);

        Console.WriteLine($"{reference.GetDisplayText()} {scriptures.GetDisplayText()}");
        Console.WriteLine("Press Enter to continue or type 'quit' to exit");
        Console.ReadLine();

        while (!scriptures.IsCompletelyHidden())
        {
            Console.Clear();

            // Hiding random words in the scripture
            scriptures.HideRandomWords(3);
            Console.WriteLine($"{reference.GetDisplayText()} {scriptures.GetDisplayText()}");

            Console.WriteLine("Press Enter to continue or type 'quit' to exit");
            string input = Console.ReadLine().Trim();

            if (input.Equals("quit", StringComparison.OrdinalIgnoreCase))
            {
                return;
            }
        }
    }
}