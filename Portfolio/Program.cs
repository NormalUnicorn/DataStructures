using System;

namespace Portfolio
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack stack = new Stack();
            Queue queue = new Queue();


            for (int i = 0; i < 5; i++) 
            {
                string UserInput = Console.ReadLine();
                stack.Push(CreateNode(UserInput));
                Console.WriteLine("Node added");
                
            }

            stack.print();
            stack.Pull();
            stack.print();

            for(int i =0; i<5; i++) 
            {
                string UserInput = Console.ReadLine();
                queue.Enqueue(CreateNode(UserInput));
                Console.WriteLine("Node Added");
            }

            queue.print();
            queue.dequeue();
            queue.print();



            Node CreateNode(string InputData) 
            {
                Node newNode = new Node();

                newNode.nodeData = InputData;

                return newNode;
            }
        }
    }
}
