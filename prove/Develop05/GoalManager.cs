using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        bool exit = false;
        while (!exit)
        {
            // Console.Clear();
            DisplayPlayerInfo();
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");

            Console.Write("\nSelect a choice from the menu: ");
            string input = Console.ReadLine();
            Console.WriteLine();

            if (input == "1")
            {
                CreateGoal();
                Console.Clear();
            }
            else if (input == "2")
            {
                ListGoalDetails();
            }
            else if (input == "3")
            {
                SaveGoals();
            }
            else if (input == "4")
            {
                LoadGoals();
            }
            else if (input == "5")
            {
                RecordEvent();
            }
            else
            {
                Console.Clear();
                exit = true;
            }

            Console.WriteLine();
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"You have {_score} points.");
    }

    public void ListGoalNames()
    {
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            string detailsString = _goals[i].GetDetailsString();

            // Find the index of the closing square bracket
            int closingBracketIndex = detailsString.IndexOf(']');

            // Find the index of the opening parenthesis
            int openParenthesisIndex = detailsString.IndexOf('(');

            // Extract the name
            string name = detailsString.Substring(closingBracketIndex + 1, openParenthesisIndex - closingBracketIndex - 1).Trim();

            Console.WriteLine($"{i + 1}. {name}");
        }
    }
    public void ListGoalDetails()
    {
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }
    public void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. CheckList Goal");
        Console.Write("\nWhich type of goal would you like to create? ");

        string goalTypeInput = Console.ReadLine();
        Console.WriteLine();

        if (goalTypeInput == "1")
        {
            Console.Write("What is the name of your goal? ");
            string name = Console.ReadLine();

            Console.Write("What is a short description of it? ");
            string description = Console.ReadLine();

            Console.Write("What is the amount of points associated with this goal? ");
            int points = int.Parse(Console.ReadLine());

            // Create Simple Goal
            SimpleGoal simpleGoal = new SimpleGoal(name, description, points, false);
            _goals.Add(simpleGoal);
        }
        else if (goalTypeInput == "2")
        {
            // Logic for creating an Eternal Goal
            Console.Write("What is the name of your goal? ");
            string name = Console.ReadLine();

            Console.Write("What is a short description of it? ");
            string description = Console.ReadLine();

            Console.Write("What is the amount of points associated with this goal? ");
            int points = int.Parse(Console.ReadLine());

            // Create Eternal Goal
            EternalGoal eternalGoal = new EternalGoal(name, description, points);
            _goals.Add(eternalGoal);
        }
        else if (goalTypeInput == "3")
        {
            Console.Write("What is the name of your goal? ");
            string name = Console.ReadLine();

            Console.Write("What is a short description of it? ");
            string description = Console.ReadLine();

            Console.Write("What is the amount of points associated with this goal? ");
            int points = int.Parse(Console.ReadLine());

            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            int target = int.Parse(Console.ReadLine());

            Console.Write("What is the bonus for accomplishing it that many times? ");
            int bonus = int.Parse(Console.ReadLine());

            // Create Checklist Goal
            ChecklistGoal checklistGoal = new ChecklistGoal(name, description, points, target, bonus);
            _goals.Add(checklistGoal);
        }
    }

    public void RecordEvent()
    {
        ListGoalNames();
        Console.Write("Which goal did you accomplish? ");
        int goalIndex = int.Parse(Console.ReadLine()) - 1;

        if (goalIndex >= 0 && goalIndex < _goals.Count)
        {
            Goal selectedGoal = _goals[goalIndex];

            if (selectedGoal is SimpleGoal simpleGoal)
            {
                if (!simpleGoal.IsComplete())
                {
                    // Call RecordEvent() method of the selected goal
                    simpleGoal.RecordEvent();

                    if (simpleGoal.IsComplete())
                    {
                        // Get the string representation of the goal
                        string representation = simpleGoal.GetStringRepresentation();

                        // Parse the representation to extract points
                        string[] parts = representation.Split(',');
                        int points = int.Parse(parts[2]);

                        // Add points to the score
                        _score += points;

                        // Notify the user about the points gained
                        Console.WriteLine($"Congratulations! You have earned {points} points!");
                    }
                }
                else
                {
                    // Goal is already completed
                    Console.WriteLine("You already completed this goal. Please add a new SimpleGoal.");
                }
            }
            else if (selectedGoal is EternalGoal eternalGoal)
            {
                eternalGoal.RecordEvent();

                string representation = eternalGoal.GetStringRepresentation();

                string[] parts = representation.Split(',');
                int points = int.Parse(parts[2]);

                _score += points;

                Console.WriteLine($"Congratulations! You have earned {points} points!");
            }
            else if (selectedGoal is ChecklistGoal checklistGoal)
            {
                if (checklistGoal.IsComplete())
                {
                    Console.WriteLine("You already completed this goal. Please add a new ChecklistGoal.");
                }
                else
                {
                    checklistGoal.RecordEvent();

                    string representation = checklistGoal.GetStringRepresentation();
                    string[] parts = representation.Split(',');
                    int points = int.Parse(parts[2]);
                    _score += points;

                    if (checklistGoal.IsComplete())
                    {
                        int bonus = int.Parse(parts[3]);
                        _score += bonus;

                        Console.WriteLine($"Congratulations! You have earned {points} points and a bonus of {bonus} points!");

                        // Trigger animation
                        // Exceeding Requirements
                        AnimateCompletion();

                    }
                    else
                    {
                        Console.WriteLine($"Congratulations! You have earned {points} points!");
                    }
                }
            }

            Console.WriteLine($"You now have {_score} points.");
        }
    }

    // Exceeding Requirements
    public void AnimateCompletion()
    {
        // Display "CONGRATULATIONS" letter by letter with a slight delay
        string message = "CONGRATULATIONS!!";
        foreach (char letter in message)
        {
            Console.Write(letter);
            // Delay between each letter
            System.Threading.Thread.Sleep(250);
        }

        // Adjust the parameter according to the duration you desire
        AnimateFireworks(5);

        // Add an additional delay at the end of the animation
        System.Threading.Thread.Sleep(500);
    }

    // Exceeding Requirements
    public static void AnimateFireworks(int seconds)
    {
        char[] symbols = { '|', '*' };
        int symbolIndex = 0;

        for (int i = 0; i < seconds * 4; i++)
        {
            Console.Write(symbols[symbolIndex]);
            Thread.Sleep(250);
            Console.Write("\b");
            Thread.Sleep(250);
            Console.Write("\b");
            symbolIndex = (symbolIndex + 1) % symbols.Length;
        }
        Console.WriteLine();
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(filename))
        {
            // Write the score on the first line
            writer.WriteLine(_score);

            // Write each goal on subsequent lines
            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
    }

    public void LoadGoals()
    {
        _goals.Clear();

        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        using (StreamReader reader = new StreamReader(filename))
        {
            // Read the score from the first line
            string scoreLine = reader.ReadLine();
            _score = int.Parse(scoreLine);

            // Read each subsequent line to load goals
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(':');
                if (parts.Length >= 2) 
                {
                    string type = parts[0];
                    string details = parts[1];

                    // Directly create the goal based on the type
                    if (type == "SimpleGoal")
                    {
                        string[] goalDetails = details.Split(',');
                        // Ensure at least four details exist
                        if (goalDetails.Length >= 4)
                        {
                            string name = goalDetails[0];
                            string description = goalDetails[1];
                            int points = int.Parse(goalDetails[2]);
                            bool isComplete = bool.Parse(goalDetails[3]);
                            _goals.Add(new SimpleGoal(name, description, points, isComplete));
                        }
                    }
                    else if (type == "EternalGoal")
                    {
                        string[] goalDetails = details.Split(',');
                        // Ensure at least three details exist
                        if (goalDetails.Length >= 3)
                        {
                            string name = goalDetails[0];
                            string description = goalDetails[1];
                            int points = int.Parse(goalDetails[2]);
                            _goals.Add(new EternalGoal(name, description, points));
                        }
                    }
                    else if (type == "ChecklistGoal")
                    {
                        string[] goalDetails = details.Split(',');
                        // Ensure at least five details exist
                        if (goalDetails.Length >= 5)
                        {
                            string name = goalDetails[0];
                            string description = goalDetails[1];
                            int points = int.Parse(goalDetails[2]);
                            int bonus = int.Parse(goalDetails[3]);
                            int target = int.Parse(goalDetails[4]);
                            _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                        }
                    }
                }
            }
        }
    }
}