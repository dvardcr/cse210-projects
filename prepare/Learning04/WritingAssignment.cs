using System;

public class WritingAssignment : Assignment
{
    private string _title = "";

    public WritingAssignment(string studentName, string topic, string title)
        : base(studentName, topic)
    {
        // Here we set any variables specific to the WritingAssignment class
        _title = title;
    }

    //public string GetTitle()
    //{
    //    return _title;
    //}
    
    //public void SetTitle(string title)
    //{
    //    _title = title;
    //}

    public string GetWritingInformation()
    {
        return $"{_title}";
    }
}