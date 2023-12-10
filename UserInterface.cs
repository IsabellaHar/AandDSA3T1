using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AandDSA2T1
{
    internal class UserInterface
    {
        public void Heading()
        {
            Console.WriteLine("++++++++++++++++++++++++++++++++");
            Console.WriteLine("   Exploring Data Structures    ");
            Console.WriteLine();
        }

        //Step 4 (part)
        public int TopMenu()
        {

            while (true)
            {
                Console.WriteLine("Select an option");
                Console.WriteLine("1) Search for a number in all data structures");
                Console.WriteLine("2) Exit");
                Console.WriteLine("Enter option (1-2):");

                ConsoleKeyInfo keyInfo = Console.ReadKey();

                if (keyInfo.KeyChar == '1') return 1;
                else if (keyInfo.KeyChar == '2') return 2;
                else
                {
                    Console.WriteLine("You did not select a valid option, please try again.");
                }

            } //end while

        } //end TopMenu

        //Step 4 (part)
        public int GetNumber()
        {
            int number = 1;
            bool checkNumber = false;

            Console.WriteLine();
            Console.WriteLine("Each data structure holds the same list of random numbers.");

            while (!checkNumber)
            {
                Console.WriteLine("Please enter a number between 1 and 150,000 to search for");
                string enteredNumber = Console.ReadLine();
                enteredNumber = enteredNumber.Replace(",", "");

                if (int.TryParse(enteredNumber, out number))
                {
                    if (number >= 1 && number <= 150000)
                    {
                        checkNumber = true;
                    }
                    else Console.WriteLine("The number entered was outside the range.");
                }
                else Console.WriteLine("The input needs to be a number.");
            }

            return number;

        }//end GetNumber

        //Step 4 (part)
        public void TimeReport(bool numberExists, string dataStructure, string searchTime)
        {
            Console.WriteLine();
            if (numberExists)
            {
                Console.WriteLine("The number was found in the " + dataStructure + " in " + searchTime + " microseconds.");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("The number was not found in the " + dataStructure + ".");
                Console.WriteLine("It took " + searchTime + " microseconds to confirm this");
                Console.WriteLine();
            }
        }

        public void Exit()
        {
            Console.WriteLine();
            Console.WriteLine("Goodbye.");
        }

    }
}
