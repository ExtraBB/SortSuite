using System;
using System.Collections.Generic;
using System.Text;

namespace SortSuiteTool.Generators
{
    class IntegerGenerator : DataGenerator<int>
    {
        public override int GenerateEntry(int min, int max)
        {
            return this.random.Next(min, max);
        }
    }
}
