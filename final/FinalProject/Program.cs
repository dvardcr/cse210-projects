using System;

class Program
{
    static void Main(string[] args)
    {
        // Initialize Library
        Library library = new Library();

        // Initialize LibraryManager
        LibraryManager manager = new LibraryManager();

        bool exitProgram = false;
        while (!exitProgram)
        {
            Console.Clear();

            // Display main menu options
            Console.WriteLine("=== Welcome to the Library System ===");
            Console.WriteLine("    1. Manage Books");
            Console.WriteLine("    2. Manage Borrowers");
            Console.WriteLine("    3. Exit");
            Console.Write("    What would you like to do? ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                // Manage books using Library
                library.ShowMenu();
            }
            else if (choice == "2")
            {
                // Manage borrowers using LibraryManager
                manager.ShowMenu();
            }
            else if (choice == "3")
            {
                exitProgram = true;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
        }
    }
}
