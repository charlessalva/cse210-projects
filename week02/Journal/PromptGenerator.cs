using System;

public class PromptGenerator
{
    public List<string> _prompts = new List<string>
    {
        "What made you smile today?",
        "Describe a challenge you overcame.",
        "What are you grateful for?",
        "What is a lesson you learned recently?",
        "What is your goal for tomorrow?",
        "How did you see God's hand in your life today?",
        "Who was someone interesting that you met today?",
        "What was the best food you've eaten today?",
        "What stood out in your scripture study?",
        "What is something you're looking forward to this week?",
        "Describe a moment when you felt at peace.",
        "What is something you would want to tell yourself five years from now?",
        "How do you feel today?"
    };

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }
}