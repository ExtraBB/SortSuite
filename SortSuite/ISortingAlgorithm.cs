using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SortSuite
{
    public interface ISortingAlgorithm
    {
        public T[] Sort<T>(T[] input) where T : IComparable;
        public Task<T[]> SortParallel<T>(T[] input) where T : IComparable;
    }
}
