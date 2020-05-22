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

            //for each char in input string
            for(int i = 0; i < text.Length-1; i++) 
            {
                currentChar = text[i];
                flag = false;
                Console.WriteLine(values.Count);

                //for each node that already exists with a value
                for(int j = 0; j<values.Count-1; j++) 
                { 

                    //increase weight of current node if it shares a value
                    if(currentChar == values[j].nodeValue) 
                    {
                        flag = true; //Don't need to create new node
                        values[j].nodeWeight++; 
                    }

                }

                //Add a new node if needed
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
                    Node newNode = new Node(); //New node to be added to tree

                    newNode.lNode = sortedVals[0]; //Setting lNode
                    newNode.rNode = sortedVals[1]; //Setting rNode

                    newNode.lNode.parentNode = newNode; //Setting lNode parent
                    newNode.rNode.parentNode = newNode; //Setting rNode parent

                    newNode.nodeWeight = newNode.lNode.nodeWeight + newNode.rNode.nodeWeight; //Setting node weight to sum of direct child nodes

                    sortedVals.Remove(sortedVals[0]); //Removing lNode from list to prevent duplication
                    sortedVals.Remove(sortedVals[1]); //Removing rNode from list to prevent duplication

                    sortedVals.Add(newNode); //Adding the node back in to be sorted 

                    sortedVals = sortedVals.OrderBy(node => node.nodeWeight).ToList(); //Resorting list, with new Node

                    sort(1, sortedVals.Count); //Reccursion
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
