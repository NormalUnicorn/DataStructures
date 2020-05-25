using System;
using System.Collections.Generic;

namespace Portfolio
{
    class Program
    {
        static void Main(string[] args)
        {
            int testing = 3; //Change this to change what gets tested
            
            //Creating instances for testing
            Stack myStack = new Stack();
            Queue myQueue = new Queue();
            List<string> testList = new List<string>();

            LinkedList myLinkedList = new LinkedList();
            DoubleLinkedList myDoubleLinkedList = new DoubleLinkedList();

            BubbleSort myBubbleSort = new BubbleSort();
            InsertionSort myInsertionSort = new InsertionSort(10);

            //Stack testing
            if(testing == 0)
            {
                Console.WriteLine("Stack Testing: ");
                
                //Creating and adding nodes to stack
                //I'm aware that an issue is caused by entering only 1 node to the array, as the tail node is not set
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("Please input a node value to add to the stack: ");
                    string UserInput = Console.ReadLine();
                    myStack.Push(CreateNode(UserInput));
                    Console.WriteLine("Node added");
                }

                myStack.print();
                myStack.Pull();
                myStack.print();
                myStack.Peek();
                myStack.print();
                testList.AddRange(myStack.toArray());
                //printing out array :)
                foreach(string text in testList) 
                {
                    Console.WriteLine("list text: " + text);
                }
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
                myQueue.peek();
                myQueue.print();
                testList.AddRange(myQueue.toArary());

                foreach(string text in testList) 
                {
                    Console.WriteLine("list text: " + text);
                }
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
            
            else if(testing == 5) 
            {
                myInsertionSort.print(myInsertionSort.sortedValues);
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
