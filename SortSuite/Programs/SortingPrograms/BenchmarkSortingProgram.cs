using SortSuite.Generators;
using SortSuite.SortingAlgorithms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace SortSuite.Programs.SortingPrograms
{
    class BenchmarkSortingProgram: SortingProgram, IProgram
    {
        public void Execute()
        {
            // Create sorting algorithm
            SortingType sortingType = GetSortingType();
            if (sortingType == SortingType.Exit) return;
            ISortingAlgorithm algorithm = GetSortingAlgorithm(sortingType);

            // Get parameters
            Console.WriteLine("How many runs?");
            int runs = ProgramUtils.ReadLineInt();
            Console.WriteLine("How many entries per run?");
            int amount = ProgramUtils.ReadLineInt();

            // Start runs 
            Stopwatch stopWatch = new Stopwatch();
            IntegerGenerator generator = new IntegerGenerator();
            Console.WriteLine("Sorting...");

            long[] results = new long[runs];
            for (int i = 0; i < runs; i++)
            {
                int[] items = generator.GenerateData(amount, -1_000_000, 1_000_000);
                stopWatch.Start();
                algorithm.Sort(items);
                stopWatch.Stop();
                results[i] = stopWatch.ElapsedMilliseconds;
                stopWatch.Reset();
                Console.Write($"\rProgress: {i+1}/{runs}");
            }

            ProgramUtils.WriteLineImpressive($"The average sorting time of {runs} runs is: {results.Average()} ms");
        }
    }
}
