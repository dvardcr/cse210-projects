using System;
using System.Collections.Generic;
using System.IO;

public class LibraryManager
{
    // Attributes
    private List<BookLoan> borrowedBooks;
    private List<LibraryMember> members;

    // Constructor
    public LibraryManager()
    {
        borrowedBooks = new List<BookLoan>();
        members = new List<LibraryMember>();
    }

    // Method to display menu for managing borrowers
    public void ShowMenu()
    {
        Console.Clear();

        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("=== Borrower Management Menu ===");
            Console.WriteLine("1. Add a Library Member");
            Console.WriteLine("2. Borrow a Book");
            Console.WriteLine("3. Return a Book");
            Console.WriteLine("4. Save Borrowers to File");
            Console.WriteLine("5. Load Borrowers from File");
            Console.WriteLine("6. Return to Main Menu");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                AddLibraryMember();
            }
            else if (choice == "2")
            {
                BorrowBook();
            }
            else if (choice == "3")
            {
                ReturnBook();
            }
            else if (choice == "4")
            {
                SaveBorrowersToFile();
            }
            else if (choice == "5")
            {
                LoadBorrowersFromFile();
            }
            else if (choice == "6")
            {
                exit = true;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
        }
    }

    // Method to add a new library member
    private void AddLibraryMember()
    {
        Console.Write("Enter member's first name: ");
        string firstName = Console.ReadLine();

        Console.Write("Enter member's last name: ");
        string lastName = Console.ReadLine();

        Console.Write("Enter member's membership ID: ");
        string membershipId = Console.ReadLine();

        // Create a new LibraryMember instance
        LibraryMember newMember = new LibraryMember(firstName, lastName, membershipId);

        // Add the new member to the list of members
        members.Add(newMember);

        Console.WriteLine($"{firstName} {lastName} is a new member with member id {membershipId}!");
    }

    // Method to borrow a book
    private void BorrowBook()
    {
        // Code to borrow a book
    }

    // Method to return a book
    private void ReturnBook()
    {
        // Method to return a book
    }

    // Method to save borrowers to file
    private void SaveBorrowersToFile()
    {
        Console.Write("Enter file name to save borrowers: ");
        string fileName = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(fileName))
        {
            foreach (var member in members)
            {
                writer.WriteLine($"{member.GetFirstName()},{member.GetLastName()},{member.GetMembershipId()}");
            }
        }

        Console.WriteLine("Borrowers saved to file successfully!");
    }

    // Method to load borrowers from file
    private void LoadBorrowersFromFile()
    {
        Console.Write("Enter file name to load borrowers: ");
        string fileName = Console.ReadLine();

        using (StreamReader reader = new StreamReader(fileName))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(',');
                if (parts.Length == 3)
                {
                    string firstName = parts[0];
                    string lastName = parts[1];
                    string membershipId = parts[2];
                    members.Add(new LibraryMember(firstName, lastName, membershipId));
                }
            }
        }

        Console.WriteLine("Borrowers loaded from file successfully!");
    }
}