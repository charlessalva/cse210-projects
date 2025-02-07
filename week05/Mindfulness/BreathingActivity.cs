public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity", 
        "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.", 0)
    {
    }

    public void Run()
    {
        Console.Clear();
        DisplayStartingMessage();
        Console.Write("\nEnter duration (seconds): ");
        int duration = int.Parse(Console.ReadLine());

        SetDuration(duration);

        Console.Clear();
        Console.Write("\nPrepare to begin...");
        ShowSpinner(6);

        for (int i = 0; i < duration / 9; i++) // Each cycle takes ~9 seconds
        {
            Console.Write("\nBreathe in...\n");
            ShowCountDown(4);
            Console.Write("\nBreathe out...\n");
            ShowCountDown(5);
        }

        DisplayEndingMessage();
        Thread.Sleep(5000);

    }
}