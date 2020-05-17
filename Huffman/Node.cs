using System;
using System.Collections.Generic;
using System.Text;

namespace Huffman
{
    class Node
    {
        public Node parentNode { get; set; } //parent node
        public Node lNode { get; set; }//left child node
        public Node rNode { get; set; }//right child node
        public int nodeWeight { get; set;}//node weight


        public Node() 
        {
            parentNode = null;
            lNode = null;
            rNode = null;
            nodeWeight = 0;
        }

    }
}
