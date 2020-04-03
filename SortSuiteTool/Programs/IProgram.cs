using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SortSuiteTool.Programs
{
    interface IProgram
    {
        void Execute();
    }

    interface ICLIProgram
    {
        Task Execute(string[] args);
    }
}
