using System;
using System.Collections.Generic;
using System.Text;

namespace SortSuite.SortingAlgorithms
{
    static class SortingUtils
    {
        public static void Swap<T>(T[] input, int i, int j)
        {
            T temp = input[i];
            input[i] = input[j];
            input[j] = temp;
        }
    }
}
