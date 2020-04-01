using SortSuite.Programs.GenerationPrograms;
using SortSuite.Programs.SortingPrograms;
using System;
using System.Collections.Generic;
using System.Text;

namespace SortSuite.Programs
{
    static class ProgramFactory
    {
        public static IProgram CreateProgram(Choice choice)
        {
            switch(choice)
            {
                case Choice.GenerateIntegers: return new GenerateIntegersProgram();
                case Choice.GenerateDoubles: return new GenerateDoublesProgram();
                case Choice.SelectionSort: return new SelectionSortProgram();
                default: throw new NotSupportedException();
            }
        }
    }
}
