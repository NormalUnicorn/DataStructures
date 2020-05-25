using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio
{
    class Stack
    {
        public Node headNode { get; set; }
        public Node tailNode { get; set; }
        public int stackLength { get; set; }
        public int staticLen { get; set; }

        public Stack() 
        {
            headNode = null;
            tailNode = null;
            stackLength = 0;
        }

        //If the stack is empty, it adds the node to the start and end, otherwise it updates the end of the stack
        public void Push(Node NodeToAdd)
        {
            if (headNode == null) 
            {
                headNode = NodeToAdd;
                tailNode = NodeToAdd;
            }
            else 
            {
                NodeToAdd.nextNode = tailNode;
                tailNode = NodeToAdd;
            }
            stackLength += 1;
        }

        //Takes the node data from the tail node, and removes it from the stack
        //Really this should return the value instead of just printing it. Too bad!
        public string Peek() 
        {
            Console.WriteLine("Value pulled: " + tailNode.nodeData);
            return tailNode.nodeData;
        }

        public string Pull() 
        {
            string nodeData = tailNode.nodeData;
            tailNode = tailNode.nextNode;
            //Console.WriteLine("new node: " + tailNode.nodeData);
            stackLength--;
            return nodeData;
        }


        //I didn't like MS' version having the array in reverse chronological order, ran into the issue with my huffman
        public string[] toArray() 
        {
            staticLen = stackLength; //updating len with the pull method, so need a static version of it
            string[] stackValues = new string[staticLen];
            string valuePulled;

            //for each node in the stack
            for(int i=0;i<staticLen;i++) 
            {
                valuePulled = this.Pull();
                //Console.WriteLine("Stack len: " + stackLength);
                stackValues[i] = valuePulled;
                //Console.WriteLine("Value pulled: " + valuePulled);
            }

            
            Array.Reverse(stackValues);
            return stackValues;
        }


        public void print() 
        {
            Node currentNode = tailNode; //local var to go through nodes + node data in stack

            Console.WriteLine("Printing stack: ");

            if (headNode == null)
            {
                Console.WriteLine("This stack is empty");
            }
            else 
            { 
            for (int i=0; i < stackLength; i++) 
                {
                    Console.WriteLine(currentNode.nodeData);
                    currentNode = currentNode.nextNode;
                }
            }

        }
    }
}
