using System;
using System.Collections.Generic;
using System.Text;

namespace Huffman
{
    class Tree
    {
        public Node headNode { get; set; }

        public Tree() 
        {
            headNode = new Node();
        }

        //function that combines the two final nodes to make one tree, could have been in huffman. Too bad!
        public void createTree(Node[] values)  
        {
            headNode.lNode = values[0]; //Set lNode of headnode to the first Node in array
            headNode.rNode = values[1]; //Set rNode of headnode to the second Node in array

            headNode.lNode.parentNode = headNode; //Making lNode parentNode point to headNode 
            headNode.rNode.parentNode = headNode; //Making rNode parentNode point to headNode
        }

        //Depth first search to find a given character in the tree
        public Stack<int> DFS(char charToFind) 
        {

            Node currentNode = headNode; //Start of the tree
            List<Node> visited = new List<Node>(); //List of visited nodes
            Stack<int> output = new Stack<int>(); //final output for that character
            bool flag = false; //flag indicating bool found

            while(!flag) //While not found
            {
                //If currently at a node that has been looked at
                if(visited.Contains(currentNode) == true) 
                {
                    Console.WriteLine("Updating new node");
                    if (visited.Contains(currentNode.lNode) == false && currentNode.lNode != null)
                    {
                        currentNode = currentNode.lNode;
                        output.Push(0); //Add 0 to represent left on tree
                    }
                    else if (visited.Contains(currentNode.rNode) == false && currentNode.rNode != null)
                    {
                        currentNode = currentNode.rNode;
                        output.Push(1); //Add 1 to represent right on tree
                    }
                    else
                    {
                        currentNode = currentNode.parentNode;
                        output.Pop(); //Remove the direction to this node from the stack
                    }
                    //Console.WriteLine("Checking new node: " + currentNode.nodeWeight + currentNode.nodeValue);
                }

                //If the currentNode has a value, is it equal to the inputChar? if so, then return the stack detailing the journey across the tree.
                if(currentNode.nodeValue!='\0') 
                { 
                    if(currentNode.nodeValue == charToFind) 
                    {
                        Console.WriteLine("Correct node found");
                        flag = true; //Found
                        return output;
                    }               
                }
                visited.Add(currentNode);
            }
            return new Stack<int>();
        }

    }
}
