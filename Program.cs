using System;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Diagnostics;

namespace AandDSA2T1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            UserInterface myUserInterface = new UserInterface();
            myUserInterface.Heading();

            //Step 3

            //Declare data structures
            List<int> myList = new List<int>();
            BST myBST = new BST();
            AVL myAVL = new AVL();

            //Fill data structures with same random numbers
            Random random = new Random();

            for (int i = 0; i < 150000; i++)
            {
                int randomNumber = random.Next(1, 150000);
                myList.Add(randomNumber);
                myBST.Insert(new Node(randomNumber));
                myAVL.Insert(new Node(randomNumber));
            }


            while (true) { 

                //Step 4 - present the user with a simple menue
                int option = myUserInterface.TopMenu();


                //If user has selected to perform searches
                if (option == 1)
                {
                    int searchTarget = myUserInterface.GetNumber();

                    Stopwatch stopwatch = new Stopwatch();

                    //Search first in the List
                    stopwatch.Start();
                    bool numberExists = myList.Contains(searchTarget);
                    stopwatch.Stop();
                    TimeSpan timeTaken = stopwatch.Elapsed;
                    myUserInterface.TimeReport(numberExists, "List", timeTaken.Ticks.ToString());


                    //Search second in the binary search tree
                    stopwatch.Reset();
                    stopwatch.Start();
                    numberExists = myBST.Contains(searchTarget);
                    stopwatch.Stop();
                    timeTaken = stopwatch.Elapsed;
                    myUserInterface.TimeReport(numberExists, "Binary Search Tree", timeTaken.Ticks.ToString());

                    //Search third in the AVL tree
                    stopwatch.Reset();
                    stopwatch.Start();
                    numberExists = myAVL.Contains(searchTarget);
                    stopwatch.Stop();
                    timeTaken = stopwatch.Elapsed;
                    myUserInterface.TimeReport(numberExists, "AVL Tree", timeTaken.Ticks.ToString());

                }


                else break;

            }

            myUserInterface.Exit();
            

        }
    }
}