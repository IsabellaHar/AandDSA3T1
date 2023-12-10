using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AandDSA2T1
{
    //Step 2 (part)
    internal class AVL : BST 
    {
        
        public override void Insert(Node newNode)
        {
            root = AVLInsert(root, newNode);
        }

        public Node AVLInsert(Node current, Node newNode)
        {
            //if at unused leaf, newNode becomes the leaf
            if (current == null)
            {
                current = newNode;
                current.height = 1;
                return newNode;
            }

            //if current node is not empty, move down left or right as appropriate

            if (newNode.value < current.value)
            {
                current.leftChild = AVLInsert(current.leftChild, newNode);
            }
            else 
            {
               current.rightChild = AVLInsert(current.rightChild, newNode);
            }

            //path has a new node at leaf, update current node's height
            int leftHeight = (current.leftChild != null) ? current.leftChild.GetHeight() : 0;
            int rightHeight = (current.rightChild != null) ? current.rightChild.GetHeight() : 0;
            current.height = 1 + Math.Max(leftHeight, rightHeight);


            //check balance at current node
            int balance = GetBalance(current);


            //Unbalanced case 1
            if (balance > 1 && newNode.value < current.leftChild.value)
                return rightRotate(current); 

            // Unbalanced case 2 
            if (balance < -1 && newNode.value > current.rightChild.value)
                return leftRotate(current); 

            // Unbalanced case 3  
            if (balance > 1 && newNode.value > current.leftChild.value)
            {
                current.leftChild = leftRotate(current.leftChild);
                return rightRotate(current); 
            }

            // Unbalanced case 4  
            if (balance < -1 && newNode.value < current.rightChild.value)
            {
                current.rightChild = rightRotate(current.rightChild);
                return leftRotate(current); // leftRotate(current);
            }

            /* return the node pointer */
            return current; 
        
    } //end insert


        public int GetBalance(Node current)
        {
            if (current == null) return 0;

            return GetHeight(current.leftChild) - GetHeight(current.rightChild);
        }

        public int GetHeight(Node aVLNode)
        {
            if (aVLNode == null) return 0;
            return aVLNode.height;
        }


        Node rightRotate(Node y)
        {

            if (y == null || y.leftChild == null)
            {
                return y;
            }

            Node x = y.leftChild;
            Node T2 = x.rightChild;

            // Perform rotation  
            x.rightChild = y;
            y.leftChild = T2;

            // Update heights  
            y.height = Max(GetHeight(y.leftChild), GetHeight(y.rightChild)) + 1;
            x.height = Max(GetHeight(x.leftChild), GetHeight(x.rightChild)) + 1;

            // Return new root  
            return x;
        }

        Node leftRotate(Node x)
        {
            if (x == null || x.rightChild == null)
            {
                return x;
            }

            Node y = x.rightChild;
            Node T2 = y.leftChild;

            // Perform rotation  
            y.leftChild = x;
            x.rightChild = T2;

            // Update heights  
            x.height = Max(GetHeight(x.leftChild),GetHeight(x.rightChild)) + 1;
            y.height = Max(GetHeight(y.leftChild),GetHeight(y.rightChild)) + 1;

            // Return new root  
            return y;
        }


        int Max(int a, int b)
        {
            return (a > b) ? a : b;
        }




    }


    /* With assistance of 
     * https://www.geeksforgeeks.org/insertion-in-an-avl-tree/?ref=lbp
     */

}
