using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio
{
    class BubbleSort
    {
        public int[] numbers { get; set; } = new int[10] {10,9,8,7,6,5,4,3,2,1}; //vals to be sorted

        public void sort(int reccursion) 
        {
            reccursion--;
            int currentVal, nextVal, tempVal; //Current array val, next array val to compare, and temp val for swapping vals
            if(reccursion >= 0) 
            {             
                for(int i = 0; i < numbers.Length-1; i++) 
                {
                    currentVal = numbers[i];
                    nextVal = numbers[i+1];
                
                    if(currentVal>nextVal) 
                    {
                        tempVal = nextVal;
                        numbers[i+1] = currentVal;
                        numbers[i] = tempVal;
                    }
                }
                Console.WriteLine("Sorting...");
                print();
                sort(reccursion);
            }
        }

        public void print() 
        { 
            foreach(int i in numbers) 
            {
                Console.WriteLine(i); //https://docs.microsoft.com/en-us/dotnet/api/system.array?redirectedfrom=MSDN&view=netcore-3.1
            }
        }       
    }
}
