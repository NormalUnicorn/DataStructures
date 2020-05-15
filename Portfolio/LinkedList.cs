using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio
{
    class LinkedList
    {
        public Node headNode { get; set; }
        public Node tailNode { get; set; }
        public int listLength { get; set; }

        public LinkedList() 
        {
            headNode = null;
            tailNode = null;
            listLength = 0;
        }

        public void appendStart(Node NodeToAdd) 
        {
            NodeToAdd.nextNode = headNode;
            headNode = NodeToAdd;
            listLength += 1;
        }

        public void appendEnd(Node NodeToAdd) 
        {
            Node currentNode = headNode;

            while(currentNode.nextNode!=null) 
            {
                currentNode = currentNode.nextNode;
            }

            currentNode.nextNode = NodeToAdd;
            tailNode = NodeToAdd;
            listLength += 1;
        }

        public void append(Node NodeToAdd,int appendPos) 
        {
            if(appendPos == 0) 
            {
                appendStart(NodeToAdd);
            }

            if(appendPos >= listLength) 
            {
                appendEnd(NodeToAdd);
            }

            if(appendPos != 0 && appendPos < listLength-1) 
            {
                Node currentNode = headNode;
                for(int i=1; i<appendPos; i++) 
                {
                    currentNode = currentNode.nextNode;
                }
                NodeToAdd.nextNode = currentNode.nextNode;
                currentNode.nextNode = NodeToAdd;
                listLength += 1;
            }
        }

        public void remove(int removePos) 
        { 
            if(removePos == 0) 
            {
                removeStart();
            }

            if(removePos >= listLength) 
            {
                removeEnd();
            }

            if (removePos != 0 && removePos < listLength-1) 
            {
                Node currentNode = headNode;
                for(int i = 1; i<removePos; i++) 
                {
                    currentNode = currentNode.nextNode;
                }
            }
        }

        public void removeStart() 
        {
            headNode = headNode.nextNode;
            listLength -= 1;
        }

        public void removeEnd() 
        {
            Node CurrentNode = headNode;
            while(CurrentNode.nextNode != tailNode) 
            {
                CurrentNode = CurrentNode.nextNode;
            }
            CurrentNode.nextNode = null;
            listLength -= 1;
        }

        public void print() 
        {
            Console.WriteLine("Priting linked list:");

            Node currentNode = headNode;
            while(currentNode.nextNode != null) 
            {
                Console.WriteLine(currentNode.nodeData);
                currentNode = currentNode.nextNode;
            }

            Console.WriteLine(currentNode.nodeData);

        }
    }
}
