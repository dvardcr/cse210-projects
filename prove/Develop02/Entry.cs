public class Entry

// Add the time attribute as part of the stretch exercise

{
    public string _date;
    public string _time;
    public string _promptText;
    public string _entryText;

    public void Display()
    {
        Console.WriteLine($"Date&Time: {_date} {_time} - Prompt: {_promptText}");
        Console.WriteLine($"{_entryText}");
    }
}