using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Huffman
{
    class HuffmanLogic
    {
        public List<Node> values { get; set; } = new List<Node>();

        public void getValues(string text) 
        {
            char currentChar;
            bool flag;

            //Console.WriteLine("Going through string");

            for(int i = 0; i < text.Length-1; i++) 
            {
                currentChar = text[i];
                flag = false;
                Console.WriteLine(values.Count);

                for(int j = 0; j<values.Count-1; j++) 
                { 

                    if(currentChar == values[j].nodeValue) 
                    {
                        flag = true;
                        values[j].nodeWeight++;
                    }

                }

                if (flag == false)
                {
                    Console.WriteLine("Adding new node");
                    Node newNode = new Node();
                    newNode.nodeWeight = 1;
                    newNode.nodeValue = currentChar;
                    values.Add(newNode);
                }
            }
        }

        public void Sort() 
        { 
            
        }

        public void print() 
        {
            for (int i = 0; i < values.Count - 1; i++)
            {
                Console.WriteLine("Node Value: " + values[i].nodeValue + " Node Weight: " + values[i].nodeWeight);
            }
        }
    }

}
