using System;

public class BiographyBook : Book
{
    public int YearPublished;
    public string Country;

    public BiographyBook(string title, string author, int yearPublished, string country, bool isAvailable)
        : base(title, author, isAvailable)
    {
        YearPublished = yearPublished;
        Country = country;
        IsAvailable = true;
    }

    public override string DisplayDetails()
    {
        return $"BiographyBook:{Title},{Author},{YearPublished},{Country},{IsAvailable}";
    }
}