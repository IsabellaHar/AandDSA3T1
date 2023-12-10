using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AandDSA2T1
{
    //Step 1 (part)
    internal class BST
    {
        public Node? root {  get; set; }    
        public int count { get; set; }

        public virtual void Insert(Node newNode)
        {
            //if tree is empty, newNode becomes the root
            if (root == null)
            {
                root = newNode;
                return; 
            }

            Node currentNode = root;
            Node? parentNode = null;

            //if tree is not empty, find the correct spot to add the newNode

            while (true)
            {
                parentNode = currentNode;
                if (newNode.value <  currentNode.value)  //if the new value is less than the current node, go left
                {
                    currentNode = currentNode.leftChild;
                    if (currentNode == null)
                    {
                        parentNode.leftChild = newNode;
                        return;
                    }

                }
                else  //if the new value is greater than current node, go right
                {
                    currentNode = currentNode.rightChild;
                    if (currentNode == null)
                    {
                        parentNode.rightChild = newNode;
                        return;
                    }
                }
            }
            
        }


        public Node? Search(int _value, bool showSearchPath = false)
        {
            if (root == null)
            {
                return null;
            }

            Node currentNode = root;

            //walk down tree until the value is found or confirmed not there
            while(currentNode.value != _value)
            {

                //print value of current node if caller wants to show the path
                if (showSearchPath)
                {
                    Console.Write(currentNode.value + ", ");
                }

                if (_value < currentNode.value)
                {
                    currentNode = currentNode.leftChild;
                }
                else
                {
                    currentNode = currentNode.rightChild;

                }

                //currentNode empty, value not found
                if (currentNode == null)
                {
                    return null;
                }

            }

            return currentNode;
        }
          


        public void PreOrderTraversal(Node current)
        {
            if (current != null)
            {
                Console.WriteLine(current.value);
                PreOrderTraversal(current.leftChild);
                PreOrderTraversal(current.rightChild);
            }
        }



        public void InOrderTraversal(Node current)
        {
            if(current != null)
            {
                InOrderTraversal(current.leftChild);
                Console.WriteLine(current.value);
                InOrderTraversal(current.rightChild); 
            }
        }


        public void PostOrderTraversal(Node current)
        {
            if (current != null)
            {
                PostOrderTraversal(current.leftChild);
                PostOrderTraversal(current.rightChild);
                Console.WriteLine(current.value);
            }
        }


        public bool Contains(int searchTarget)
        {
            Node current = root;
            while (current != null)
            {
                if (searchTarget == current.value) return true;

                if (searchTarget < current.value)
                {
                    current = current.leftChild;
                }
                else
                {
                    current = current.rightChild;
                }

            }

            return false;
        } 

    }
}

//Reference: Module 9 Learning Activities  https://torrens.blackboard.com/webapps/blackboard/content/listContent.jsp?course_id=_148034_1&content_id=_11449493_1&mode=reset
