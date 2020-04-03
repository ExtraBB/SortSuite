using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using SortSuite;
using System.Linq;

namespace SortSuiteTool.Programs.SortingPrograms
{
    class FileSortingProgram : SortingProgram, IProgram
    {
        public void Execute()
        {
            SortingType sortingType = GetSortingType();
            if(sortingType == SortingType.Exit) return;

            ISortingAlgorithm algorithm = GetSortingAlgorithm(sortingType);

            Console.WriteLine("What's the input file name?");
            string inputFilename = Console.ReadLine();
            string[] linesIn = File.ReadAllLines(inputFilename);

            Console.WriteLine("What's the output file name?");
            string outputFilename = Console.ReadLine();

            Stopwatch stopWatch = new Stopwatch();
            string[] linesOut;

            Console.WriteLine("Sorting...");

            double[] items = linesIn.Select(line => double.Parse(line)).ToArray();
            stopWatch.Start();
            algorithm.Sort(items);
            stopWatch.Stop();
            linesOut = items.Select(item => item.ToString()).ToArray();

            File.WriteAllLines(outputFilename, linesOut);

            ProgramUtils.WriteLineImpressive($"Succesfully sorted the values in {inputFilename} and wrote the result to {outputFilename} in {stopWatch.ElapsedMilliseconds} ms");
        }
    }
}
