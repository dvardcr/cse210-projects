using System;

public class FictionBook : Book
{
    // Additional attributes
    private string Genre;
    private string Classification;

    // Constructor
    public FictionBook(string title, string author, string genre, string classification, bool isAvailable) : base(title, author)
    {
        Genre = genre;
        Classification = classification;
    }

    // Implementing abstract behavior
    public override string DisplayDetails()
    {
        // Return a string representation of the book details
        return $"FictionBook:{Title},{Author},{Genre},{Classification},{IsAvailable}";
    }
}