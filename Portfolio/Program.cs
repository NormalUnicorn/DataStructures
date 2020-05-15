using System;

namespace Portfolio
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack myStack = new Stack();
            Queue myQueue = new Queue();
            LinkedList myLinkedList = new LinkedList();
            DoubleLinkedList myDoubleLinkedList = new DoubleLinkedList();
            BubbleSort myBubbleSort = new BubbleSort();


            //Stack testing
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


            //Queue testing
            for (int i = 0; i < 5; i++)
            {
                string UserInput = Console.ReadLine();
                myQueue.Enqueue(CreateNode(UserInput));
                Console.WriteLine("Node Added");
            }

            myQueue.print();
            myQueue.Dequeue();
            myQueue.print();


            //Linked list testing
            //Creating nodes to add to list
            myLinkedList.appendStart(CreateNode("3"));
            myLinkedList.appendStart(CreateNode("8"));
            myLinkedList.appendStart(CreateNode("4"));
            myLinkedList.appendStart(CreateNode("5"));
            myLinkedList.appendEnd(CreateNode("7"));

            Console.WriteLine("Before removal calls");
            myLinkedList.print();

            myLinkedList.removeStart();
            myLinkedList.removeEnd();

            myLinkedList.append(CreateNode("11"), 5); //Change the int here to change where the value gets appended

            Console.WriteLine("After removal calls");

            myLinkedList.print();




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
