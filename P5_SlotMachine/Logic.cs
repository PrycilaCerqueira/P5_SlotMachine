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
		/// It generates a random number
		/// </summary>
		/// <returns>Int number from 1 to 9</returns>
		public static int GetRandomNumber()
		{
			Random rnd = new Random();
			int num = rnd.Next(1, 10);
			return num;
		}

		/// <summary>
		/// It creates a auxiliar 1D array 
		/// </summary>
		/// <param name="array2D">Two dimensions array</param>
		/// <param name="row">Number of rows</param>
		/// <returns>1 dimension array</returns>
		public static int[] CreateRowsAuxArray(int[,] array2D, int row)
		{
			int[] auxArray = new int[array2D.GetLength(0)];

			for (int col = 0; col < array2D.GetLength(0); col++)
			{
				auxArray[col] = array2D[row, col];
			}
			return auxArray;
		}

		/// <summary>
		/// It creates a auxiliar 1D array 
		/// </summary>
		/// <param name="array2D">Two dimensions array</param>
		/// <param name="col">Number of columns</param>
		/// <returns>1 dimension array</returns>
		public static int[] CreateColumnsAuxArray(int[,] array2D, int col)
		{
			int[] auxArray = new int[array2D.GetLength(1)];

			for (int row = 0; row < array2D.GetLength(1); row++)
			{
				auxArray[row] = array2D[row, col];
			}
			return auxArray;

		}

		/// <summary>
		/// It creates a auxiliar 1D array 
		/// </summary>
		/// <param name="array2D">Two dimensions array</param>
		/// <param name="diag">Number of diagonals</param>
		/// <returns>1 dimension array</returns>
		public static int[] CreateDiagonalAuxArray(int[,] array2D, int diag)
		{
			int[] auxArray = new int[array2D.GetLength(1)];
			int[] array1D = new int[9];
			int i = 0;

			//Flattening the array 2D to 1D
			for (int row = 0; row < array2D.GetLength(0); row++)
			{
				for (int col = 0; col < array2D.GetLength(1); col++)
				{
					array1D[i++] = array2D[row, col];
				}
			}

			if (diag == 0)
			{
				i = 0;
				for (int item = 0; item < array2D.GetLength(1); item++)
				{
					auxArray[item] = array1D[i];
					i = i + 4;
				}
			}

			if (diag == 1)
			{
				i = 2;
				for (int item = 0; item < array2D.GetLength(1); item++)
				{
					auxArray[item] = array1D[i];
					i = i + 2;
				}
			}
			return auxArray;

		}


		/// <summary>
		/// It verifies if the array elements are the same 
		/// </summary>
		/// <param name="auxArray">Int array of 3 elements</param>
		/// <returns>True or False</returns>
		public static bool CheckCombinations(int[] auxArray)
		{
			if (auxArray[0] == auxArray[1] && auxArray[0] == auxArray[2])
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
		/// <param name="resValidation">True or False</param>
		/// <param name="cash">Int cash</param>
		/// <returns>The accumulated cash</returns>
		public static int CalcCash(bool resValidation, int cash)
		{
			if (resValidation == true)
			{
				cash = cash + 1;
			}
			return cash;
		}



	}

}
