using System;
using System.Collections.Generic;
using System.Text;

namespace Huffman
{
    class Tree
    {
        public Node headNode { get; set; }
        public List<Node> visited { get; set; }
        public Stack<int> output { get; set; }


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
            visited = new List<Node>();
            output = new Stack<int>();
            bool flag = true;

            //while not found value
            while(flag) 
            {
                if( currentNode.nodeValue == null) 
                {
                    Console.WriteLine("Got here");
                    if(currentNode.nodeValue == charToFind) 
                    {
                        Console.WriteLine("got here too");
                        flag = false;
                    }
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

            return output;
        }
    }
}
