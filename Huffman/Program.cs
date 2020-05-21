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
            string inputString = "Something doesn't seem right with this code, and I'm unsure as to what it could be!";
            List<int> compressed = new List<int>();
            

            myHuffman.getValues(inputString);

            myHuffman.sort(0, myHuffman.values.Count);
            myHuffman.print();
            myHuffman.sort(1, myHuffman.values.Count);
            myHuffman.print();
            myTree.createTree(myHuffman.sortedVals.ToArray());

            for(int i = 0; i < inputString.Length-1; i++) 
            {
                Console.WriteLine("Compressing...");
                char currentChar = inputString[i];
                compressed.AddRange(myTree.depthFirstSearch(currentChar).ToArray());
            }
            Console.WriteLine(compressed);

        }
    }
}
