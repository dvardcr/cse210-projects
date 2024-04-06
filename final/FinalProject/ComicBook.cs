using System;

public class ComicBook : Book
{
    // Additional attributes
    private string Publisher;
    private string Language;

    // Constructor
    public ComicBook(string title, string author, string publisher, string language, bool isAvailable) : base(title, author)
    {
        Publisher = publisher;
        Language = language;
    }

    // Implementing abstract behavior
    public override string DisplayDetails()
    {
        // Return a string representation of the book details
        return $"ComicBook:{Title},{Author},{Publisher},{Language},{IsAvailable}";
    }
}
