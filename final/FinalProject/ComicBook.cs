using System;

public class ComicBook : Book
{
    public string Publisher;
    public string Language;

    public ComicBook(string title, string author, string publisher, string language, bool isAvailable)
        : base(title, author, isAvailable)
    {
        Publisher = publisher;
        Language = language;
        IsAvailable = true;
    }

    public override string DisplayDetails()
    {
        return $"ComicBook:{Title},{Author},{Publisher},{Language},{IsAvailable}";
    }
}
