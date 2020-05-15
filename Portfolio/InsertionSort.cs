using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio
{
    class InsertionSort
    {
        public int[] unsortedValues { get; set; }
        public int[] sortedValues { get; set; }

        public int[] Sort()
        {
            for (int i = 0; i < unsortedValues.Length; i++)
            {
                int unsortedVal = unsortedValues[unsortedValues.Length - 1];
                for (int j = 0; j < sortedValues.Length; j++) 
                { 
                    if(unsortedVal < sortedValues[j]) 
                    {
                        return null;
                    }
                }

            }
            return null;
        }

    }
}
