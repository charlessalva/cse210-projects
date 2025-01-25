using System;

public class Program
{
    static void Main(string[] args)
    {
        // Full verse text (make sure it's complete)
        string scriptureText = "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.";

        // Create the scripture reference (John 3:16)
        Reference reference = new Reference("John", 3, 16);
        Scripture scripture = new Scripture(reference, scriptureText);

        // Loop until the scripture is fully hidden
        while (!scripture.isFullyHidden())
        {
            // Display the scripture with hidden words
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            
            // Prompt the user to press Enter or type 'quit'
            Console.WriteLine("\nPress Enter to hide more words or type 'quit' to exit.");
            string input = Console.ReadLine().Trim(); // Trim any extra spaces

            // Check if the user typed 'quit' and exit if true
            if (input.ToLower() == "quit")
            {
                break;
            }

            // Hide random words
            scripture.HideRandomWords(3); // Hide 3 words each time
        }

        // Final display when all words are hidden
        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine("\nAll words are hidden! Press any key to exit.");
        Console.ReadKey();
    }
}
