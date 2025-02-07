using System;

class Program
{
    static void Main(string[] args)
    {
        bool exit = false;
        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("Menu Options");
            Console.WriteLine("Choose from 1-4:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");
            Console.Write("Select a choice from the menu: ");

            switch (Console.ReadLine())
            {
                case "1":
                    new BreathingActivity().Run();
                    break;
                case "2":
                    new ReflectingActivity().Run();
                    break;
                case "3":
                    new ListingActivity().Run();
                    break;
                case "4":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Please select from 1-4.");
                    Console.ReadKey();
                    break;
            }
        }
    }
}
