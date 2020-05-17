using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio
{
    class BubbleSort
    {
        public int[] unsortedList { get; set; }
        public int[] sortedList { get; set; }

        public void sort(int reccursion) 
        {
            reccursion--;
            int currentVal, nextVal, tempVal;
            if(reccursion >= 0) 
            {             
                for(int i = 0; i < unsortedList.Length-1; i++) 
                {
                    currentVal = unsortedList[i];
                    nextVal = unsortedList[i+1];
                
                    if(currentVal>nextVal) 
                    {
                        tempVal = nextVal;
                        unsortedList[i + 1] = currentVal;
                        unsortedList[i] = tempVal;
                    }
                }
                sort(reccursion);
            }

        }

        
    }
}
