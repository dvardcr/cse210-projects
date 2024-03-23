using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts;

    public ListingActivity() : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.", 0) {}

    public void Run()
    {
        Console.Clear();
        base.DisplayStartingMessage();
        Console.Write("\nHow long, in seconds, would you like for your session? ");
        int duration = int.Parse(Console.ReadLine());
        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);
        Console.WriteLine(" ");
        string prompt = GetRandomPrompt();
        ShowCountDown(5);
        Console.WriteLine(" ");
        List<string> userInputList = GetListFromUser(duration);
        DisplayEndingMessage(duration);
        Console.WriteLine(" ");
        ShowSpinner(3);
    }

    public string GetRandomPrompt()
    {
        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        Random rand = new Random();
        int index = rand.Next(_prompts.Count);
        string prompt = _prompts[index];

        Console.WriteLine("List as many responses you can to the following prompt:");
        Console.WriteLine($"--- {prompt} ---");
        Console.Write("You may begin in: ");

        return prompt;
    }

    public List<string> GetListFromUser(int duration)
    {
        string userInput;
        List<string> userInputList = new List<string>();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            userInput = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(userInput))
            {
                userInputList.Add(userInput);
                _count++;
            }

            if (DateTime.Now >= endTime)
            {
                break;
            }
        }

        Console.WriteLine($"You listed {_count} items!");
        Console.WriteLine(" ");

        return userInputList;
    }
}