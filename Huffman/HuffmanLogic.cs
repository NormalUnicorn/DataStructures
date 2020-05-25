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

        //Function to work out the frequency(weight) of each character given an input
        public void getValues(string text) 
        {
            //Console.WriteLine(text);
            bool flag;
            char currentChar;

            //For each char in the string
            for (int i = 0; i <= text.Length-1; i++)
            {
                currentChar = text[i];
                flag = false;

                //for each node that already exists with a value
                for (int j = 0; j < values.Count; j++)
                {

                    //increase weight of current node if it shares a value
                    if (currentChar == values[j].nodeValue)
                    {
                        flag = true; //Don't need to create new node
                        values[j].nodeWeight++;
                    }

                }

                //Add a new node if needed
                if (flag == false)
                {
                    //Console.WriteLine("Adding new node");//debugging
                    Node newNode = new Node();
                    newNode.nodeWeight = 1;
                    newNode.nodeValue = currentChar;
                    values.Add(newNode);
                }
            }
        }
        
        //this could go in huffman or tree, as huffman is reliant on the tree.
        //Sorts a list of Nodes by weight, and combines the two lowest node weights as children of a new node
        public List<Node> sort(List<Node> nodeList) 
        {
            sortedVals = nodeList.OrderBy(node => node.nodeWeight).ToList(); //https://stackoverflow.com/questions/1301822/how-to-sort-a-list-of-objects-by-a-specific-field-in-c 
            return sortedVals;
        }

        //debugging
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
