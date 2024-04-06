using System;
using System.Collections.Generic;
using System.IO;

public class Library
{
    // Attributes
    private List<Book> bookCollection;

    // Constructor
    public Library()
    {
        bookCollection = new List<Book>();
    }

    // Method to display menu for managing books
    public void ShowMenu()
    {
        Console.Clear();

        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("=== Library Management Menu ===");
            Console.WriteLine("1. Add a Book");
            Console.WriteLine("2. Remove a Book");
            Console.WriteLine("3. Search for a Book");
            Console.WriteLine("4. Save Books to File");
            Console.WriteLine("5. Load Books from File");
            Console.WriteLine("6. Return to Main Menu");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                AddBook();
            }
            else if (choice == "2")
            {
                RemoveBook();
            }
            else if (choice == "3")
            {
                SearchBook();
            }
            else if (choice == "4")
            {
                SaveBooksToFile();
            }
            else if (choice == "5")
            {
                LoadBooksFromFile();
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

    // Method to add a book
    private void AddBook()
    {
        Console.WriteLine("Select the type of book:");
        Console.WriteLine("1. Fiction");
        Console.WriteLine("2. Children");
        Console.WriteLine("3. Biography");
        Console.WriteLine("4. Comic");

        Console.Write("Enter your choice: ");
        string choice = Console.ReadLine();

        string title, author;
        if (choice == "1")
        {
            Console.Write("Enter the title: ");
            title = Console.ReadLine();

            Console.Write("Enter the author: ");
            author = Console.ReadLine();

            Console.Write("Enter the genre: ");
            string genre = Console.ReadLine();

            Console.Write("Enter the classification: ");
            string classification = Console.ReadLine();

            bookCollection.Add(new FictionBook(title, author, genre, classification, true));
        }
        else if (choice == "2")
        {
            Console.Write("Enter the title: ");
            title = Console.ReadLine();

            Console.Write("Enter the author: ");
            author = Console.ReadLine();

            Console.Write("Enter the activities: ");
            string activities = Console.ReadLine();

            Console.Write("Enter the age: ");
            int age = int.Parse(Console.ReadLine());

            bookCollection.Add(new ChildrenBook(title, author, activities, age, true));
        }
        else if (choice == "3")
        {
            Console.Write("Enter the title: ");
            title = Console.ReadLine();

            Console.Write("Enter the author: ");
            author = Console.ReadLine();

            Console.Write("Enter the name: ");
            string name = Console.ReadLine();

            Console.Write("Enter the country: ");
            string country = Console.ReadLine();

            bookCollection.Add(new BiographyBook(title, author, name, country, true));
        }
        else if (choice == "4")
        {
            Console.Write("Enter the title: ");
            title = Console.ReadLine();

            Console.Write("Enter the author: ");
            author = Console.ReadLine();

            Console.Write("Enter the publisher: ");
            string publisher = Console.ReadLine();

            Console.Write("Enter the language: ");
            string language = Console.ReadLine();

            bookCollection.Add(new ComicBook(title, author, publisher, language, true));
        }
        else
        {
            Console.WriteLine("Invalid choice.");
        }
    }

    // Method to remove a book
    private void RemoveBook()
    {
        Console.Write("Enter the title of the book to remove: ");
        string titleToRemove = Console.ReadLine();

        Book bookToRemove = bookCollection.Find(book => book.DisplayDetails().Contains(titleToRemove));
        if (bookToRemove != null)
        {
            string[] bookDetails = bookToRemove.DisplayDetails().Split(',');
            string[] titleInfo = bookDetails[0].Split(':');

            // Extracting just the name of the book
            string bookName = titleInfo[1].Trim();

            Console.WriteLine($"Book \"{bookName}\" removed successfully.");
            bookCollection.Remove(bookToRemove);
        }
        else
        {
            Console.WriteLine($"Book \"{titleToRemove}\" not found.");
        }
    }

    // Method to search for a book
    private void SearchBook()
    {
        bool anyAvailable = false;

        Console.WriteLine("List of Books:");
        foreach (Book book in bookCollection)
        {
            string[] bookDetails = book.DisplayDetails().Split(',');
            string[] titleInfo = bookDetails[0].Split(':');

            // Extracting just the name of the book
            string bookName = titleInfo[1].Trim();

            // Extracting availability from the details
            string availability = bookDetails[bookDetails.Length - 1].Trim().ToLower() == "true" ? "available" : "unavailable";

            Console.WriteLine($"\"{bookName}\" is {availability}.");

            // Update anyAvailable flag if a book is available
            if (bookDetails[bookDetails.Length - 1].Trim().ToLower() == "true")
            {
                anyAvailable = true;
            }
        }

        // Check if no books are available
        if (!anyAvailable)
        {
            Console.WriteLine("No books are available at the moment.");
        }
    }

    // Method to save books to file
    private void SaveBooksToFile()
    {
        Console.Write("Enter the file name to save the books: ");
        string fileName = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            foreach (Book book in bookCollection)
            {
                outputFile.WriteLine(book.DisplayDetails());
            }
        }

        Console.WriteLine("Books saved to file successfully.");
    }

    // Method to load books from file
    private void LoadBooksFromFile()
    {
        Console.Write("Enter the file name to save the books: ");
        string fileName = Console.ReadLine();

        string[] lines = System.IO.File.ReadAllLines(fileName);

        foreach (string line in lines)
        {
            string[] parts = line.Split(':');

            // Extracting book type
            string bookType = parts[0];

            // Extracting book details
            string[] bookDetails = parts[1].Split(',');

            // Trim each part of book details to remove leading and trailing spaces
            for (int i = 0; i < bookDetails.Length; i++)
            {
                bookDetails[i] = bookDetails[i].Trim();
            }

            // Extracting book information
            string title = bookDetails[0];
            string author = bookDetails[1];
            string genreOrActivity = bookDetails[2];
            string classificationOrAge = bookDetails[3];
            string availabilityString = bookDetails[4].ToLower(); // Convert "true" or "false" to bool

            // Convert availability string to bool
            bool isAvailable = availabilityString == "true";

            // Create the book object based on its type
            if (bookType == "FictionBook")
            {
                string genre = genreOrActivity;
                string classification = classificationOrAge;
                bookCollection.Add(new FictionBook(title, author, genre, classification, isAvailable));
            }
            else if (bookType == "ChildrenBook")
            {
                int age;
                if (!int.TryParse(classificationOrAge, out age))
                {
                    Console.WriteLine($"Invalid age format for line: {line}. Skipping this entry.");
                    continue;
                }
                bookCollection.Add(new ChildrenBook(title, author, genreOrActivity, age, isAvailable));
            }
            else if (bookType == "BiographyBook")
            {
                string name = genreOrActivity;
                string country = classificationOrAge;
                bookCollection.Add(new BiographyBook(title, author, name, country, isAvailable));
            }
            else if (bookType == "ComicBook")
            {
                string publisher = genreOrActivity;
                string language = classificationOrAge;
                bookCollection.Add(new ComicBook(title, author, publisher, language, isAvailable));
            }
            else
            {
                Console.WriteLine($"Unknown book type \"{bookType}\". Skipping this entry.");
            }
        }

        Console.WriteLine("Books loaded successfully.");
    }
}