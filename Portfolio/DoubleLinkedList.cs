using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio
{
    class DoubleLinkedList
    {
        public Node headNode { get; set; }
        public Node tailNode { get; set; }
        public int listLength { get; set; }

        public DoubleLinkedList()
        {
            headNode = null;
            tailNode = null;
            listLength = 0;
        }

        //Adds node to start of the linkedlist
        public void appendStart(Node NodeToAdd)
        {
            //if the list is empty, then we just need to set the headnode
            if(headNode == null) 
            {
                headNode = NodeToAdd;
            }
            //Otherwise, we need to move the headnode along one
            else 
            { 
                headNode.previousNode = NodeToAdd;
                NodeToAdd.nextNode = headNode;
                headNode = NodeToAdd;
            }
            listLength++;            
        }

        //Adds node to the end of the linkedlist
        public void appendEnd(Node NodeToAdd)
        {
            Node currentNode = headNode;
            Node previousListNode = headNode;

            //Get to the node before the tail node
            while (currentNode.nextNode != null)
            {
                previousListNode = currentNode;
                currentNode = currentNode.nextNode;
            }

            //Update values
            currentNode.nextNode = NodeToAdd;
            tailNode = NodeToAdd;
            tailNode.previousNode = previousListNode;
            listLength++;
        }

        //Used to check where to add the Node, either call the Start/End functions or go through the list to correct point
        public void append(Node NodeToAdd, int appendPos)
        {
            if (appendPos == 0)
            {
                appendStart(NodeToAdd);
            }
            else if (appendPos >= listLength)
            {
                appendEnd(NodeToAdd);
            }
            else if(appendPos == 1) 
            {
                Node tempNode = headNode.nextNode;
                headNode.nextNode = NodeToAdd;
                NodeToAdd.nextNode = tempNode;
                tempNode.previousNode = NodeToAdd;
                NodeToAdd.previousNode = headNode;
                listLength++;
            }
            else
            {
                Node currentNode = headNode; //Local var to go through nodes in list
                Node previousListNode = headNode;
                for (int i = 0; i < appendPos-1; i++)
                {
                    previousListNode = currentNode;
                    currentNode = currentNode.nextNode;
                }

                NodeToAdd.nextNode = currentNode;
                NodeToAdd.previousNode = previousListNode;
                previousListNode.nextNode = NodeToAdd;
                currentNode.previousNode = NodeToAdd;
                listLength += 1;
            }
        }

        //Removes first node in list
        public string removeStart()
        {
            string returnVal = headNode.nodeData;
            headNode = headNode.nextNode;
            headNode.previousNode = null;
            listLength--;
            return returnVal;
        }

        //Removes last node in list
        public string removeEnd()
        {
            string returnVal;
            Node CurrentNode = headNode;

            while (CurrentNode.nextNode != tailNode)
            {
                CurrentNode = CurrentNode.nextNode;
            }
            returnVal = tailNode.nodeData;
            CurrentNode.nextNode = null;
            tailNode = CurrentNode;
            listLength--;
            return returnVal;
        }


        //Used to check which node to remove from the list, either call Start/End or go through the list to correct point
        //there is an issue when removing pos 1, where it doesn't properly get removed, as I don't update the head value
        public string remove(int removePos)
        {
            string returnVal;
            if (removePos == 0)
            {
                returnVal = removeStart();
            }

            else if (removePos >= listLength)
            {
                returnVal = removeEnd();
            }

            else if(removePos>0)
            {
                Node previousListNode = headNode;
                Node currentNode = headNode;
                for (int i = 0; i < removePos-1; i++)
                {
                    previousListNode = currentNode;
                    currentNode = currentNode.nextNode;
                }

                returnVal = currentNode.nodeData;

                previousListNode.nextNode = currentNode.nextNode;
                previousListNode.nextNode.previousNode = previousListNode;
                listLength--;
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
            Console.WriteLine("Priting double linked list:");

            Node currentNode = headNode;
            //Don't ask why I swapped from for loop in stack/queue to while loop here, no idea why.
            while (currentNode.nextNode != null)
            {
                Console.WriteLine(currentNode.nodeData);
                currentNode = currentNode.nextNode;
            }
            //wouldn't need this if used for loop. Too bad!
            Console.WriteLine(currentNode.nodeData);

        }
    }
}

