using System;
using System.Collections.Generic;

class LibraryManager
{
    private Dictionary<string, List<string>> borrowedBooks = new Dictionary<string, List<string>>();
    private Dictionary<string, DateTime> returnDates = new Dictionary<string, DateTime>();
    private BookManager bookManager;
    private MemberManager memberManager;

    public LibraryManager(BookManager bookManager, MemberManager memberManager)
    {
        this.bookManager = bookManager;
        this.memberManager = memberManager;
    }

    public void Run()
    {
        bool exitLibraryManager = false;
        while (!exitLibraryManager)
        {
            Console.WriteLine("\n=== Library Manager ===");
            Console.WriteLine("1. Select Member");
            Console.WriteLine("2. Add Book to Member");
            Console.WriteLine("3. Select Return Date");
            Console.WriteLine("4. Display Borrowed Books");
            Console.WriteLine("5. Return Book");
            Console.WriteLine("6. Return to Main Menu");

            Console.Write("Select an option: ");
            string userInput = Console.ReadLine();

            if (userInput == "1")
            {
                SelectMember();
            }
            else if (userInput == "2")
            {
                AddBookToMember();
            }
            else if (userInput == "3")
            {
                SelectReturnDate();
            }
            else if (userInput == "4")
            {
                DisplayBorrowedBooks();
            }
            else if (userInput == "5")
            {
                ReturnBook();
            }
            else if (userInput == "6")
            {
                Console.Clear();
                exitLibraryManager = true;
            }
            else
            {
                Console.WriteLine("Invalid option. Please select again.");
            }
        }
    }

    private void SelectMember()
    {
        Console.WriteLine("\n=== Select Member ===");
        memberManager.DisplayMembers();

        Console.Write("Enter the index of the member: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index >= 0 && index < memberManager.Members.Count)
        {
            string selectedMember = memberManager.Members[index];
            if (!borrowedBooks.ContainsKey(selectedMember))
            {
                borrowedBooks[selectedMember] = new List<string>();
            }
            Console.WriteLine($"Member '{selectedMember}' selected.");
        }
        else
        {
            Console.WriteLine("Invalid index. Please try again.");
        }
    }

    private void AddBookToMember()
    {
        Console.WriteLine("\n=== Add Book to Member ===");
        if (borrowedBooks.Count == 0)
        {
            Console.WriteLine("No member selected. Please select a member first.");
            return;
        }
        bookManager.DisplayBooks();
        Console.Write("Enter the index of the book to borrow: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index >= 0 && index < bookManager.Books.Count)
        {
            string bookDetails = bookManager.Books[index].DisplayDetails();
            string[] detailsArray = bookDetails.Split(',');
            string availabilityInfo = detailsArray[detailsArray.Length - 1];
            string[] parts = availabilityInfo.Split(':');
            string status = parts[parts.Length - 1].Trim();
            bool isAvailable = status.Equals("True", StringComparison.OrdinalIgnoreCase);

            if (!isAvailable)
            {
                Console.WriteLine("This book is not available for borrowing.");
                return;
            }

            Book selectedBook = bookManager.Books[index];
            string selectedMember = borrowedBooks.Keys.Last();
            borrowedBooks[selectedMember].Add(bookDetails);
            selectedBook.SetAvailability(false);
            string selectedBookTitle = detailsArray[0].Split(':')[1].Trim();
            Console.WriteLine($"Book '{selectedBookTitle}' added to member '{selectedMember}'.");
        }
        else
        {
            Console.WriteLine("Invalid index. Please try again.");
        }
    }

    private void SelectReturnDate()
    {
        Console.WriteLine("\n=== Select Return Date ===");
        if (borrowedBooks.Count == 0)
        {
            Console.WriteLine("No member selected. Please select a member first.");
            return;
        }

        bool isValidDate = false;
        while (!isValidDate)
        {
            Console.Write("Enter the return date (YYYY-MM-DD): ");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime returnDate))
            {
                // Calculate the difference in days
                TimeSpan difference = returnDate.Date - DateTime.Today;
                int daysDifference = difference.Days;

                // Check if the return date is within 7 days from now
                if (daysDifference <= 7)
                {
                    string selectedMember = borrowedBooks.Keys.Last();
                    returnDates[selectedMember] = returnDate;
                    Console.WriteLine($"Return date set to {returnDate.ToShortDateString()} for member '{selectedMember}'.");
                    isValidDate = true;
                }
                else
                {
                    Console.WriteLine("Return date exceeds 7 days from today. Please select a date within 7 days.");
                }
            }
            else
            {
                Console.WriteLine("Invalid date format. Please try again.");
            }
        }
    }

    private void DisplayBorrowedBooks()
    {
        Console.WriteLine("\n=== Borrowed Books ===");
        foreach (var member in borrowedBooks)
        {
            Console.WriteLine($"Member: {member.Key}");
            Console.WriteLine("Books Borrowed:");
            foreach (var bookDetails in member.Value)
            {
                string[] detailsArray = bookDetails.Split(',');
                string title = detailsArray[0].Split(':')[1]; // Extracting the title
                Console.WriteLine($"- {title}");
            }
            if (returnDates.ContainsKey(member.Key))
            {
                Console.WriteLine($"Return Date: {returnDates[member.Key].ToShortDateString()}");
            }
            Console.WriteLine();
        }
    }


    private void ReturnBook()
    {
        Console.WriteLine("\n=== Return Book ===");
        if (borrowedBooks.Count == 0)
        {
            Console.WriteLine("No member selected. Please select a member first.");
            return;
        }
        string selectedMember = borrowedBooks.Keys.Last();
        if (borrowedBooks[selectedMember].Count == 0)
        {
            Console.WriteLine("No books borrowed by this member.");
            return;
        }
        Console.WriteLine("Books Borrowed by Selected Member:");
        for (int i = 0; i < borrowedBooks[selectedMember].Count; i++)
        {
            Console.WriteLine($"{i}. {borrowedBooks[selectedMember][i]}");
        }
        Console.Write("Enter the index of the book to return: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index >= 0 && index < borrowedBooks[selectedMember].Count)
        {
            string returnedBookDetails = borrowedBooks[selectedMember][index];
            string[] detailsArray = returnedBookDetails.Split(',');
            string returnedBookTitle = detailsArray[0].Split(':')[1].Trim(); // Extract and trim the title from the details string
            
            // Mark the book as available
            foreach (Book book in bookManager.Books)
            {
                string[] bookDetailsArray = book.DisplayDetails().Split(',');
                 // Extract and trim the title from the book details string
                string bookTitle = bookDetailsArray[0].Split(':')[1].Trim();
                
                if (bookTitle == returnedBookTitle)
                {
                    book.SetAvailability(true);
                    break; // Exit the loop once the book is found and updated
                }
            }
            
            borrowedBooks[selectedMember].RemoveAt(index);
            Console.WriteLine($"Book '{returnedBookTitle}' returned successfully.");

            // Check if the member has no more borrowed books
            if (borrowedBooks[selectedMember].Count == 0)
            {
                borrowedBooks.Remove(selectedMember);
                returnDates.Remove(selectedMember);
                Console.WriteLine($"No more books borrowed by member '{selectedMember}'.");
            }
        }
        else
        {
            Console.WriteLine("Invalid index. Please try again.");
        }
    }

}
