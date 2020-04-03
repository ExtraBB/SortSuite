using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SortSuiteTool.Programs
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

        public static string ReadLineStringOption(string[] options)
        {
            string type;
            while (Array.IndexOf(options, (type = Console.ReadLine())) == -1)
            {
                Console.WriteLine("That's not a valid type");
            }
            return type;
        }

        public static T ReadLineEnum<T>(Func<T, string> getTextForOption) where T: struct, Enum
        {
            Console.WriteLine("Choose one of the following options:");

            T[] choices = Enum.GetValues(typeof(T)).Cast<T>().ToArray();
            for (int i = 0; i < choices.Length; i++)
            {
                Console.WriteLine($"[{i}]: {getTextForOption(choices[i])}");
            }

            T choice;
            while (!Enum.TryParse<T>(Console.ReadLine(), true, out choice) || !Enum.IsDefined(typeof(T), choice))
            {
                Console.WriteLine("That's not a valid choice, please enter your choice again.");
            }
            return choice;
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
