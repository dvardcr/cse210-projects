using System;

public class MathAssignment : Assignment
{
    private string _textbookSection = "";
    private string _problems = "";

    // public string GetTextbookSection()
    // {
    //     return _textbookSection;
    // }
    
    // public void SetTextbookSection(string textbookSection)
    // {
    //     _textbookSection = textbookSection;
    // }

    // public string GetProblems()
    // {
    //     return _problems;
    // }

    // public void SetProblems(string problems)
    // {
    //     _problems = problems;
    // }

    public MathAssignment(string studentName, string topic, string textbookSection, string problems) : base(studentName, topic)
    {
        _textbookSection = textbookSection;
        _problems = problems;
    }

    public string GetHomeworkList()
    {
        return $"Section {_textbookSection} Problems {_problems}";
    }

}