using System;

namespace Huffman
{
    class Program
    {

        static void Main(string[] args)
        {
            HuffmanLogic myHuffman = new HuffmanLogic();

            myHuffman.getValues("Sphinx of black quartz, judge my vow!");
            myHuffman.print();
            myHuffman.values.Sort(new Comparison<StatInfo>(x, y) => int.Compare(x.nodeWeight, y.nodeWeight)));

        }
    }
}
