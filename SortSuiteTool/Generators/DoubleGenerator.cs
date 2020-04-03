﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SortSuiteTool.Generators
{
    class DoubleGenerator : DataGenerator<double>
    {
        public override double GenerateEntry(double min, double max)
        {
            return this.random.NextDouble() * (max - min) + min;
        }
    }
}
