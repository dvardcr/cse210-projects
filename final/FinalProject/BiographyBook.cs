using System;

public class BiographyBook : Book
{
    // Additional attributes
    private string Name;
    private string Country;

    // Constructor
    public BiographyBook(string title, string author, string name, string country, bool isAvailable) : base(title, author)
    {
        Name = name;
        Country = country;
    }

    // Implementing abstract behavior
    public override string DisplayDetails()
    {
        // Return a string representation of the book details
        return $"BiographyBook:{Title},{Author},{Name},{Country},{IsAvailable}";
    }
}
