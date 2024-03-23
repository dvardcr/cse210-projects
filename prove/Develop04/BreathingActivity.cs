using System;

public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.", 0) {}

    public void Run()
    {
        Console.Clear();
        base.DisplayStartingMessage();
        Console.WriteLine(" ");
        Console.Write("How long, in seconds, would you like for your session? ");
        int duration = int.Parse(Console.ReadLine());
        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("\n\nBreathe in...");
            ShowCountDown(4);

            if (DateTime.Now >= endTime)
                break;

            Console.Write("\nNow breathe out...");
            ShowCountDown(6);
        }

        Console.WriteLine(" ");
        ShowSpinner(4);
        Console.WriteLine(" ");
        DisplayEndingMessage(duration);
        Console.WriteLine(" ");
        ShowSpinner(4);
    }
}