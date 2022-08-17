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
        /// Prints an array in a 3x3 matrix shape
        /// </summary>
        /// <param name="array2D">Integer array [3,3] </param>
        public static void PrintArraMatrix(int[,] array2D)
        {
            for (int row = 0; row < array2D.GetLength(0); row++) //GetLength(<dimension>) returns the number of array items for each dimension (row = 3)
            {
                for (int column = 0; column < array2D.GetLength(1); column++) //GetLength(<dimension>) returns (colmns = 3)
                {
                    Console.Write($"  {array2D[row, column]}"); //Print the numbers in line sepated by a space
                }
                Console.WriteLine();//Skips a line to print another set of numbers in line on the next iteraction
            }
        }

        public static void PrintWinLose(bool resValidation, int iteraction, string rowCol)
        {
            if (resValidation == true)
            {
                Console.WriteLine($"All numbers are the same in {rowCol} {iteraction+1}.");
            }
            else
            {
                Console.WriteLine($"Not all numbers are the same in {rowCol} {iteraction+1}.");
            }

        }
    }

}
