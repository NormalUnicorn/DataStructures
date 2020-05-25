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

        //Adds node to start of the linkedlist
        public void appendStart(Node NodeToAdd) 
        {
            NodeToAdd.nextNode = headNode;
            headNode = NodeToAdd;
            listLength += 1;
        }

        //Adds node to the end of the linkedlist
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

        //Used to check where to add the Node, either call the Start/End functions or go through the list to correct point
        public void append(Node NodeToAdd,int appendPos) 
        {
            if(appendPos == 0) 
            {
                appendStart(NodeToAdd);
            }
            else if(appendPos >= listLength) 
            {
                appendEnd(NodeToAdd);
            }
            else 
            {
                Node currentNode = headNode; //Local var to go through nodes in list
                for(int i=0; i<appendPos-1; i++) 
                {
                    currentNode = currentNode.nextNode;
                }
                NodeToAdd.nextNode = currentNode.nextNode;
                currentNode.nextNode = NodeToAdd;
                listLength += 1;
            }
        }

        //Removes first node in list
        public string removeStart() 
        {
            string retunVal = headNode.nodeData;
            headNode = headNode.nextNode;
            listLength -= 1;
            return retunVal;
        }

        //Removes last node in list
        public string removeEnd() 
        {
            string returnVal = tailNode.nodeData;
            Node CurrentNode = headNode;
            while(CurrentNode.nextNode != tailNode) 
            {
                CurrentNode = CurrentNode.nextNode;
            }
            CurrentNode.nextNode = null;
            listLength -= 1;
            return returnVal;
        }

        //Used to check which node to remove from the list, either call Start/End or go through the list to correct point
        public string remove(int removePos) 
        {
            string returnVal;
            if(removePos == 0) 
            {
                returnVal = removeStart();
            }

            else if(removePos > listLength) 
            {
                returnVal = removeEnd();
            }

            else  if(removePos>0)
            {
                Node previousListNode = headNode, currentNode = headNode;
                for(int i = 0; i<removePos-1; i++) 
                {
                    previousListNode = currentNode;
                    currentNode = currentNode.nextNode;
                }
                returnVal = currentNode.nodeData;
                previousListNode.nextNode = currentNode.nextNode;
                listLength -= 1;
            }
            else 
            {
                return null;
            }
            return returnVal;
        }

        //Prints out all the values in the list
        public void print() 
        {
            Console.WriteLine("Priting linked list:");

            Node currentNode = headNode;
            //Don't ask why I swapped from for loop in stack/queue to while loop here, no idea why.
            while(currentNode.nextNode != null) 
            {
                Console.WriteLine(currentNode.nodeData);
                currentNode = currentNode.nextNode;
            }
            //wouldn't need this if used for loop. Too bad!
            Console.WriteLine(currentNode.nodeData);

        }
    }
}
