using System;

public class FictionBook : Book
{
    public string Classification;
    public string Type;

    public FictionBook(string title, string author, string classification, string type, bool isAvailable)
        : base(title, author, isAvailable)
    {
        Classification = classification;
        Type = type;
        IsAvailable = true;
    }

    public override string DisplayDetails()
    {
        return $"FictionBook:{Title},{Author},{Classification},{Type},{IsAvailable}";
    }
}