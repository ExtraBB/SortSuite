using System;
using System.Collections.Generic;
using System.Text;

namespace SortSuite.Programs
{
    static class ProgramUtils
    {
        public static int ReadLineInt()
        {
            int result;
            while(!int.TryParse(Console.ReadLine(), out result))
            {
                Console.WriteLine("That is not a valid integer, please try again.");
            }
            return result;
        }

        public static double ReadLineDouble()
        {
            double result;
            while (!double.TryParse(Console.ReadLine(), out result))
            {
                Console.WriteLine("That is not a valid double, please try again.");
            }
            return result;
        }

        public static void WriteLineImpressive(string line)
        {

            Console.WriteLine();
            Console.WriteLine(new String('-', line.Length + 4));
            Console.WriteLine($"| {line} |");
            Console.WriteLine(new String('-', line.Length + 4));
            Console.WriteLine();
        }
    }
}
