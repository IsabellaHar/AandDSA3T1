using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AandDSA2T1
{
    //Step 1 (part)
    public class Node
    {

        public int value { get; set; }
        public Node? parent { get; set; }
        public Node? leftChild { get; set; }
        public Node? rightChild { get; set; }

        public int height;  //required for AVL tree


        public Node() {}

        public Node(int _value)
        {
            value = _value;
            height = 1;
        }

        public int GetHeight()  //iterates to find distance to root node
        {
            int height = 1;
            Node current = this;
            while (current.parent != null)
            {
                height++;
                current = current.parent;
            }
            return height;
        }


    }
}
