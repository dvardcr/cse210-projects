using System;

public class ChildrenBook : Book
{
    public int Age;
    public bool Illustrated;

    public ChildrenBook(string title, string author, int age, bool illustrated, bool isAvailable)
        : base(title, author, isAvailable)
    {
        Age = age;
        Illustrated = illustrated;
        IsAvailable = true;
    }

    public override string DisplayDetails()
    {
        return $"ChildrenBook:{Title},{Author},{Age},{(Illustrated ? "Illustrated" : "Not illustrated")},{IsAvailable}";
    }
}
