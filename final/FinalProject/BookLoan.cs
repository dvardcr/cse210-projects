using System;

public class BookLoan
{
    // Attributes
    private Book Book;
    private string Borrower;
    private DateTime BorrowDate;
    private DateTime ReturnDate;

    // Constructor
    public BookLoan(Book book, string borrower, DateTime borrowDate, DateTime returnDate)
    {
        Book = book;
        Borrower = borrower;
        BorrowDate = borrowDate;
        ReturnDate = returnDate;
    }

    // Display details of the book loan
    public void DisplayBookLoanDetails()
    {
        Console.WriteLine($"Book:");
        Console.WriteLine($"Borrower:");
        Console.WriteLine($"Borrow Date:");
        Console.WriteLine($"Return Date:");
    }
}