using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P5_SlotMachine
{
    public class UI
    {
        /// <summary>
        /// It prints the game headline and its first instructions
        /// </summary>
        public static void PrintGame1stInstructions()
        {
            Console.WriteLine("***** Slot Machine Game *****\n");
            Console.WriteLine("Game rules:\n-To initiate the game you need to make a bet.\n-Each line costs $1 and you can bet up to $3 at once.");
            Console.WriteLine("-You win $1 for each line with THREE identical numbers in sequence (e.g. 1 1 1).\n-The number sequence can be in a row, column, and diagonal.\n");
                        
        }

        /// <summary>
        /// It asks the player how much they would like to bet 
        /// </summary>
        /// <returns> The bet amount (int)</returns>
        public static int MakeYourBet(int bet)
        {
            Console.Write("How much would you like to bet? Choose $1, $2 or $3.\n");
            //int bet = 0;

            while (true)
            {
                Console.Write("Enter $ ");
                bet = Int32.Parse(Console.ReadLine());

                if (bet > 0 && bet < 4)
                {
                    return bet;
                }
                else 
                {
                    Console.WriteLine($"${bet} is a invalid entry value.\n");
                }
                
            }
        }

        /// <summary>
        /// Prints an array in a 3x3 matrix shape
        /// </summary>
        /// <param name="array2D">Integer array [3,3] </param>
        public static void PrintArrayMatrix(int[,] array2D)
        {
            Console.WriteLine();// Skips a line

            for (int row = 0; row < array2D.GetLength(0); row++) //GetLength(<dimension>) returns the number of array items for each dimension (row = 3)
            {
                for (int column = 0; column < array2D.GetLength(1); column++) //GetLength(<dimension>) returns (colmns = 3)
                {
                    Console.Write($"  {array2D[row, column]}"); //Print the numbers in line sepated by a space
                }
                Console.WriteLine();//Skips a line to print another set of numbers in line on the next iteraction
            }
        }

        /// <summary>
        /// It printes a message of the array elements similirities
        /// </summary>
        /// <param name="resValidation">True or False</param>
        /// <param name="index">Index number</param>
        /// <param name="rowCol">Row or Column words</param>
        public static void PrintWinLose(int cashSum)
        {
            if (cashSum > 0)
            {
                Console.WriteLine($"\nYou WON!!!\nTotal ${cashSum}");
            }
            else
            {
                Console.WriteLine($"\nYou LOSE!!!\nTotal ${cashSum}");
            }

        }

        public static bool AskToContinueGame()
        {
            bool yesNo;
            Console.Write("\nWould you like to make a new bet? Y/N\nEnter: ");

            if (Console.ReadKey().Key == ConsoleKey.Y)
            {
                yesNo = true;
            }
            else
            {
                yesNo = false;
            }
            Console.WriteLine();
            return yesNo;
                        
        }
    }

}
