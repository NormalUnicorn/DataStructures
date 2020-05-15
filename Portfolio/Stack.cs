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
        public void Pull() 
        {
            Console.WriteLine("Value pulled: " + tailNode.nodeData);
            tailNode = tailNode.nextNode;
            stackLength -= 1;
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
