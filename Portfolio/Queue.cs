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
        public int staticLen { get; set; }

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
        public string Dequeue() 
        {
            if(queueLength>0) 
            {
                string nodeData = headNode.nodeData;
                headNode = headNode.nextNode;
                queueLength -= 1;
                return nodeData;
            }
            else 
            {
                Console.WriteLine("Sorry, the queue is empty!");
            }
            return null;
        }

        public string peek() 
        { 
            if(queueLength>0) 
            {
                return headNode.nodeData;
            }
            else 
            {
                Console.WriteLine("The queue is empty! no value to peek at.");
            }
            return null;
        }

        //Prints out the contents of the queue
        public void print() 
        {
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

        public string[] toArary() 
        {
            staticLen = queueLength;
            string[] queueArray = new string[staticLen];
            string valueDequeued;

            for(int i = 0; i<staticLen;i++) 
            {
                valueDequeued = this.Dequeue();
                queueArray[i] = valueDequeued;
            }

            return queueArray;
        }

    }
}
