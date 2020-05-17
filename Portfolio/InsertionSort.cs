using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio
{
    class InsertionSort
    {
        public int[] unsortedValues { get; set; } = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        public int[] sortedValues { get; set; }



        public InsertionSort(int arrayLen) 
        {
            sortedValues = new int[arrayLen];
        }
        public void print(Array numbers)
        {
            foreach (int i in numbers)
            {
                Console.WriteLine(i); //https://docs.microsoft.com/en-us/dotnet/api/system.array?redirectedfrom=MSDN&view=netcore-3.1
            }
        }
    }
}
