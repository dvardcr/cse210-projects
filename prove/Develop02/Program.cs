using System;
using System.Collections.Generic;
using System.IO;

// Exceeding Requirements
// I added the time to the journal entry.

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Journal Program!");
        string userChoice;

        PromptGenerator promptGenerator = new PromptGenerator();

        List<Entry> entries = new List<Entry>();

        do
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");

            Console.Write("What would you like to do? ");
            userChoice = Console.ReadLine();

            int userInput = int.Parse(userChoice);
            if (userInput == 1)
            {
                string randomPrompt = promptGenerator.GetRandomPrompt();
                Console.WriteLine(randomPrompt);

                string journalEntry = Console.ReadLine();

                Entry newEntry = new Entry
                {
                    // Found easy way to get the date & time https://www.c-sharpcorner.com/blogs/date-and-time-format-in-c-sharp-programming1
                    _date = DateTime.Now.ToString("MM-dd-yyyy"),
                    _time = DateTime.Now.ToString("hh:mm tt"),
                    _promptText = randomPrompt,
                    _entryText = journalEntry
                };
                entries.Add(newEntry);
            }
            else if (userInput == 2)
            {
                DisplayAll(entries);
            }
            else if (userInput == 3)
            {
                Console.WriteLine("What is the file name?");
                string fileName = Console.ReadLine();
                entries = ReadFromFile(fileName);
            }
            else if (userInput == 4)
            {
                Console.WriteLine("What is the file name?");
                string fileName = Console.ReadLine();
                SaveToFile(fileName, entries);
            }
            else
            {
                Console.WriteLine("See you later, Alligator!");
            }

        } while (userChoice != "5");
    }

    // Method to display all entries
    public static void DisplayAll(List<Entry> entries)
    {
        if (entries.Count == 0)
        {
            Console.WriteLine("No entries to display.");
            return;
        }

        foreach (var entry in entries)
        {
            entry.Display();
            Console.WriteLine();
        }
    }

    // Method to save all entries
    public static void SaveToFile(string fileName, List<Entry> entries)
    {
        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            foreach (Entry e in entries)
            {
                outputFile.WriteLine($"Date: {e._date} {e._time} - Prompt: {e._promptText}");
                outputFile.WriteLine($"{e._entryText}");
            }
        }
        Console.WriteLine("Entries saved to file.");
    }

    // Method to load entries from a saved file
    public static List<Entry> ReadFromFile(string fileName)
    {
        List<Entry> entries = new List<Entry>();

        string[] lines = File.ReadAllLines(fileName);

        for (int i = 0; i < lines.Length; i += 2)
        {
            string[] parts = lines[i].Split(" - Prompt: ", StringSplitOptions.RemoveEmptyEntries);

            string date = parts[0].Substring(6);
            string promptText = parts[1];
            string entryText = lines[i + 1];

            Entry entry = new Entry
            {
                _date = date,
                _promptText = promptText,
                _entryText = entryText
            };

            entries.Add(entry);
        }

        return entries;
    }
}