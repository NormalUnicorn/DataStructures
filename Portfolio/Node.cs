using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio
{
    class Node
    {
        public Node nextNode { get; set; }
        public Node previousNode { get; set; }
        public string nodeData { get; set; }

        public Node()
        {
            nextNode = null;
            previousNode = null;
        }
    }
}
