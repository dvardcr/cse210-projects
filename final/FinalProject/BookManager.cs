using System;
using System.Collections.Generic;
using System.IO;

class BookManager
{
    private List<Book> books;
    private string fileName;

    public List<Book> Books
    {
        get { return books; }
    }

    public BookManager()
    {
        books = new List<Book>();
    }

    public void AddBook(Book book)
    {
        books.Add(book);
    }

    public void RemoveBook(Book book)
    {
        books.Remove(book);
    }

    public void DisplayBooks()
    {
        Console.WriteLine("\n=== Books ===");

        if (books.Count == 0)
        {
            Console.WriteLine("No books available.");
            Console.WriteLine("");
            return;
        }

        for (int i = 0; i < books.Count; i++)
        {
            // Console.WriteLine($"{i}. {books[i].DisplayDetails()}");

            string[] bookDetails = books[i].DisplayDetails().Split(',');
            // Get the last item (availability) and trim spaces
            string availability = bookDetails[bookDetails.Length - 1].Trim();

            Console.WriteLine($"{i}. {string.Join(",", bookDetails, 0, bookDetails.Length - 1)}, Availability: {availability}");
        }
    }

    public void Run()
    {
        bool exitMenu = false;
        while (!exitMenu)
        {
            Console.WriteLine("=== Book Manager Menu ===");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. Remove Book");
            Console.WriteLine("3. Display Books");
            Console.WriteLine("4. Save Books to File");
            Console.WriteLine("5. Load Books from File");
            Console.WriteLine("6. Return to Main Menu");

            Console.Write("Select an option: ");
            string userInput = Console.ReadLine();

            if (userInput == "1")
            {
                AddBookMenu();
            }
            else if (userInput == "2")
            {
                RemoveBookMenu();
            }
            else if (userInput == "3")
            {
                DisplayBooks();
            }
            else if (userInput == "4")
            {
                SaveBooksToFile();
            }
            else if (userInput == "5")
            {
                LoadBooksFromFile();
            }
            else if (userInput == "6")
            {
                Console.Clear();
                exitMenu = true;
            }
            else
            {
                Console.WriteLine("Invalid option. Please select again.");
            }
        }
    }

    private void AddBookMenu()
    {
        Console.WriteLine("=== Add Book ===");
        Console.WriteLine("Select the type of book:");
        Console.WriteLine("1. Fiction Book");
        Console.WriteLine("2. Comic Book");
        Console.WriteLine("3. Children's Book");
        Console.WriteLine("4. Biography Book");
        Console.Write("Enter your choice: ");

        string choice = Console.ReadLine();
        if (choice == "1")
        {
            AddFictionBook();
        }
        else if (choice == "2")
        {
            AddComicBook();
        }
        else if (choice == "3")
        {
            AddChildrenBook();
        }
        else if (choice == "4")
        {
            AddBiographyBook();
        }
        else
        {
            Console.WriteLine("Invalid choice.");
        }
    }

    private void AddFictionBook()
    {
        Console.Write("Enter title: ");
        string title = Console.ReadLine();
        Console.Write("Enter author: ");
        string author = Console.ReadLine();
        Console.Write("Enter classification: ");
        string classification = Console.ReadLine();
        Console.Write("Enter type: ");
        string type = Console.ReadLine();

        Book book = new FictionBook(title, author, classification, type, true);
        AddBook(book);
    }

    private void AddComicBook()
    {
        Console.Write("Enter title: ");
        string title = Console.ReadLine();
        Console.Write("Enter author: ");
        string author = Console.ReadLine();
        Console.Write("Enter publisher: ");
        string publisher = Console.ReadLine();
        Console.Write("Enter language: ");
        string language = Console.ReadLine();

        Book book = new ComicBook(title, author, publisher, language, true);
        AddBook(book);
    }

    private void AddChildrenBook()
    {
        Console.Write("Enter title: ");
        string title = Console.ReadLine();
        Console.Write("Enter author: ");
        string author = Console.ReadLine();
        Console.Write("Enter age: ");
        int age = int.Parse(Console.ReadLine());
        Console.Write("Enter 'true' if it is Illustrated, 'false' otherwise: ");
        bool withImages = bool.Parse(Console.ReadLine());

        Book book = new ChildrenBook(title, author, age, withImages, true);
        AddBook(book);
    }

    private void AddBiographyBook()
    {
        Console.Write("Enter title: ");
        string title = Console.ReadLine();
        Console.Write("Enter author: ");
        string author = Console.ReadLine();
        Console.Write("Enter year published: ");
        int yearPublished = int.Parse(Console.ReadLine());
        Console.Write("Enter country: ");
        string country = Console.ReadLine();

        Book book = new BiographyBook(title, author, yearPublished, country, true);
        AddBook(book);
    }

    private void RemoveBookMenu()
    {
        Console.WriteLine("=== Remove Book ===");
        Console.Write("Enter the title of the book to remove: ");
        string title = Console.ReadLine();

        // Find the book by its title
        Book bookToRemove = null;
        foreach (var book in books)
        {
            if (book.DisplayDetails().Contains(title))
            {
                bookToRemove = book;
                break;
            }
        }

        if (bookToRemove != null)
        {
            RemoveBook(bookToRemove);
            Console.WriteLine($"Book '{title}' removed successfully.");
        }
        else
        {
            Console.WriteLine($"Book '{title}' not found.");
        }
    }

    private void SaveBooksToFile()
    {
        Console.Write("Enter file name for saving books: ");
        fileName = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(fileName))
        {
            foreach (Book book in books)
            {
                string[] parts = book.DisplayDetails().Split(':');
                string bookDetails = parts[1];
                writer.WriteLine($"{book.GetType().Name}${bookDetails}");
            }
        }
        Console.WriteLine("Books saved to file successfully!");
    }

    private void LoadBooksFromFile()
    {
        Console.Write("Enter file name for loading books: ");
        fileName = Console.ReadLine();

        if (!File.Exists(fileName))
        {
            Console.WriteLine("File not found.");
            return;
        }

        books.Clear();
        using (StreamReader reader = new StreamReader(fileName))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split('$');
                string[] bookDetails = parts[1].Split(',');
                string bookType = parts[0];

                if (bookType == nameof(FictionBook))
                {
                    string title = bookDetails[0];
                    string author = bookDetails[1];
                    string classification = bookDetails[2];
                    string type = bookDetails[3];
                    Book book = new FictionBook(title, author, classification, type, true);
                    books.Add(book);
                }
                else if (bookType == nameof(ComicBook))
                {
                    string title = bookDetails[0];
                    string author = bookDetails[1];
                    string publisher = bookDetails[2];
                    string language = bookDetails[3];
                    Book book = new ComicBook(title, author, publisher, language, true);
                    books.Add(book);
                }
                else if (bookType == nameof(ChildrenBook))
                {
                    string title = bookDetails[0];
                    string author = bookDetails[1];
                    int age = int.Parse(bookDetails[2]);
                    bool illustrated = bookDetails[3].Equals("Illustrated", StringComparison.OrdinalIgnoreCase);
                    Book book = new ChildrenBook(title, author, age, illustrated, true);
                    books.Add(book);
                }
                else if (bookType == nameof(BiographyBook))
                {
                    string title = bookDetails[0];
                    string author = bookDetails[1];
                    int yearPublished = int.Parse(bookDetails[2]);
                    string country = bookDetails[3];
                    Book book = new BiographyBook(title, author, yearPublished, country, true);
                    books.Add(book);
                }
                else
                {
                    Console.WriteLine("Unknown book type.");
                }
            }
        }
        Console.WriteLine("Books loaded from file successfully!");
    }
}
