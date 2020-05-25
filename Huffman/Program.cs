﻿using System;
using System.IO;
using System.Collections.Generic;

namespace Huffman
{
    class Program
    {

        static void Main(string[] args)
        {
            //I tested my program agaist https://people.ok.ubc.ca/ylucet/DS/Huffman.html, when it comes to tree traversal, my tree traversal is flipped, if my tree says go right, go left on the tree generated here

            HuffmanLogic myHuffman = new HuffmanLogic();
            Tree myTree = new Tree();

            //I read text from a file, so I need a try catch incase the user inputs a file path that doesn't exist
            try 
            { 
                //https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/file-system/how-to-read-from-a-text-file
                string inputTextFile = System.IO.File.ReadAllText(@"E:\Documents\Github\Uni\DataStructures\Huffman\Text files\inputTextFile.txt"); //Update the path to read text from a text file

                string compressed = ""; //final compressed text

                Stack<int> tempOut = new Stack<int>(); //this is needed because ms return stacks in reverse chronological order
                string tempOutString; //this is needed because ms return stacks in reverse chronological order, I could have used my own stack implementation but too bad!
            
                myHuffman.getValues(inputTextFile); //create nodes of the chars from input string, change the paramater to inputString or inputTextFile

                //printing out the nodes
                //for (int i = 0; i < myHuffman.values.Count; i++) 
                //{
                //    Console.WriteLine("Node: \nNode value: " + myHuffman.values[i].nodeValue + "\nNode weight: " + myHuffman.values[i].nodeWeight);
                //}
            
                //creating tree
                myTree.createTree(myHuffman.sort(myHuffman.values));


                //myTree.createTree(myHuffman.sortedVals.ToArray());

                //for each letter in the string
                for (int i = 0; i < inputTextFile.Length; i++)
                {
                    //Console.WriteLine("Compressing...");

                    char currentChar = inputTextFile[i];
                    tempOutString = ""; //clear the string, so that we just get the path for the specific value

                    tempOut = myTree.DFS(currentChar); //searching the tree

                    //The stack is output in reverse order, so I have to reverse it again, by poping from it and then reversing the string
                    while(tempOut.Count != 0) 
                    {
                        tempOutString += tempOut.Pop().ToString();
                    }

                    tempOutString = reverseString(tempOutString);

                    compressed+=tempOutString;

                    Console.WriteLine("The optimal huffman code for " + currentChar + " is: " + tempOutString); 
                }
            
                //output the compressed string
                Console.WriteLine(compressed);

                //https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/file-system/how-to-write-to-a-text-file
                System.IO.File.WriteAllText(@"E:\Documents\Github\Uni\DataStructures\Huffman\Text files\outputCompressedText.txt", compressed);

                //decompress string to check correct output
                myTree.decompress(compressed);
            }
            catch(FileNotFoundException ex) 
            {
                Console.WriteLine("Sorry, that file doesn't exist!");
            }
        }

        //https://stackoverflow.com/questions/228038/best-way-to-reverse-a-string
        public static string reverseString(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
