using System;

class Program
{
    static void Main(string[] args)
    {
        string response;

        do
        {
            //Console.Write("What is the magic number? ");
            //string magicNumber = Console.ReadLine();
            //int mNumber = int.Parse(magicNumber);

            Random randomGenerator = new Random();
            int randomNumber = randomGenerator.Next(1, 100);

            Console.WriteLine("The PC thought about a number.");
            Console.Write("What is your guess? ");
            string guess = Console.ReadLine();
            int guessNumber = int.Parse(guess);

            int countGuesses = 1;

            while (randomNumber != guessNumber)
            {
                if (randomNumber > guessNumber)
                {
                    Console.WriteLine("Higher");
                }

                else
                {
                    Console.WriteLine("Lower");
                }
            
            Console.Write("What is your guess? ");
            guess = Console.ReadLine();
            guessNumber = int.Parse(guess);

            countGuesses++;

            }

            Console.WriteLine($"You guessed it in {countGuesses} attempts!");
            Console.Write("Do you want to try it again? ");
            response = Console.ReadLine();
            }
            while (response == "yes");
    }
}