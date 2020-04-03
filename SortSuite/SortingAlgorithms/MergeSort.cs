using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SortSuite.SortingAlgorithms
{
    class MergeSort : ISortingAlgorithm
    {
        public T[] Sort<T>(T[] input) where T : IComparable
        {
            if (input.Length <= 1) return input;

            int middle = input.Length / 2;

            T[] inputA = SortingUtils.Take(input, 0, middle);
            T[] inputB = SortingUtils.Take(input, middle, input.Length);

            Sort(inputA);
            Sort(inputB);

            int iA = 0, iB = 0;
            for(int i = 0; i < input.Length; i++)
            {
                if(iA == inputA.Length)
                {
                    input[i] = inputB[iB];
                    iB++;
                } 
                else if (iB == inputB.Length)
                {
                    input[i] = inputA[iA];
                    iA++;
                }
                else if (inputA[iA].CompareTo(inputB[iB]) < 0)
                {
                    input[i] = inputA[iA];
                    iA++;
                } else
                {
                    input[i] = inputB[iB];
                    iB++;
                }
            }
            return input;
        }
        public T[] SortParallel<T>(T[] input) where T : IComparable
        {
            if (input.Length <= 1) return input;

            int middle = input.Length / 2;

            T[] inputA = SortingUtils.Take(input, 0, middle);
            T[] inputB = SortingUtils.Take(input, middle, input.Length);

            Parallel.Invoke(
                () => Sort(inputA),
                () => Sort(inputB)
            );

            int iA = 0, iB = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (iA == inputA.Length)
                {
                    input[i] = inputB[iB];
                    iB++;
                }
                else if (iB == inputB.Length)
                {
                    input[i] = inputA[iA];
                    iA++;
                }
                else if (inputA[iA].CompareTo(inputB[iB]) < 0)
                {
                    input[i] = inputA[iA];
                    iA++;
                }
                else
                {
                    input[i] = inputB[iB];
                    iB++;
                }
            }
            return input;
        }
    }
}
