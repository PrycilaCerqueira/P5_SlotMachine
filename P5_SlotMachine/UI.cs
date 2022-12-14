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
        /// It prints the game headline and instructions
        /// </summary>
        public static void PrintGameInstructions()
        {
            Console.WriteLine("***** Slot Machine Game *****\n");
            Console.WriteLine("Game rules:\n-To initiate the game you need to make a bet.\n-Each line costs $1 and you can bet up to $3 at once.");
            Console.WriteLine("-You win $1 for each line with THREE identical numbers in sequence (e.g. 1 1 1).\n-The number sequence can be in a row, column, and diagonal.");
                        
        }

        /// <summary>
        /// It asks the player how much they would like to bet 
        /// </summary>
        /// <returns> The bet amount (int)</returns>
        public static int MakeYourBet()
        {
            int bet = 0;
            Console.Write("\nHow much would you like to bet? Choose $1, $2 or $3.\n");
            
            while (true)
            {
                Console.Write("Enter $ ");
                string input = Console.ReadLine();
                
                if (input.Length > 1)
                {
                    Console.WriteLine("Enter only one digit.\n");
                    continue;
                }
                if (!int.TryParse(input, out bet))
                {
                    Console.WriteLine($"'{input.ToUpper()}' is a invalid entry value.\n");
                    continue;
                }
                if (bet < 1 || bet > 3)
                {              
                    Console.WriteLine($"${bet} is a invalid value.\n");
                    continue;
                }
                break;
            }
            return bet;

        }

        /// <summary>
        /// Prints an array in an up 3x3 matrix shape
        /// </summary>
        /// <param name="grid">Array [rows, columns] </param>
        public static void PrintGrid(int[,] grid, string gridStatus)
        {
            Console.WriteLine($"\n  {gridStatus}");// Skips a line
            for (int row = 0; row < grid.GetLength(0); row++) //GetLength(<dimension>) returns the number of array items for each dimension (row = 3)
            {
                for (int column = 0; column < grid.GetLength(1); column++) //GetLength(<dimension>) returns (colmns = 3)
                {
                    string gridElements = grid[row, column].ToString();

                    if (grid[row, column] == (int)Rocket.Mode.Up)
                    {
                        gridElements = "\u25b2";
                    }
                    if (grid[row, column] == (int)Rocket.Mode.Down)
                    {
                        gridElements = "\u25bc";
                    }

                    Console.Write($"   {gridElements}");
                  
                }
                Console.WriteLine();//Skips a line to print another set of numbers in line on the next iteraction
            }
        }

        /// <summary>
        /// Prints a Won or Lose to the players
        /// </summary>
        /// <param name="resValidation">True or False</param>
        /// <param name="index">Index number</param>
        /// <param name="rowCol">Row or Column words</param>
        public static void PrintWinLoseMsg(int cashSum)
        {
            if (cashSum > 0)
            {
                Console.WriteLine($"\nYou WIN!!!\nTotal ${cashSum}");
            }
            else
            {
                Console.WriteLine($"\nYou LOSE!!!");
            }

        }

        /// <summary>
        /// It asks the player whether they want to continue or not
        /// </summary>
        /// <returns>Yes or No response</returns>
        public static bool AskToContinueGame()
        {
            Console.Write("\nWould you like to make a new bet? Y/N\nEnter: ");

            if (Console.ReadKey().Key == ConsoleKey.Y) //YES response
            {
                Console.WriteLine();
                return true;
            }
            else //NO response
            {
                Console.WriteLine();
                return false;
            }
                        
        }
    }

}
