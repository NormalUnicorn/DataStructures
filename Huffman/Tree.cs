using System;
using System.Collections.Generic;
using System.Text;

namespace Huffman
{
    class Tree : HuffmanLogic
    {

        public Node headNode { get; set; }

        public Tree() 
        {
            headNode = new Node();
        }

        //function that combines the two final nodes to make one tree, could have been in huffman. Too bad!
        public void createNodes(List<Node> nodesToSort)  
        {
            headNode.lNode = values[0]; //Set lNode of headnode to the first Node in array
            headNode.rNode = values[1]; //Set rNode of headnode to the second Node in array

            headNode.lNode.parentNode = headNode; //Making lNode parentNode point to headNode 
            headNode.rNode.parentNode = headNode; //Making rNode parentNode point to headNode
        }


        public void createTree(List<Node> nodeList) 
        {

            Console.WriteLine(nodeList.Capacity);
            Node newNode = new Node(); //create new node 
            if(nodeList.Count > 2) 
            {

                newNode.lNode = nodeList[0]; //set lNode
                newNode.rNode = nodeList[1]; //set rNode

                newNode.lNode.parentNode = newNode; //set parents
                newNode.rNode.parentNode = newNode; //set parents

                newNode.nodeWeight = newNode.lNode.nodeWeight + newNode.rNode.nodeWeight; //create the weight value for the new node

                //This cost me two sleepless nights, the issue was removing them in the wrong order. 
                nodeList.RemoveAt(1);
                nodeList.RemoveAt(0);

                nodeList.Add(newNode);

                Console.WriteLine("New node created: " + newNode.nodeWeight);
                Console.WriteLine("Node children: \nlNode: " + newNode.lNode.nodeValue + " \nrNode: " + newNode.rNode.nodeValue);
                Console.WriteLine("Node parents: \nlNode: " + newNode.lNode.parentNode.nodeWeight + "\nrNode: " + newNode.rNode.parentNode.nodeWeight);

                nodeList = sort(nodeList);

                createTree(nodeList);
            }
            else 
            {
                newNode.lNode = nodeList[0];
                newNode.rNode = nodeList[1];

                newNode.lNode.parentNode = newNode;
                newNode.rNode.parentNode = newNode;

                headNode = newNode;
            }
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
                    //Console.WriteLine("Updating new node");
                    //Checking to see if we have been to the left node before, and if the left node actually exists
                    if (visited.Contains(currentNode.lNode) == false && currentNode.lNode != null)
                    {
                        Console.WriteLine("Going left");
                        currentNode = currentNode.lNode;
                        //Console.WriteLine("Node Value: " + currentNode.nodeValue);
                        output.Push(0); //Add 0 to represent left on tree
                    }
                    //If we can't go left, check if we can go right
                    else if (visited.Contains(currentNode.rNode) == false && currentNode.rNode != null)
                    {
                        Console.WriteLine("Going right");
                        currentNode = currentNode.rNode;
                        //Console.WriteLine("Node value: " + currentNode.nodeValue);
                        output.Push(1); //Add 1 to represent right on tree
                    }
                    //If we can't go left or right, then simply go back to the parent 
                    else
                    {
                        Console.WriteLine("Going up");
                        currentNode = currentNode.parentNode;
                        //Console.WriteLine("Node Value: " + currentNode.nodeValue);
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

        public void decompress(string path) 
        {
            Node currentNode = headNode;
            //int counter = 0;
            //char currentChar;

            //Console.WriteLine("current char value: " +currentChar);
            foreach(char currentChar in path)  
            {
                if(currentChar == '0') 
                {
                    //Console.WriteLine("going left");
                    currentNode = currentNode.lNode;
                    //currentChar = path[counter+1];
                }

                if(currentChar == '1') 
                {
                    currentNode = currentNode.rNode;
                    //currentChar = path[counter+1];
                }
                if(currentChar == '3') 
                { 
                    Console.WriteLine(currentNode.nodeValue);
                    currentNode = headNode;
                    //currentChar = path[counter + 1];
                }
            }
            
        }

    }
}
