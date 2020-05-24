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
            string inputString = "aabcdabda";
            List<int> compressed = new List<int>();
            string tempOut = "";
            string output = "";
            

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



                compressed.AddRange((myTree.DFS(currentChar).ToArray()));

                //compressed.Add(3);
                Console.WriteLine(currentChar + " has been compressed");
                Console.WriteLine(myTree.DFS(currentChar).ToString());
            }
            
            for(int i = 0; i < compressed.Count; i++) 
            {
                output += compressed[i];
            }
            Console.WriteLine(output);

            //myTree.decompress(output);
        }
    }
}
