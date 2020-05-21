using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Huffman
{
    class HuffmanLogic
    {
        public List<Node> values { get; set; } = new List<Node>();

        public List<Node> sortedVals;

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
        
        public void sort(int type, int counter) 
        {
            if(type == 0) 
            { 
                sortedVals = values.OrderBy(node => node.nodeWeight).ToList(); //https://stackoverflow.com/questions/1301822/how-to-sort-a-list-of-objects-by-a-specific-field-in-c                
            }
            else if(type == 1) 
            { 
                if(counter != 2) 
                { 
                    counter = sortedVals.Count;
                    Node newNode = new Node();
                    newNode.lNode = sortedVals[0];
                    newNode.rNode = sortedVals[1];
                    newNode.nodeWeight = newNode.lNode.nodeWeight + newNode.rNode.nodeWeight;
                    newNode.nodeValue = '\0';
                    sortedVals.Remove(sortedVals[0]);
                    sortedVals.Remove(sortedVals[1]);

                    sortedVals.Add(newNode);

                    sortedVals = sortedVals.OrderBy(node => node.nodeWeight).ToList();
                    sort(1, sortedVals.Count);
                } 
            }
        }

        public void print() 
        {
            Console.WriteLine("Unsorted: ");
            Console.WriteLine("List len: " + values.Count);
            for (int i = 0; i < values.Count; i++)
            {
                Console.WriteLine("Node Value: " + values[i].nodeValue + " Node Weight: " + values[i].nodeWeight);
            }

            Console.WriteLine("Sorted: ");
            Console.WriteLine("List len: " + sortedVals.Count);
            for (int i = 0; i < sortedVals.Count; i++)
            {
                Console.WriteLine("Node Value: " + sortedVals[i].nodeValue + " Node Weight: " + sortedVals[i].nodeWeight);
            }
        }
    }

}
