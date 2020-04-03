using System;
using System.Collections.Generic;
using System.Text;

namespace SortSuite.Programs
{
    interface IProgram
    {
        void Execute();
    }

    interface ICLIProgram
    {
        void Execute(string[] args);
    }
}
