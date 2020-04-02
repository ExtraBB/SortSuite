using SortSuite.Programs;
using SortSuite.Programs.GenerationPrograms;
using SortSuite.Programs.SortingPrograms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SortSuite
{
    enum ProgramType
    {
        GenerateIntegers,
        GenerateDoubles,
        FileSort,
        Exit
    }

    class Program
    {
        static void Main(string[] args)
        {
            ProgramType choice;
            do
            {
                Console.WriteLine("Choose one of the following options:");
                PrintProgramTypes();

                while (!Enum.TryParse(Console.ReadLine(), out choice) || !Enum.IsDefined(typeof(ProgramType), choice))
                {
                    Console.WriteLine("That's not a valid choice, please enter your choice again.");
                }

                if(choice == ProgramType.Exit)
                {
                    break;
                }

                IProgram program = CreateProgram(choice);
                program.Execute();
            }
            while (choice != ProgramType.Exit);
        }

        static void PrintProgramTypes()
        {
            ProgramType[] choices = Enum.GetValues(typeof(ProgramType)).Cast<ProgramType>().ToArray();

            for(int i = 0; i < choices.Length; i++)
            {
                Console.WriteLine($"[{i}]: {GetTextForProgramType(choices[i])}");
            }

        }

        static string GetTextForProgramType(ProgramType choice)
        {
            switch(choice)
            {
                case ProgramType.GenerateIntegers: return "Generate a list of random integers";
                case ProgramType.GenerateDoubles: return "Generate a list of random doubles";
                case ProgramType.FileSort: return "Sort a file of numbers";
                case ProgramType.Exit: return "Exit";
                default: return "Unkown choice";
            }
        }

        static IProgram CreateProgram(ProgramType choice)
        {
            switch (choice)
            {
                case ProgramType.GenerateIntegers: return new GenerateIntegersProgram();
                case ProgramType.GenerateDoubles: return new GenerateDoublesProgram();
                case ProgramType.FileSort: return new FileSortingProgram();
                default: throw new NotSupportedException();
            }
        }
    }
}
