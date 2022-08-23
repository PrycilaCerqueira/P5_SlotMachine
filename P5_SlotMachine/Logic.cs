using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P5_SlotMachine
{
    public class Logic
    {
		/// <summary>
		/// Nested loops to fill up the array with random numbers
		/// </summary>
		/// <param name="array2D">Array [n,n]</param>
		/// <returns> Filled up array</returns>
		public static int[,] FillUp2DArray(int[,] array2D)
        {
			
			for (int row = 0; row < array2D.GetLength(0); row++)
			{
				for (int column = 0; column < array2D.GetLength(1); column++)
				{
					Random rnd = new Random();
					int num = rnd.Next(1, 10);

					array2D[row, column] = num; //assigns a rdn number to each array item
				}
			}
			return array2D;
		}

		/// <summary>
		/// It creates a auxiliary 1D array 
		/// </summary>
		/// <param name="array2D">Two dimensions array</param>
		/// <param name="row">Number of rows</param>
		/// <returns>One dimension array</returns>
		public static int[] CreateRows1DArray(int[,] array2D, int row)
		{
			int[] array1D = new int[array2D.GetLength(1)];

			for (int col = 0; col < array2D.GetLength(1); col++)
			{
				array1D[col] = array2D[row, col];
			}
			return array1D;
		}

		/// <summary>
		/// It creates a auxiliary 1D array 
		/// </summary>
		/// <param name="array2D">Two dimensions array</param>
		/// <param name="col">Number of columns</param>
		/// <returns>One dimension array</returns>
		public static int[] CreateColumns1DArray(int[,] array2D, int col)
		{
			int[] array1D = new int[array2D.GetLength(1)];

			for (int row = 0; row < array2D.GetLength(1); row++)
			{
				array1D[row] = array2D[row, col];
			}
			return array1D;

		}

		/// <summary>
		/// It creates a auxiliary 1D array 
		/// </summary>
		/// <param name="array2D">Two dimensions array</param>
		/// <param name="diag">Number of diagonals</param>
		/// <returns>One dimension array</returns>
		public static int[] CreateDiagonal1DArray(int[,] array2D, int diag)
		{
			int[] array1D = new int[array2D.GetLength(1)];
								
			for (int row = 0; row < array2D.GetLength(0); row++)
			{
				for (int col = 0; col < array2D.GetLength(1); col++)
				{ 
					if (diag == 0 && row == col)
					{
						array1D[row] = array2D[row, col];
					}
					else if (diag == 1 && row + col == array2D.GetLength(1) - 1)
                    {
						array1D[row] = array2D[row, col];
                    }
				}
			}
			
			return array1D;
		}


		/// <summary>
		/// It verifies if the array elements are the same 
		/// </summary>
		/// <param name="array1D">Int array of 3 elements</param>
		/// <returns>True or False</returns>
		public static bool CheckCombinations(int[] array1D)
		{
			if (array1D[0] == array1D[1] && array1D[0] == array1D[2])
			{
				return true;
			}
			else
			{
				return false;
			}

		}

		/// <summary>
		/// It calculates the total amount of cash earned in the game
		/// </summary>
		/// <param name="result">True or False</param>
		/// <param name="cash">Int cash</param>
		/// <returns>The accumulated cash</returns>
		public static int CalcCash(bool result, int cash)
		{
			if (result == true)
			{
				cash = cash + 1;
			}
			return cash;
		}



	}

}
