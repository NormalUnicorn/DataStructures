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

        public void Pull() 
        {
            Console.WriteLine("Value pulled: " + tailNode.nodeData);
            tailNode = tailNode.nextNode;
            stackLength -= 1;
        }

        public void print() 
        {

            Node currentNode = tailNode;
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
