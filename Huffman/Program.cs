using System;
using System.Collections.Generic;

namespace Huffman
{
    class Program
    {

        static void Main(string[] args)
        {
            HuffmanLogic myHuffman = new HuffmanLogic();
            Tree myTree = new Tree();
            string inputString = "This is difficult to read due to the fact that it's vertical text, and we are used to reading left to right, horizontally";
            string compressed = "";
            Stack<int> tempOut = new Stack<int>();
            string tempOutString;
            

            myHuffman.getValues(inputString);

            for (int i = 0; i < myHuffman.values.Count; i++) 
            {
                Console.WriteLine("Node: \nNode value: " + myHuffman.values[i].nodeValue + "\nNode weight: " + myHuffman.values[i].nodeWeight);
            }
            
            myTree.createTree(myHuffman.sort(myHuffman.values));


            //myTree.createTree(myHuffman.sortedVals.ToArray());

            for (int i = 0; i < inputString.Length; i++)
            {
                //Console.WriteLine("Compressing...");
                char currentChar = inputString[i];
                tempOutString = "";

                tempOut = myTree.DFS(currentChar);

                while(tempOut.Count != 0) 
                {
                    tempOutString += tempOut.Pop().ToString();
                }

                tempOutString = reverseString(tempOutString);

                compressed+=tempOutString;

                compressed += "3";
                Console.WriteLine(currentChar + " has been compressed to: " + tempOutString);
            }
            
            Console.WriteLine(compressed);

            myTree.decompress(compressed);
        }

        public static string reverseString(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
