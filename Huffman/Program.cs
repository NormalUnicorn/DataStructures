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
            string inputString = "This is difficult to read due to the fact that it's vertical text, and we are used to reading left to right, horizontally"; //text to be compressed
            string compressed = ""; //final compressed text
            Stack<int> tempOut = new Stack<int>(); //this is needed because ms return stacks in reverse chronological order
            string tempOutString; //this is needed because ms return stacks in reverse chronological order, I could have used my own stack implementation but too bad!
            

            myHuffman.getValues(inputString); //create nodes of the chars from input string 

            //printing out the nodes
            for (int i = 0; i < myHuffman.values.Count; i++) 
            {
                Console.WriteLine("Node: \nNode value: " + myHuffman.values[i].nodeValue + "\nNode weight: " + myHuffman.values[i].nodeWeight);
            }
            
            //creating tree
            myTree.createTree(myHuffman.sort(myHuffman.values));


            //myTree.createTree(myHuffman.sortedVals.ToArray());

            //for each letter in the string
            for (int i = 0; i < inputString.Length; i++)
            {
                //Console.WriteLine("Compressing...");

                char currentChar = inputString[i];
                tempOutString = ""; //clear the string, so that we just get the path for the specific value

                tempOut = myTree.DFS(currentChar); //searching the tree

                //The stack is output in reverse order, so I have to reverse it again, by poping from it and then reversing the string
                while(tempOut.Count != 0) 
                {
                    tempOutString += tempOut.Pop().ToString();
                }

                tempOutString = reverseString(tempOutString);

                compressed+=tempOutString;

                //used for bodged decompressing :)
                compressed += "3";
                Console.WriteLine(currentChar + " has been compressed to: " + tempOutString);
            }
            
            //output the compressed string
            Console.WriteLine(compressed);

            myTree.decompress(compressed);
        }

        //
        public static string reverseString(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
