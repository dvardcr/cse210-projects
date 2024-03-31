using System;

// Added a small animation when the bonus is earned for the completion of the ChecklistGoal.
// I also added a stop if the user wants to continue completing a Simple or a Checklist goal.

class Program
{
    static void Main(string[] args)
    {
        GoalManager goalManager = new GoalManager();
        goalManager.Start();
    }
}