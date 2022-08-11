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
        /// <param name="array3D">Integer array [3,3,1] </param>
        public static void PrintArray3x3Matrix(int[,,] array3D)
        {
            //Nested FOR loops to create the 3x3 shape. 
            for (int row = 0; row < array3D.GetLength(0); row++) //GetLength(<dimension>) returns the number of array items for each dimension (row = 3)
            {
                for (int column = 0; column < array3D.GetLength(1); column++) //GetLength(<dimension>) returns (colmns = 3)
                {
                    for(int item = 0; item < array3D.GetLength(2); item++) //GetLength(<dimension>) returns (items = 1)
                    {
                       Console.Write($" {array3D[row, column, 0]}"); //Print the numbers in line sepated by a space
                    }
                }
                Console.WriteLine();//Skips a line to print another set of numbers in line on the next iteraction
            }
        }
    }
}
