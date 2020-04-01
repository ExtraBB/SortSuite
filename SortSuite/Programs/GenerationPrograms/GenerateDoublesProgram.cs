using SortSuite.Generators;
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace SortSuite.Programs.GenerationPrograms
{
    class GenerateDoublesProgram : IProgram
    {
        public void Execute()
        {
            Console.WriteLine("How many entries do you want to generate?");
            int entries = ProgramUtils.ReadLineInt();
            Console.WriteLine("What's the minimum double?");
            double min = ProgramUtils.ReadLineDouble();
            Console.WriteLine("What's the maximum double?");
            double max = ProgramUtils.ReadLineDouble();
            Console.WriteLine("What's the output file name?");
            string filename = Console.ReadLine();

            DoubleGenerator generator = new DoubleGenerator();
            double[] data = generator.GenerateData(entries, min, max);
            string[] lines = Array.ConvertAll(data, i => i.ToString());
            File.WriteAllLines(filename, lines);

            ProgramUtils.WriteLineImpressive($"Succesfully wrote {entries} random integers in range [{min} - {max}] to {filename}!");
        }
    }
}
