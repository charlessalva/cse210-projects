using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

// ADDED THE RANK TO THE DISPLAY OF PLAYER INFO
    public void DisplayPlayerInfo()
    {
        string rank = GetPlayerRank();
        Console.WriteLine($"Current Score: {_score} ({rank})");
    }

// EXCEEDING REQUIREMENTS ADDED 20 RANK LEVELS THAT WILL CORRESPOND TO A CERTAIN SCORE THRESHOLD 
// (Asked AI to generate the ranks and the thresholds)
    private string GetPlayerRank()
    {
        (int threshold, string title)[] ranks = new (int, string)[]
        {
            (0, "Seeker"), (100, "Initiate"), (250, "Novice"), (500, "Apprentice"),
            (1000, "Adept"), (1500, "Wayfarer"), (2500, "Challenger"), (4000, "Warrior"),
            (6000, "Guardian"), (9000, "Champion"), (12000, "Hero"), (16000, "Master"),
            (21000, "Sage"), (27000, "Paragon"), (34000, "Legend"), (42000, "Mythic"),
            (51000, "Ascendant"), (61000, "Eternal"), (72000, "Celestial"), (85000, "Transcendent")
        };

        for (int i = ranks.Length - 1; i >= 0; i--)
        {
            if (_score >= ranks[i].threshold)
            {
                return ranks[i].title;
            }
        }
        return "Seeker";
    }

    public void CreateGoal()
    {
        Console.WriteLine("Select goal type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        int choice = int.Parse(Console.ReadLine());

        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter description: ");
        string description = Console.ReadLine();
        Console.Write("Enter points for completion: ");
        int points = int.Parse(Console.ReadLine());

        if (choice == 1)
        {
            _goals.Add(new SimpleGoal(name, description, points));
        }
        else if (choice == 2)
        {
            _goals.Add(new EternalGoal(name, description, points));
        }
        else if (choice == 3)
        {
            Console.Write("Enter target count: ");
            int target = int.Parse(Console.ReadLine());
            Console.Write("Enter bonus points: ");
            int bonus = int.Parse(Console.ReadLine());
            _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
        }
    }

    public void ListGoals()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals available.");
            return;
        }

        Console.WriteLine("Your Goals:");
        foreach (var goal in _goals)
        {
            Console.WriteLine(goal.GetDetailsString() + $" - {goal.GetDescription()}");
        }
    }

    public void RecordEvent()
    {
        Console.WriteLine("Select a goal to record:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
        int choice = int.Parse(Console.ReadLine()) - 1;

        if (choice >= 0 && choice < _goals.Count)
        {
            _goals[choice].RecordEvent();
            _score += _goals[choice].GetPoints();
            Console.WriteLine("Goal recorded!");
        }
    }

    public void SaveGoals(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine("Goals saved successfully!");
    }

    public void LoadGoals(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        _goals.Clear();
        using (StreamReader reader = new StreamReader(filename))
        {
            _score = int.Parse(reader.ReadLine());
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split('|');
                string type = parts[0];

                if (type == "SimpleGoal")
                {
                    SimpleGoal goal = new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]));
                    goal.SetCompletion(bool.Parse(parts[4])); 
                    _goals.Add(goal);
                }
                else if (type == "EternalGoal")
                {
                    _goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));
                }
                else if (type == "ChecklistGoal")
                {
                    ChecklistGoal goal = new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5]));
                    goal.SetAmountCompleted(int.Parse(parts[6])); 
                    _goals.Add(goal);
                }
            }
        }
        Console.WriteLine("Goals loaded successfully!");
    }
}
