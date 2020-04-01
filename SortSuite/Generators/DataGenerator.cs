using System;
using System.Collections.Generic;
using System.Text;

namespace SortSuite
{
    abstract class DataGenerator<T>
    {
        protected Random random;

        public DataGenerator()
        {
            this.random = new Random();
        }

        public abstract T GenerateEntry(T min, T max);

        public T[] GenerateData(int amount, T min, T max)
        {
            T[] result = new T[amount];

            for(int i = 0; i < amount; i++)
            {
                result[i] = this.GenerateEntry(min, max);
            }

            return result;
        }
    }
}
