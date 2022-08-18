﻿using System;

namespace P5_SlotMachine// Note: actual namespace depends on the project name.
{
	internal class Program
	{
		/// <summary>
		/// It generates a random number
		/// </summary>
		/// <returns>Int number from 1 to 9</returns>
		static int GetRandomNumber()
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
		static int[] CreateRowsAuxArray(int[,] array2D, int row)
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
		static int[] CreateColumnsAuxArray(int[,] array2D, int col)
        {
			int[] auxArray = new int[array2D.GetLength(1)];

			for (int row = 0; row <array2D.GetLength(1); row++)
            {
				auxArray[row] = array2D[row, col];
            }
			return auxArray;

        }

		static int[] CreateDiagonalAuxArray(int[,] array2D, int diag)
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
				for ( int item = 0; item < array2D.GetLength(1); item++)
				{
					auxArray[item] = array1D[i];
					i = i + 4;
				}
			}
			if (diag == 1)
			{
				i = 2;
				for(int item = 0; item < array2D.GetLength(1); item++)
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
		static bool CheckCombinations(int[] auxArray)
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



		static void Main(string[] args)
		{
			//Creates an instance of the SlotMachine Obejct and set values for its properties
			SlotMachine smObj = new SlotMachine();
			smObj.row = 3;
			smObj.column = 3;


			//Defines and initiates an array 2D - 3rows, 3colums.
			int[,] array2D = new int[smObj.row, smObj.column];

			//Nested loops to fill up the array with random numbers
			for (int row = 0; row < smObj.row; row++)
			{
				for (int column = 0; column < smObj.column; column++)
				{
					array2D[row, column] = GetRandomNumber(); //assigns a rdn number to each array item
				}
			}
			UI.PrintArraMatrix(array2D);

			//Separates the 2D array into smaller arrays 
			bool result;
			int[] auxArray;
			int countCash = 0;

			//Checks the array row elements similarities
			for (int row = 0; row < array2D.GetLength(0); row++)
            {
				auxArray = CreateRowsAuxArray(array2D, row);
				result = CheckCombinations(auxArray);
				
				if (result == true)
                {
					countCash = countCash + 1;
                }

				UI.PrintWinLose(result, row, "row");
			}


			//Checks the array column elements similarities
			for (int col = 0; col <array2D.GetLength(1); col++)
            {
				auxArray = CreateColumnsAuxArray(array2D, col);
				result = CheckCombinations(auxArray);

				if (result == true)
                {
					countCash = countCash + 1;
                }

				UI.PrintWinLose(result, col, "column"); 
            }

			//Checks the diagonal array elements similarities
			for (int diag = 0; diag < 2; diag++)
            {
				auxArray = CreateDiagonalAuxArray(array2D, diag);
				result = CheckCombinations(auxArray);

				if (result == true)
                {
					countCash = countCash + 1;
                }

				UI.PrintWinLose(result, diag, "diagonal");
            }






		}
	}
}