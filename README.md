# SortSuite
This package is written as a programming exercise for implementing sorting algorithms and publishing on NuGet.

## Supported sorting algorithms
-  Selection Sort (O(n^2))
-  Quicksort (O(n log n))
-  Mergesort (O(n log n)) (Can be run in parallel)

## Nuget Package
When using the nuget package, you can use the sorting algorithms as follows:

```c#
using SortSuite;

class Class1 {
    static void Main(string[] args) {
        int[] items = new int[]{3, 9, 2, 5, 6, 1, 2, 3, 0};
        ISortingAlgorithm sorter = new MergeSort();
        sorter.Sort(items); // items is now sorted;
    }
}
```

There is also a `SortParallel` function which runs `async` and is currently implemented for MergeSort.

## SortSuiteTool
You can use this Console tool to generate data, run benchmarks, sort files etc. It can also be used from the CLI, run `./SortSuiteTool --help` to see the options.