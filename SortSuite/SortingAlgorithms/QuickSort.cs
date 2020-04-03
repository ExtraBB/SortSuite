using System;
using System.Collections.Generic;
using System.Text;

namespace SortSuite.SortingAlgorithms
{
    class QuickSort: ISortingAlgorithm
    {
        public T[] Sort<T>(T[] input) where T : IComparable
        {
            SortSection(input, 0, input.Length - 1);
            return input;
        }

        private void SortSection<T>(T[] input, int low, int high) where T : IComparable
        {
            if (low < high)
            {
                int p = Partition(input, low, high);
                SortSection(input, low, p - 1);
                SortSection(input, p + 1, high);
            }
        }

        private int Partition<T>(T[] input, int low, int high) where T : IComparable
        {
            T pivot = input[high];
            int i = low;

            for(int j = low; j < high; j++)
            {
                if(input[j].CompareTo(pivot) < 0)
                {
                    SortingUtils.Swap(input, i, j);
                    i++;
                }
            }
            SortingUtils.Swap(input, i, high);
            return i;
        }

        public T[] SortParallel<T>(T[] input) where T : IComparable
        {
            throw new NotImplementedException();
        }
    }
}
