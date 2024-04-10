using System;

public abstract class Book
{
    protected string Title;
    protected string Author;
    protected bool IsAvailable;
    protected DateTime ReturnDate;

    public Book(string title, string author, bool isAvailable)
    {
        Title = title;
        Author = author;
        IsAvailable = true;
    }

    public void SetAvailability(bool available)
    {
        IsAvailable = available;
    }

    public abstract string DisplayDetails();
}
