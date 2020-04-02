using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SortSuite.SortingAlgorithms;

namespace SortSuite.Programs.SortingPrograms
{
    enum SortingType
    {
        SelectionSort,
        QuickSort,
        Exit
    }

    abstract class SortingProgram
    {
        protected ISortingAlgorithm GetSortingAlgorithm(SortingType type)
        {
            switch(type)
            {
                case SortingType.SelectionSort: return new SelectionSort();
                case SortingType.QuickSort: return new QuickSort();
                default: throw new NotSupportedException();
            }
        }

        protected SortingType GetSortingType()
        {
            SortingType choice;
            PrintSortingTypes();
            while (!Enum.TryParse(Console.ReadLine(), out choice) || !Enum.IsDefined(typeof(SortingType), choice))
            {
                Console.WriteLine("That's not a valid choice, please enter your choice again.");
            }
            return choice;
        }

        protected void PrintSortingTypes()
        {
            SortingType[] choices = Enum.GetValues(typeof(SortingType)).Cast<SortingType>().ToArray();

            for (int i = 0; i < choices.Length; i++)
            {
                Console.WriteLine($"[{i}]: {GetTextForSortingType(choices[i])}");
            }

        }

        protected string GetTextForSortingType(SortingType choice)
        {
            switch (choice)
            {
                case SortingType.SelectionSort: return "Selection Sort";
                case SortingType.QuickSort: return "Quicksort";
                case SortingType.Exit: return "Return to main menu";
                default: return "Unkown choice";
            }
        }
    }
}
