using SortSuite.Generators;
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace SortSuite.Programs.GenerationPrograms
{
    class GenerateIntegersProgram : IProgram
    {
        public void Execute() 
        {
            Console.WriteLine("How many entries do you want to generate?");
            int entries = ProgramUtils.ReadLineInt();
            Console.WriteLine("What's the minimum integer?");
            int min = ProgramUtils.ReadLineInt();
            Console.WriteLine("What's the maximum integer?");
            int max = ProgramUtils.ReadLineInt();
            Console.WriteLine("What's the output file name?");
            string filename = Console.ReadLine();

            IntegerGenerator generator = new IntegerGenerator();
            int[] data = generator.GenerateData(entries, min, max);
            string[] lines = Array.ConvertAll(data, i => i.ToString());
            File.WriteAllLines(filename, lines);


            ProgramUtils.WriteLineImpressive($"Succesfully wrote {entries} random integers in range [{min} - {max}] to {filename}!");
        }
    }
}
