using System;

public class ChildrenBook : Book
{
    // Additional attributes
    private string Activities;
    private int Age;

    // Constructor
    public ChildrenBook(string title, string author, string activities, int age, bool isAvailable) : base(title, author)
    {
        Activities = activities;
        Age = age;
    }

    // Implementing abstract behavior
    public override string DisplayDetails()
    {
        // Return a string representation of the book details
        return $"ChildrenBook:{Title},{Author},{Activities},{Age},{IsAvailable}";
    }
}
