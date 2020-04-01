using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;
using SortSuite.SortingAlgorithms;
using System.Linq;

namespace SortSuite.Programs.SortingPrograms
{
    class SelectionSortProgram : IProgram
    {
        public void Execute()
        {
            Console.WriteLine("What's the input file name?");
            string inputFilename = Console.ReadLine();
            string[] linesIn = File.ReadAllLines(inputFilename);
            int[] items = linesIn.Select(line => int.Parse(line)).ToArray();

            Console.WriteLine("What's the output file name?");
            string outputFilename = Console.ReadLine();

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            SelectionSort.SortIntegers(items);
            stopWatch.Stop();

            string[] linesOut = items.Select(item => item.ToString()).ToArray();
            File.WriteAllLines(outputFilename, linesOut);

            ProgramUtils.WriteLineImpressive($"Succesfully sorted the values in {inputFilename} and wrote the result to {outputFilename} in {stopWatch.ElapsedMilliseconds} ms");
        }
    }
}
