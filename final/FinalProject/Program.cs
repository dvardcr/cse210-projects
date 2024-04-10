using System;

class MainProgram
{
    static void Main(string[] args)
    {
        // Instantiate managers
        BookManager bookManager = new BookManager();
        MemberManager memberManager = new MemberManager();
        LibraryManager libraryManager = new LibraryManager(bookManager, memberManager);

        // Main menu loop
        bool exitProgram = false;
        while (!exitProgram)
        {
            Console.WriteLine("=== Library Management System ===");
            Console.WriteLine("1. Book Manager");
            Console.WriteLine("2. Member Manager");
            Console.WriteLine("3. Library Manager");
            Console.WriteLine("4. Exit");

            // Get user input
            Console.Write("Select an option: ");
            string userInput = Console.ReadLine();

            // Process user input
            if (userInput == "1")
            {
                // Access Book Manager
                bookManager.Run();
            }
            else if (userInput == "2")
            {
                // Access Member Manager
                memberManager.Run();
            }
            else if (userInput == "3")
            {
                // Access Library Manager
                libraryManager.Run();
            }
            else if (userInput == "4")
            {
                // Exit the program
                exitProgram = true;
            }
            else
            {
                // Invalid input
                Console.WriteLine("Invalid option. Please select again.");
                Console.WriteLine("");
            }
        }
    }
}
