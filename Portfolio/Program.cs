﻿using System;

namespace Portfolio
{
    class Program
    {
        static void Main(string[] args)
        {
            int testing = 4; //Change this to change what gets tested
            
            //Creating instances for testing
            Stack myStack = new Stack();
            Queue myQueue = new Queue();
            LinkedList myLinkedList = new LinkedList();
            DoubleLinkedList myDoubleLinkedList = new DoubleLinkedList();
            BubbleSort myBubbleSort = new BubbleSort();

            //Stack testing
            if(testing == 0)
            {
                Console.WriteLine("Stack Testing: ");
                
                //Creating and adding nodes to stack
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("Please input a node value to add to the stack: ");
                    string UserInput = Console.ReadLine();
                    myStack.Push(CreateNode(UserInput));
                    Console.WriteLine("Node added");
                }

                myStack.print();
                myStack.Pull();
                myStack.print();
            }

            //Queue testing
            else if(testing == 1) 
            { 
                Console.WriteLine("Queue Testing: ");

                //Creating and adding nodes to queue
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("Please input a node value to add to the queue: ");
                    string UserInput = Console.ReadLine();
                    myQueue.Enqueue(CreateNode(UserInput));
                    Console.WriteLine("Node Added");
                }

                myQueue.print();
                myQueue.Dequeue();
                myQueue.print();            
            }

            //Linked list testing
            else if(testing == 2) 
            { 
                Console.WriteLine("LL testing: ");

                //Creating and adding nodes to the LL
                myLinkedList.appendStart(CreateNode("3"));
                myLinkedList.appendStart(CreateNode("8"));
                myLinkedList.appendStart(CreateNode("4"));
                myLinkedList.appendStart(CreateNode("5"));
                myLinkedList.appendEnd(CreateNode("7"));

                
                Console.WriteLine("Before removal calls");
                myLinkedList.print();

                myLinkedList.removeStart();
                myLinkedList.removeEnd();

                myLinkedList.append(CreateNode("11"), 1); //Change the int here to change where the value gets appended
                myLinkedList.remove(7);

                Console.WriteLine("After removal calls");
                myLinkedList.print();            
            }

            //DoubleLinkedList Testing
            else if(testing == 3) 
            { 
                Console.WriteLine("DoubleLinkedList testing: ");

                //creating and adding nodes to the DLL
                myDoubleLinkedList.appendStart(CreateNode("5"));
                myDoubleLinkedList.appendStart(CreateNode("7"));
                myDoubleLinkedList.appendStart(CreateNode("4"));
                myDoubleLinkedList.append(CreateNode("11"), 1);
                myDoubleLinkedList.appendEnd(CreateNode("8"));


                myDoubleLinkedList.print();
                myDoubleLinkedList.remove(5);
                myDoubleLinkedList.print();           
            }

            //Bubble sort testing
            else if (testing == 4) 
            {
                Console.WriteLine("Bubble sort testing: ");

                //Unsorted
                Console.WriteLine("Unsorted array: ");
                myBubbleSort.print();

                //sorting
                myBubbleSort.sort(myBubbleSort.numbers.Length);

                //printing out sorted list
                Console.WriteLine("Sorted array: ");
                myBubbleSort.print();
            }
            
            //used to create node instances to add data to structures that use nodes
            Node CreateNode(string InputData) 
            {
                Node newNode = new Node();

                newNode.nodeData = InputData;

                return newNode;
            }
        }
    }
}
