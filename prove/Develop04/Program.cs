using System;
using System.Collections.Generic;

// As Exceeding Requirements, I added an activity tracker that displays a counter for each activity completed for each session.

class Program
{
    static void Main(string[] args)
    {
        // https://www.tutorialsteacher.com/csharp/csharp-dictionary
        // https://www.geeksforgeeks.org/c-sharp-dictionary-with-examples/
        Dictionary<int, int> counter = new Dictionary<int, int>();
        Dictionary<int, string> activityNames = new Dictionary<int, string>
        {
            {1, "Breathing Activity"},
            {2, "Reflecting Activity"},
            {3, "Listing Activity"}
        };
        string userInput;

        do
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("    1. Start Breathing Activity");
            Console.WriteLine("    2. Start Reflecting Activity");
            Console.WriteLine("    3. Start Listing Activity");
            Console.WriteLine("    4. Activity Counter Tracker");
            Console.WriteLine("    5. Quit");
            Console.Write("Select a choice from this menu: ");
            userInput = Console.ReadLine();

            int option;
            if (int.TryParse(userInput, out option))
            {
                if (option >= 1 && option <= 3)
                {
                    if (!counter.ContainsKey(option))
                    {
                        counter[option] = 1;
                    }
                    else
                    {
                        counter[option]++;
                    }
                    Console.WriteLine($"You have selected option {option} {counter[option]} time(s).");
                }

                if (option == 1)
                {
                    Console.Clear();
                    BreathingActivity breathingActivity = new BreathingActivity();
                    breathingActivity.Run();
                }
                else if (option == 2)
                {
                    Console.Clear();
                    ReflectingActivity reflectingActivity = new ReflectingActivity();
                    reflectingActivity.Run();
                }
                else if (option == 3)
                {
                    Console.Clear();
                    ListingActivity listingActivity = new ListingActivity();
                    listingActivity.Run();
                }
                else if (option == 4)
                {
                    Console.Clear();
                    Console.WriteLine($"Counter Tracker\n");
                    foreach (var k in counter)
                    {
                        Console.WriteLine($"{activityNames[k.Key]}: {k.Value} time(s)");
                    }
                    Console.WriteLine($"\nPress enter to return to the Menu Options.");
                    Console.ReadKey();
                }
                else if (option == 5)
                {
                    Console.Clear();
                }
            }

        } while (userInput != "5");
    }
}
