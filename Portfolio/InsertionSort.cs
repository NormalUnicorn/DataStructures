using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Portfolio
{
    class InsertionSort
    {
        //Never got round to finishing this sorry 

        public int[] unsortedValues { get; set; } = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        public int[] sortedValues { get; set; }

        public InsertionSort(int arrayLen) 
        {
            sortedValues = new int[arrayLen];
        }

        public void sort(int sortVal) 
        { 
            foreach(int currentVal in sortedValues) 
            { 
                if(sortVal < currentVal) 
                {
                    int tempVal = currentVal;
                    //int pos = Array.FindIndex(currentVal, w => currentVal);
                    //sortedValues.SetValue(currentVal, );
                }
            }
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
