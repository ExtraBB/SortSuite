using SortSuite.Programs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SortSuite
{
    enum Choice
    {
        GenerateIntegers,
        GenerateDoubles,
        SelectionSort,
        Exit
    }

    class Program
    {
        static void Main(string[] args)
        {
            Choice choice;
            do
            {
                Console.WriteLine("Choose one of the following options:");
                PrintChoices();

                while (!Enum.TryParse(Console.ReadLine(), out choice) || !Enum.IsDefined(typeof(Choice), choice))
                {
                    Console.WriteLine("That's not a valid choice, please enter your choice again.");
                }

                if(choice == Choice.Exit)
                {
                    break;
                }

                IProgram program = ProgramFactory.CreateProgram((Choice)choice);
                program.Execute();
            }
            while (choice != Choice.Exit);
        }

        static void PrintChoices()
        {
            Choice[] choices = Enum.GetValues(typeof(Choice)).Cast<Choice>().ToArray();

            for(int i = 0; i < choices.Length; i++)
            {
                Console.WriteLine($"[{i}]: {GetTextForChoice(choices[i])}");
            }

        }

        static string GetTextForChoice(Choice c)
        {
            switch(c)
            {
                case Choice.GenerateIntegers: return "Generate a list of random integers";
                case Choice.GenerateDoubles: return "Generate a list of random doubles";
                case Choice.SelectionSort: return "Selection Sort";
                case Choice.Exit: return "Exit";
                default: return "Unkown choice";
            }
        }
    }
}
