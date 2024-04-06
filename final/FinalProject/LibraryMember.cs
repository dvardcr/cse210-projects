using System;
using System.Collections.Generic;

public class LibraryMember
{
    // Attributes
    private string firstName;
    private string lastName;
    private string membershipId;
    private List<BookLoan> borrowedBooks;

    // Constructor
    public LibraryMember(string firstName, string lastName, string membershipId)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.membershipId = membershipId;
        borrowedBooks = new List<BookLoan>();
    }

    // Getter for FirstName
    public string GetFirstName()
    {
        return firstName;
    }

    // Getter for LastName
    public string GetLastName()
    {
        return lastName;
    }

    // Getter for MembershipId
    public string GetMembershipId()
    {
        return membershipId;
    }
}