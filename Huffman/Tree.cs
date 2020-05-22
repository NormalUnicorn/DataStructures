using System;
using System.Collections.Generic;
using System.Text;

namespace Huffman
{
    class Tree
    {
        public Node headNode { get; set; }
        public List<Node> visited { get; set; }


        public Tree() 
        {
            headNode = new Node();
        }


        public void createTree(Node[] values)  
        {
            headNode.lNode = values[0];
            headNode.rNode = values[1];
        }
        
        public Stack<int> depthFirstSearch(char charToFind) 
        {
            //Todo, create stack and then use stack to help traverse tree to find correct node.
            Node currentNode = headNode;
            List<Node> visited = new List<Node>();
            Stack<int> output = new Stack<int>();
            bool flag = true;

            //while not found value
            while(flag) 
            {
                //check if current node has a value
                if(currentNode.nodeValue != '\0') 
                {
                    //if it's the correct value then stop the loop, and 
                    if(currentNode.nodeValue == charToFind) 
                    {
                        Console.WriteLine("got here too");
                        flag = false;
                    }
                    else if(visited.Contains(currentNode.lNode) == false) 
                    {
                        currentNode = currentNode.lNode;
                        output.Push(0);
                    }
                    else if(visited.Contains(currentNode.rNode) == false) 
                    {
                        currentNode = currentNode.rNode;
                        output.Push(1);
                    }
                    else if(visited.Contains(currentNode.lNode) && visited.Contains(currentNode.rNode)) 
                    {
                        output.Pop();
                        currentNode = currentNode.parentNode;
                    }
                }                
            }

            return output;
        }

        public Node updateNode(Node currentNode, List<Node> visited) 
        { 
            if(visited.Contains(currentNode.lNode) == false) 
            {
                return currentNode.lNode;
            }
            else if(visited.Contains(currentNode.rNode) == false) 
            {
                return currentNode.rNode;
            }
            else 
            {
                return currentNode.parentNode;
            }
        }

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
                    Console.WriteLine("Checking new node: " + currentNode.nodeWeight + currentNode.nodeValue);
                }

                if(currentNode.nodeValue == charToFind) 
                {
                    Console.WriteLine("Correct node found");
                    flag = true; //Found
                    return output;
                }
                visited.Add(currentNode);
            }
            return new Stack<int>();
        }

    }
}
