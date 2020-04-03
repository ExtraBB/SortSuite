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

        public static T[] Take<T>(T[] input, int from, int to)
        {
            T[] result = new T[to - from];
            for(int i = from; i < to; i++)
                result[i - from] = input[i];
            return result;
        }
    }
}
