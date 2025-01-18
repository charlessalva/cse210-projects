public class Entry
{
    public string _date;
    public string _promptText;
    public string _entryText;

    public Entry() { }

    public Entry(string date, string promptText, string entryText)
    {
        _date = date;
        _promptText = promptText;
        _entryText = entryText;
    }
    
    public void DisplayEntry()
    {
        Console.WriteLine($"{_date} -- {_promptText}");
        Console.WriteLine(_entryText);
    }
}