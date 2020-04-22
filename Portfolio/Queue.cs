using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio
{
    class Queue
    {
        public Node headNode { get; set; }
        public Node tailNode { get; set; }
        public int queueLength { get; set; }

        public Queue() 
        {
            headNode = null;
            tailNode = null;
            queueLength = 0;
        }

        public void Enqueue(Node NodeToAdd) 
        { 
            if(headNode == null) 
            {
                headNode = NodeToAdd;
                tailNode = NodeToAdd;
            }
            else 
            {
                NodeToAdd.nextNode = tailNode;
                tailNode = NodeToAdd;
            }
            queueLength += 1;
        }

        public void dequeue() 
        {
            Console.WriteLine("Node dequeued: " + headNode.nodeData);
            headNode = headNode.nextNode;
            queueLength -= 1;
        }

        public void print() 
        {
            Node currentNode = headNode;
            Console.WriteLine("Printing Queue: ");

            if(headNode == null) 
            {
                Console.WriteLine("This queue is empty");
            }
            else 
            { 
                for(int i = 0; i < queueLength; i++) 
                {
                    Console.WriteLine(currentNode.nodeData);
                    currentNode = currentNode.nextNode;
                }
            }
        }

    }
}
