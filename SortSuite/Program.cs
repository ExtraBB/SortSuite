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
        BenchmarkSort,
        Exit
    }

    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length > 0)
            {
                ICLIProgram program = new CLIFileSortingProgram();
                program.Execute(args);
                return;
            }

            ProgramType choice;
            do
            {
                choice = ProgramUtils.ReadLineEnum<ProgramType>((option) => GetTextForProgramType(option));
                if(choice == ProgramType.Exit) break;
                CreateProgram(choice).Execute();
            }
            while (choice != ProgramType.Exit);
        }

        static string GetTextForProgramType(ProgramType choice)
        {
            switch(choice)
            {
                case ProgramType.GenerateIntegers: return "Generate a list of random integers";
                case ProgramType.GenerateDoubles: return "Generate a list of random doubles";
                case ProgramType.FileSort: return "Sort a file of numbers";
                case ProgramType.BenchmarkSort: return "Benchmark a sorting algorithm";
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
                case ProgramType.BenchmarkSort: return new BenchmarkSortingProgram();
                default: throw new NotSupportedException();
            }
        }
    }
}
