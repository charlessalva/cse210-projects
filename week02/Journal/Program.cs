using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        Console.WriteLine("\nThis is the Journal Program Menu:");

        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("\nWhat would you like to do next?");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display all entries");
            Console.WriteLine("3. Save journal to file");
            Console.WriteLine("4. Load journal from file");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            // Used switch, case, and break in my menu (STUDIED IN W3SCHOOLS.COM)
            switch (choice)
            {
                case "1":
                    string prompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine(prompt);
                    Console.Write("Your entry: ");
                    string entryText = Console.ReadLine();
                    Entry newEntry = new Entry(DateTime.Now.ToString("yyyy-MM-dd"), prompt, entryText);
                    journal.AddEntry(newEntry);
                    break;

                case "2":
                    journal.DisplayAllEntries();
                    break;

                case "3":
                    Console.Write("Enter file name to save: ");
                    string saveFile = Console.ReadLine();
                    journal.SaveToFile(saveFile);
                    break;

                case "4":
                    Console.Write("Enter file name to load: ");
                    string loadFile = Console.ReadLine();
                    journal.LoadFromFile(loadFile);
                    break;

                case "5":
                    exit = true;
                    Console.WriteLine("Exiting the program.");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}