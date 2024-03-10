using System.Collections.Generic;

public class PromptGenerator
{
    // List of prompts
    private List<string> _prompts = new List<string>
    { "Who was the most interesting person I interacted with today?", "What was the best part of my day?", "How did I see the hand of the Lord in my life today?", "What was the strongest emotion I felt today?", "If I had one thing I could do over today, what would it be?", "What unexpected obstacle did I encounter today, and how did I navigate through it?", "Recount a moment from today where I felt fully engaged and present in my actions.", "Recall a small act of kindness from today that made an impact.", "How did I prioritize my own well-being or self-care throughout the day?", "What new insight about myself or the world around me did I gain today?" };

    // Method to get a random prompt from the list
    public string GetRandomPrompt()
    {
        Random rand = new Random();
        int index = rand.Next(0, _prompts.Count);
        return _prompts[index];
    }
}