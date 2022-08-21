using System;

namespace P5_SlotMachine// Note: actual namespace depends on the project name.
{
	internal class Program
	{
		static void Main(string[] args)
		{
			UI.PrintGame1stInstructions();
			int bet = UI.PrintMakeYourBet();

			int[,] array2D = new int[bet, 3]; //Defines and initiates an array 2D - 1 to 3 rows and 3 colums.
			Logic.FillUp2DArray(array2D);
			UI.PrintArrayMatrix(array2D);


			bool result;
			int[] lineArray;
			int cashSum = 0;

			/*TODO: CashCount to replay or not
					Improve WinLose print messages
					Imput error verifications
			*/
			switch (bet)
			{
				case 1:
				case 2:
					for (int rows = 0; rows < array2D.GetLength(0); rows++)
					{
						lineArray = Logic.CreateRows1DArray(array2D, rows);
						result = Logic.CheckCombinations(lineArray);
						//cashSum = Logic.CalcCash(result, cashSum);
						UI.PrintWinLose(result, rows, "row");
					}
					break;

				case 3:
					//Separates the 2D array into smaller arrays and checks the array row elements similarities
					for (int rows = 0; rows < array2D.GetLength(0); rows++)
					{
						lineArray = Logic.CreateRows1DArray(array2D, rows);
						result = Logic.CheckCombinations(lineArray);
						//cashSum = Logic.CalcCash(result, cashSum);
						UI.PrintWinLose(result, rows, "row");
					}

					//Separates the 2D array into smaller arrays and checks the array column elements similarities
					for (int columns = 0; columns < array2D.GetLength(1); columns++)
					{
						lineArray = Logic.CreateColumns1DArray(array2D, columns);
						result = Logic.CheckCombinations(lineArray);
						//cashSum = Logic.CalcCash(result, cashSum);
						UI.PrintWinLose(result, columns, "column");
					}

					//Separates the 2D array into smaller arrays and checks the diagonal array elements similarities
					for (int diagonals = 0; diagonals < 2; diagonals++)
					{
						lineArray = Logic.CreateDiagonal1DArray(array2D, diagonals);
						result = Logic.CheckCombinations(lineArray);
						//cashSum = Logic.CalcCash(result, cashSum);
						UI.PrintWinLose(result, diagonals, "diagonal");
					}
					break;
			}

		}
	}
}
