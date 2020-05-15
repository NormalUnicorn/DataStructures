using System;

namespace Portfolio
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack stack = new Stack();
            Queue queue = new Queue();
            LinkedList linkedList = new LinkedList();
            DoubleLinkedList doubleLinkedList = new DoubleLinkedList();
            BubbleSort bubblesort = new BubbleSort();

            //for (int i = 0; i < 5; i++) 
            //{
            //    string UserInput = Console.ReadLine();
            //    stack.Push(CreateNode(UserInput));
            //    Console.WriteLine("Node added");

            //}

            //stack.print();
            //stack.Pull();
            //stack.print();

            //for(int i =0; i<5; i++) 
            //{
            //    string UserInput = Console.ReadLine();
            //    queue.Enqueue(CreateNode(UserInput));
            //    Console.WriteLine("Node Added");
            //}

            //queue.print();
            //queue.Dequeue();
            //queue.print();

            //linkedList.appendStart(CreateNode("3"));
            //linkedList.appendStart(CreateNode("8"));
            //linkedList.appendStart(CreateNode("4"));
            //linkedList.appendStart(CreateNode("5"));
            //linkedList.appendEnd(CreateNode("7"));

            //Console.WriteLine(linkedList.listLength);

            //linkedList.append(CreateNode("11"), 5);
            //linkedList.print();



            Node CreateNode(string InputData) 
            {
                Node newNode = new Node();

                newNode.nodeData = InputData;

                return newNode;
            }
        }
    }
}
