public class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    private List<string> _usedPrompts = new List<string>();
    private List<string> _usedQuestions = new List<string>();

    public ReflectingActivity() : base("Reflecting Activity",
        "This activity will help you reflect on times in your life when you have shown strength and resilience.", 0)
    {
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

        DisplayPrompt();
        DisplayQuestions(duration);

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

    public string GetRandomQuestion()
    {
        // EXCEEDING REQUIREMENTS : Ensured that the random prompts won't be repeated until going through all the list.
        if (_usedQuestions.Count == _questions.Count)
        {
            _usedQuestions.Clear(); // Reset the list once all questions are used
        }

        string question;
        do
        {
            question = _questions[new Random().Next(_questions.Count)];
        } while (_usedQuestions.Contains(question));

        _usedQuestions.Add(question);
        return question;
    }

    public void DisplayPrompt()
    {
        string prompt = GetRandomPrompt();
        Console.WriteLine($"\n{prompt}");
        Console.WriteLine("\nWhen you have something in mind, press Enter to continue...");
        Console.ReadLine();
    }

    public void DisplayQuestions(int duration)
    {
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(duration);

        while (DateTime.Now < endTime)
        {
            Console.WriteLine(GetRandomQuestion());
            ShowSpinner(5);
        }
    }
}
