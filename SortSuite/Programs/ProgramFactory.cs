using SortSuite.Programs.GenerationPrograms;
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
                default: throw new NotSupportedException();
            }
        }
    }
}
