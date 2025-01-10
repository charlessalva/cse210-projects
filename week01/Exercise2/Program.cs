using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise2 Project.");

        Console.Write("What is your grade? ");
        string grade = Console.ReadLine();
        int gradeNumber = int.Parse(grade);

        string gradeLetter = "";
        string gradeSign = "";

        if (gradeNumber % 10 >= 7)
            {
                gradeSign = "+";
            }
            else if (gradeNumber % 10 < 3)
            {
                gradeSign = "-";
            }
        if (gradeNumber >= 90)
        {
            gradeLetter = "A";
            if (gradeNumber % 10 >= 7)
            {
                gradeSign = "";
            }
        }
        else if (gradeNumber >= 80 && gradeNumber < 90)
        {
            gradeLetter = "B";
        }
        else if (gradeNumber >= 70 && gradeNumber < 80)
        {
            gradeLetter = "C";
        }
        else if (gradeNumber >= 60 && gradeNumber < 70)
        {
            gradeLetter = "D";
        }
        else
        {
            gradeLetter = "F";
            if (gradeLetter == "F")
            {
                gradeSign = "";
            }
        }

        Console.WriteLine($"Your grade is {gradeLetter}{gradeSign}");

        if (gradeNumber >= 70)
        {
            Console.WriteLine("You passed!");
        }
        else
        {
            Console.WriteLine("Better luck next time!");
        }

    }
}