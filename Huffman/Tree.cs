using System;
using System.Collections.Generic;
using System.Text;

namespace Huffman
{
    class Tree : HuffmanLogic
    {

        public Node headNode { get; set; } //the headnode in the tree

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

            //Console.WriteLine(nodeList.Count);
            if(nodeList.Count > 2) 
            {
                Node newNode = new Node(); //create new node 

                newNode.lNode = nodeList[0]; //set lNode
                newNode.rNode = nodeList[1]; //set rNode

                newNode.lNode.parentNode = newNode; //set parents
                newNode.rNode.parentNode = newNode; //set parents

                newNode.nodeWeight = newNode.lNode.nodeWeight + newNode.rNode.nodeWeight; //create the weight value for the new node

                //This cost me two sleepless nights, the issue was removing them in the wrong order. very bad!
                nodeList.RemoveAt(1);
                nodeList.RemoveAt(0);

                //Add new newNode to list of nodes again
                nodeList.Add(newNode);

                //checking it works 
                Console.WriteLine("New node created: " + newNode.nodeWeight);
                Console.WriteLine("Node children: \nlNode: " + newNode.lNode.nodeValue + " \nrNode: " + newNode.rNode.nodeValue);
                Console.WriteLine("Node parents: \nlNode: " + newNode.lNode.parentNode.nodeWeight + "\nrNode: " + newNode.rNode.parentNode.nodeWeight);

                //Sort the list again, with the newNode in it now
                nodeList = sort(nodeList);

                //reccursion 
                createTree(nodeList);
            }

            else 
            {
                //if there are only 2 nodes in the array, then set the children of headNode to the two remaining nodes

                headNode.lNode = nodeList[0];
                
                //this is incase there is only one letter in the string, there won't be two nodes so would throw an error
                try
                { 
                    headNode.rNode = nodeList[1];
                }
                catch (ArgumentOutOfRangeException outOfRange) 
                {
                    Console.WriteLine("The text to compress only contains one letter");
                }

                headNode.lNode.parentNode = headNode;

                //If there is only one letter to compress, then there is only one node
                if(headNode.rNode!= null) 
                {
                    headNode.rNode.parentNode = headNode;
                }
            }
        }

        //Depth first search to find a given character in the tree
        public Stack<int> DFS(char charToFind) 
        {

            Node currentNode = headNode; //Start of the tree
            List<Node> visited = new List<Node>(); //List of visited nodes
            Stack<int> output = new Stack<int>(); //final output for that character
            bool flag = false; //flag indicating if node has been found
            bool showTreeTraversal = true; //make this true if you would like to build the tree by hand, will show how the code is moving around the tree(warning, will spam console)

            while(!flag) //While not found
            {
                //If currently at a node that has been looked at
                if(visited.Contains(currentNode) == true) 
                {
                    //Console.WriteLine("Updating new node");
                    //Checking to see if we have been to the left node before, and if the left node actually exists
                    if (visited.Contains(currentNode.lNode) == false && currentNode.lNode != null)
                    {

                        if(showTreeTraversal) 
                        { 
                            Console.WriteLine("Going left");
                        }

                        currentNode = currentNode.lNode;
                        //Console.WriteLine("Node Value: " + currentNode.nodeValue);
                        output.Push(0); //Add 0 to represent left on tree
                    }
                    //If we can't go left, check if we can go right
                    else if (visited.Contains(currentNode.rNode) == false && currentNode.rNode != null)
                    {

                        if(showTreeTraversal) 
                        { 
                            Console.WriteLine("Going right");
                        }

                        currentNode = currentNode.rNode;
                        output.Push(1); //Add 1 to represent right on tree
                    }
                    //If we can't go left or right, then simply go back to the parent 
                    else
                    {

                        if(showTreeTraversal) 
                        { 
                            Console.WriteLine("Going up");
                        }

                        currentNode = currentNode.parentNode;
                        output.Pop(); //Remove the direction to this node from the stack
                    }
                    //Console.WriteLine("Checking new node: " + currentNode.nodeWeight + currentNode.nodeValue);
                }

                //If the currentNode has a value, is it equal to the inputChar? if so, then return the stack detailing the journey across the tree.
                if(currentNode.nodeValue!='\0') //honestly don't need this first if check, not really worth it in any way at all, oh well, too bad!
                { 
                    if(currentNode.nodeValue == charToFind) 
                    {
                        if(showTreeTraversal) 
                        { 
                            Console.WriteLine("Correct node found");
                        }
                        flag = true; //Found
                        return output;
                    }               
                }

                visited.Add(currentNode);//update list of visited nodes 
            }

            return new Stack<int>();//stack detailing the path through the tree to take
        }

        //better decompression, use this one instead of the horrible bodged one up top
        public string decompress(string path) 
        {
            string output = "";
            Node currentNode = headNode;
            char currentChar = ' ';
            for(int i=0; i<path.Length;i++)
            {
                currentChar = path[i];
                Console.WriteLine("current char: " + currentChar);
                if (currentNode.nodeValue != '\0') 
                {
                    output += currentNode.nodeValue;
                    Console.WriteLine("output: " + output);
                    currentNode = headNode;
                }
                else if (currentChar == '0') 
                {
                    currentNode = currentNode.lNode;
                }
                else if(currentChar == '1') 
                {
                    currentNode = currentNode.rNode;
                }
            }
            Console.WriteLine("output: " + output);
            return output;
        }

    }
}
