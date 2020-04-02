using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using SortSuite.SortingAlgorithms;
using System.Linq;

namespace SortSuite.Programs.SortingPrograms
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

            Console.WriteLine("What's the type of the entries? [int/double]");
            string inputType = ProgramUtils.ReadLineType();

            Stopwatch stopWatch = new Stopwatch();
            string[] linesOut;

            if (inputType == "int") {
                int[] items = linesIn.Select(line => int.Parse(line)).ToArray();
                stopWatch.Start();
                algorithm.Sort(items);
                stopWatch.Stop();
                linesOut = items.Select(item => item.ToString()).ToArray();
            } 
            else if (inputType == "double")
            {
                double[] items = linesIn.Select(line => double.Parse(line)).ToArray();
                stopWatch.Start();
                algorithm.Sort(items);
                stopWatch.Stop();
                linesOut = items.Select(item => item.ToString()).ToArray();
            }
            else
            {
                throw new NotSupportedException();
            }

            File.WriteAllLines(outputFilename, linesOut);

            ProgramUtils.WriteLineImpressive($"Succesfully sorted the values in {inputFilename} and wrote the result to {outputFilename} in {stopWatch.ElapsedMilliseconds} ms");
        }
    }
}
