using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        bool running = true;

        while (running)
        {
            Console.WriteLine("1. Create Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Show Player Info");
            Console.WriteLine("5. Save Goals");
            Console.WriteLine("6. Load Goals");
            Console.WriteLine("7. Exit");
            Console.Write("Choose an option: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    manager.CreateGoal();
                    break;
                case 2:
                    manager.ListGoals();
                    break;
                case 3:
                    manager.RecordEvent();
                    break;
                case 4:
                    manager.DisplayPlayerInfo();
                    break;
                case 5:
                    Console.Write("Enter filename to save: ");
                    manager.SaveGoals(Console.ReadLine());
                    break;
                case 6:
                    Console.Write("Enter filename to load: ");
                    manager.LoadGoals(Console.ReadLine());
                    break;
                case 7:
                    running = false;
                    break;
            }
            Console.WriteLine();
        }
    }
}
