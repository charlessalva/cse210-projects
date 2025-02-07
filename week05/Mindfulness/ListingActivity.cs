public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts;
    private List<string> _usedPrompts;

    public ListingActivity() : base("Listing Activity",
        "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.", 0)
    {
        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        _usedPrompts = new List<string>();
        _count = 0;
    }

    public void Run()
    {
        Console.Clear();
        DisplayStartingMessage();
        Console.Write("\nEnter duration (seconds): ");
        int duration = int.Parse(Console.ReadLine());

        // Set the duration in the parent class
        SetDuration(duration);

        Console.Clear();
        Console.WriteLine("\nPrepare to begin...");
        ShowSpinner(5);

        Console.WriteLine($"\n{GetRandomPrompt()}");
        ShowCountDown(5);

        List<string> items = GetListFromUser(duration);

        Console.WriteLine($"\nYou listed {_count} items!");
        DisplayEndingMessage();
        Thread.Sleep(5000);
    }

    public string GetRandomPrompt()
    {
        // EXCEEDING REQUIREMENTS : Ensured that the random prompts won't be repeated until going through all the list.
        if (_usedPrompts.Count == _prompts.Count)
        {
            _usedPrompts.Clear(); // Reset the list once all prompts are used
        }

        string prompt;
        do
        {
            prompt = _prompts[new Random().Next(_prompts.Count)];
        } while (_usedPrompts.Contains(prompt));

        _usedPrompts.Add(prompt);
        return prompt;
    }

    public List<string> GetListFromUser(int duration)
    {
        List<string> items = new List<string>();
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("Enter an item: ");
            string item = Console.ReadLine();
            items.Add(item);
            _count++;
        }

        return items;
    }
}
