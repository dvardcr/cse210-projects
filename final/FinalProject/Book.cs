using System;

public abstract class Book
{
    // Attributes
    protected string Title;
    protected string Author;
    protected bool IsAvailable;

    // Constructor
    protected Book(string title, string author)
    {
        Title = title;
        Author = author;
        IsAvailable = true;
    }

    // Method to check if the book is available
    public bool CheckAvailability()
    {
        return IsAvailable;
    }

    // Abstract behavior
    public abstract string DisplayDetails();
}
