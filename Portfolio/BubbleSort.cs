using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio
{
    class BubbleSort
    {
        public int[] numbers { get; set; } = new int[10] {10,9,8,7,6,5,4,3,2,1 };

        public void sort(int reccursion) 
        {
            reccursion--;
            int currentVal, nextVal, tempVal;
            if(reccursion >= 0) 
            {             
                for(int i = 0; i < numbers.Length-1; i++) 
                {
                    currentVal = numbers[i];
                    nextVal = numbers[i+1];
                
                    if(currentVal>nextVal) 
                    {
                        tempVal = nextVal;
                        numbers[i + 1] = currentVal;
                        numbers[i] = tempVal;
                    }
                }
                sort(reccursion);
            }
        }

        public BubbleSort() 
        {
            int[] numbers = new int[10] { 15, 7, 1, 33, 18, 4, 9, 101, 21 , 12 };
        }
        
    }
}
