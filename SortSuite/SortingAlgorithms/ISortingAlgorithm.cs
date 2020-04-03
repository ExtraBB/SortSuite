using System;
using System.Collections.Generic;
using System.Text;

namespace SortSuite.SortingAlgorithms
{
    interface ISortingAlgorithm
    {
        public T[] Sort<T>(T[] input) where T : IComparable;
        public T[] SortParallel<T>(T[] input) where T : IComparable;
    }
}
