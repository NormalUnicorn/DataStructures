using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio
{
    class Node
    {
        //Used for Stack, Queue, and LL/DLL
        public Node nextNode { get; set; }
        public Node previousNode { get; set; }
        public string nodeData { get; set; }

        //Used for Tree and Graph
        public Node parentNode { get; set; }
        public Node[] childNode { get; set; }
        public int nodeWeight { get; set; }

        public Node()
        {
            nextNode = null;
            previousNode = null;
            parentNode = null;
            childNode = null;
        }
    }
}
