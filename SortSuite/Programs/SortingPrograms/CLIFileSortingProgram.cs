using CommandLine;
using SortSuite.SortingAlgorithms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace SortSuite.Programs.SortingPrograms
{
    class CLIFileSortingProgram : SortingProgram, ICLIProgram
    {
        class Options
        {
            [Option('i', "input", Required = true, HelpText = "Input file")]
            public string inputFile { get; set; }

            [Option('o', "output", Required = true, HelpText = "Output file")]
            public string outputFile { get; set; }

            [Option('s', "sort", Required = true, HelpText = "Sorting algorithm [SelectionSort/QuickSort/MergeSort]")]
            public SortingType sortingAlgorithm { get; set; }
        }

        public void Execute(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args).WithParsed((Options opts) => {
                ISortingAlgorithm algorithm = GetSortingAlgorithm(opts.sortingAlgorithm);
                string[] linesIn = File.ReadAllLines(opts.inputFile);

                Stopwatch stopWatch = new Stopwatch();
                string[] linesOut;

                Console.WriteLine("Sorting...");

                double[] items = linesIn.Select(line => double.Parse(line)).ToArray();
                stopWatch.Start();
                algorithm.Sort(items);
                stopWatch.Stop();
                linesOut = items.Select(item => item.ToString()).ToArray();


                File.WriteAllLines(opts.outputFile, linesOut);

                ProgramUtils.WriteLineImpressive($"Succesfully sorted the values in {opts.inputFile} and wrote the result to {opts.outputFile} in {stopWatch.ElapsedMilliseconds} ms");
            });
        }
    }
}
