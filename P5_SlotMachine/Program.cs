using System;

namespace P5_SlotMachine// Note: actual namespace depends on the project name.
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//Defines and initiates an array 2D - 3rows, 3colums.
			int[,] array2D = new int[3,3];

			//Nested loops to fill up the array with random numbers
			for (int row = 0; row < array2D.GetLength(0); row++)
			{
				for (int column = 0; column < array2D.GetLength(1); column++)
				{
					array2D[row, column] = Logic.GetRandomNumber(); //assigns a rdn number to each array item
				}
			}
			UI.PrintArraMatrix(array2D);

			
			bool result;
			int[] auxArray;
			int cashSum = 0;

			//Separates the 2D array into smaller arrays and checks the array row elements similarities
			for (int row = 0; row < array2D.GetLength(0); row++)
            {
				auxArray = Logic.CreateRowsAuxArray(array2D, row);
				result = Logic.CheckCombinations(auxArray);
				cashSum = Logic.CalcCash(result, cashSum);
				UI.PrintWinLose(result, row, "row");
			}

			//Separates the 2D array into smaller arrays and checks the array column elements similarities
			for (int col = 0; col <array2D.GetLength(1); col++)
            {
				auxArray = Logic.CreateColumnsAuxArray(array2D, col);
				result = Logic.CheckCombinations(auxArray);
				cashSum = Logic.CalcCash(result, cashSum);
				UI.PrintWinLose(result, col, "column"); 
            }

			//Separates the 2D array into smaller arrays and checks the diagonal array elements similarities
			for (int diag = 0; diag < 2; diag++)
            {
				auxArray = Logic.CreateDiagonalAuxArray(array2D, diag);
				result = Logic.CheckCombinations(auxArray);
				cashSum = Logic.CalcCash(result, cashSum);
				UI.PrintWinLose(result, diag, "diagonal");
            }






		}
	}
}