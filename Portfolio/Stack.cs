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
            if(stackLength > 0)
            { 
                return tailNode.nodeData;
            }
            else 
            {
                Console.WriteLine("The stack is empty, there is no value to peek at!");
            }
            return null;
        }

        public string Pull() 
        {
            
            if(stackLength>0) 
            { 
                string nodeData = tailNode.nodeData;
                tailNode = tailNode.nextNode;
                //Console.WriteLine("new node: " + tailNode.nodeData);
                stackLength--;
                return nodeData;
            }
            else 
            {
                Console.WriteLine("The stack is empty, there is no value to pull!");
            }
            return null;
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

        //I didn't like MS' version having the array in reverse chronological order, ran into issue over this with my huffman, very bad!
        public string[] toArray() 
        {
            staticLen = stackLength; //updating len with the pull method, so need a static version of it
            string[] stackArray = new string[staticLen];
            string valuePulled;

            //for each node in the stack
            for(int i=0;i<staticLen;i++) 
            {
                valuePulled = this.Pull();
                //Console.WriteLine("Stack len: " + stackLength);
                stackArray[i] = valuePulled;
                //Console.WriteLine("Value pulled: " + valuePulled);
            }

            
            Array.Reverse(stackArray);
            return stackArray;
        }
    }
}
