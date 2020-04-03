using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SortSuite
{
    public class SelectionSort: ISortingAlgorithm
    {

        public T[] Sort<T>(T[] input) where T : IComparable
        {
            for (int i = 0; i < input.Length - 1; i++)
            {
                int jMin = i;
                for (int j = i + 1; j < input.Length; j++)
                {
                    if (input[j].CompareTo(input[jMin]) < 0)
                    {
                        jMin = j;
                    }
                }
                SortingUtils.Swap(input, i, jMin);
            }
            return input;
        }
        public Task<T[]> SortParallel<T>(T[] input) where T : IComparable
        {
            throw new NotImplementedException();
        }
    }
}
