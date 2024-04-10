using System;
using System.Collections.Generic;
using System.IO;

class MemberManager
{
    private List<string> members = new List<string>();
    private string fileName;

    public List<string> Members
    {
        get { return members; }
    }

    public void Run()
    {
        bool exitMemberManager = false;
        while (!exitMemberManager)
        {
            Console.WriteLine("\n=== Member Manager ===");
            Console.WriteLine("1. Add Member");
            Console.WriteLine("2. Remove Member");
            Console.WriteLine("3. Display Members");
            Console.WriteLine("4. Save Members to File");
            Console.WriteLine("5. Load Members from File");
            Console.WriteLine("6. Return to Main Menu");

            Console.Write("Select an option: ");
            string userInput = Console.ReadLine();

            if (userInput == "1")
            {
                AddMember();
            }
            else if (userInput == "2")
            {
                RemoveMember();
            }
            else if (userInput == "3")
            {
                DisplayMembers();
            }
            else if (userInput == "4")
            {
                SaveMembersToFile();
            }
            else if (userInput == "5")
            {
                LoadMembersFromFile();
            }
            else if (userInput == "6")
            {
                Console.Clear();
                exitMemberManager = true;
            }
            else
            {
                Console.WriteLine("Invalid option. Please select again.");
                Console.WriteLine("");
            }
        }
    }

    private void AddMember()
    {
        Console.WriteLine("\n=== Add Member ===");
        Console.Write("Enter member name: ");
        string memberName = Console.ReadLine();
        members.Add(memberName);
        Console.WriteLine("Member added successfully!");
        Console.WriteLine("");
    }

    private void RemoveMember()
    {
        Console.WriteLine("\n=== Remove Member ===");

        DisplayMembers();

        if (members.Count == 0)
        {
            Console.WriteLine("No members available to remove.");
            Console.WriteLine("");
            return;
        }

        Console.Write("Enter the index of the member to remove: ");

        if (int.TryParse(Console.ReadLine(), out int index) && index >= 0 && index < members.Count)
        {
            members.RemoveAt(index);
            Console.WriteLine("Member removed successfully!");
            Console.WriteLine("");
        }
        else
        {
            Console.WriteLine("Invalid index. Please try again.");
            Console.WriteLine("");
        }
    }

    public void DisplayMembers()
    {
        Console.WriteLine("\n=== Members ===");
        if (members.Count == 0)
        {
            Console.WriteLine("No members available.");
            Console.WriteLine("");
            return;
        }
        for (int i = 0; i < members.Count; i++)
        {
            Console.WriteLine($"{i}. {members[i]}");
        }
    }

    private void SaveMembersToFile()
    {
        Console.Write("Enter file name for saving members: ");
        fileName = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(fileName))
        {
            foreach (string member in members)
            {
                writer.WriteLine(member);
            }
        }
        Console.WriteLine("Members saved to file successfully!");
        Console.WriteLine("");
    }

    private void LoadMembersFromFile()
    {
        Console.Write("Enter file name for loading members: ");
        fileName = Console.ReadLine();

        if (!File.Exists(fileName))
        {
            Console.WriteLine("File not found.");
            return;
        }

        members.Clear();
        using (StreamReader reader = new StreamReader(fileName))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                members.Add(line);
            }
        }
        Console.WriteLine("Members loaded from file successfully!");
        Console.WriteLine("");
    }
}