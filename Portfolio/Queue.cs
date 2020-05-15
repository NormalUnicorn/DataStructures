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

        //Adds value to the back of the queue
        public void Enqueue(Node NodeToAdd) 
        { 
            if(headNode == null) 
            {
                headNode = NodeToAdd;
                tailNode = NodeToAdd;
                Console.WriteLine("updated head node");
            }
            else 
            {
                tailNode.nextNode = NodeToAdd;
                tailNode = NodeToAdd;
            }
            queueLength += 1;
        }

        //Removes the top value from the queue
        public void Dequeue() 
        {
            Console.WriteLine("Node dequeued: " + headNode.nodeData);
            headNode = headNode.nextNode;
            queueLength -= 1;
        }

        //Prints out the contents of the queue
        public void print() 
        {
            //Local var used to go through the nodes + node values of the queue
            Node currentNode = headNode; //Local var to go through nodes + node values of queue
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
