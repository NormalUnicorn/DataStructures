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
        public int nodeWeight { get; set; }//node weight
        public char nodeValue { get; set; }//value held in the node
        public int nodeID { get; set; } //debugging, mayhaps? potentially? spoilers: never actually used this :(

        public Node() 
        {
            parentNode = null;
            lNode = null;
            rNode = null;
            nodeWeight = 0; 
            nodeValue = '\0'; //chars cannot be null, so '\0 is the equivilant'
        }
    }
}
