using CommandLine;
using SortSuite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortSuiteTool.Programs.SortingPrograms
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

            [Option('p', "parallel", Required = false, HelpText = "Run sorting algorithm in parallel. Only possible for: [MergeSort]")]
            public bool parallel { get; set; }
        }

        public async Task Execute(string[] args)
        {
            await Parser.Default.ParseArguments<Options>(args).MapResult(async (Options opts) => {
                ISortingAlgorithm algorithm = GetSortingAlgorithm(opts.sortingAlgorithm);
                string[] linesIn = File.ReadAllLines(opts.inputFile);

                Stopwatch stopWatch = new Stopwatch();
                string[] linesOut;

                Console.WriteLine("Sorting...");

                double[] items = linesIn.Select(line => double.Parse(line)).ToArray();
                stopWatch.Start();
                if (opts.parallel)
                    await algorithm.SortParallel(items);
                else
                    algorithm.Sort(items);
                stopWatch.Stop();
                linesOut = items.Select(item => item.ToString()).ToArray();


                File.WriteAllLines(opts.outputFile, linesOut);

                ProgramUtils.WriteLineImpressive($"Succesfully sorted the values in {opts.inputFile} and wrote the result to {opts.outputFile} in {stopWatch.ElapsedMilliseconds} ms");
                return 1;
            }, (_) => Task.FromResult(0));
        }
    }
}
