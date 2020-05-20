using System;

namespace Huffman
{
    class Program
    {

        static void Main(string[] args)
        {
            HuffmanLogic myHuffman = new HuffmanLogic();

            myHuffman.getValues("Something doesn't seem right with this code, and I'm unsure as to what it could be!");

            myHuffman.firstSort();
            myHuffman.print();
            myHuffman.sorts();
            myHuffman.print();
            myHuffman.sorts();
            myHuffman.sorts();
            myHuffman.sorts();
            myHuffman.print();

        }
    }
}
