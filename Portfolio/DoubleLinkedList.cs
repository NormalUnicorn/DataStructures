﻿using System;
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
            if(headNode == null) 
            {
                headNode = NodeToAdd;
            }
            else 
            { 
                headNode.previousNode = NodeToAdd;
                NodeToAdd.nextNode = headNode;
                headNode = NodeToAdd;
            }
            listLength += 1;            
        }

        //Adds node to the end of the linkedlist
        public void appendEnd(Node NodeToAdd)
        {
            Node currentNode = headNode;
            Node previousListNode = headNode;

            while (currentNode.nextNode != null)
            {
                previousListNode = currentNode;
                currentNode = currentNode.nextNode;
            }

            currentNode.nextNode = NodeToAdd;
            tailNode = NodeToAdd;
            tailNode.previousNode = previousListNode;
            listLength += 1;
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
        public void removeStart()
        {
            headNode = headNode.nextNode;
            listLength -= 1;
        }

        //Removes last node in list
        public void removeEnd()
        {
            Node CurrentNode = headNode;
            while (CurrentNode.nextNode != tailNode)
            {
                CurrentNode = CurrentNode.nextNode;
            }
            CurrentNode.nextNode = null;
            listLength -= 1;
        }

        //Used to check which node to remove from the list, either call Start/End or go through the list to correct point
        public void remove(int removePos)
        {
            if (removePos == 0)
            {
                removeStart();
            }

            if (removePos >= listLength)
            {
                removeEnd();
            }

            if (removePos != 0 && removePos < listLength)
            {
                Node currentNode = headNode;
                for (int i = 0; i < removePos-1; i++)
                {
                    currentNode = currentNode.nextNode;
                }
            }
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

