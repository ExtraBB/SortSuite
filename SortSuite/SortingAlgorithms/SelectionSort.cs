using System;
using System.Collections.Generic;
using System.Text;

namespace SortSuite.SortingAlgorithms
{
    static class SelectionSort
    {
        public static void SortIntegers(int[] input)
        {
            for(int i = 0; i < input.Length - 1; i++)
            {
                int jMin = i;
                for(int j = i+1; j < input.Length; j++)
                {
                    if(input[j] < input[jMin])
                    {
                        jMin = j;
                    }
                }
                SortingUtils.Swap(input, i, jMin);
            }
        }
    }
}
