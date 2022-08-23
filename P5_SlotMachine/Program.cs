using System;

namespace P5_SlotMachine// Note: actual namespace depends on the project name.
{
	internal class Program
	{
		static void Main(string[] args)
		{
			UI.PrintGame1stInstructions();
			int bet = UI.MakeYourBet();

			int[,] array2D = new int[bet, 3]; //Defines and initiates an array 2D - 1 to 3 rows and 3 colums.
            array2D[0,1] = 1;
			array2D[0,2] = 1;
            array2D[0,3] = 1;
			//Logic.FillUp2DArray(array2D);
			//UI.PrintArrayMatrix(array2D);


			bool result;
			int[] lineArray;
			int cashSum = 0;

			/*TODO: CashCount to replay or not
					Improve WinLose print messages
					Imput error verifications
			*/

			for (int rows = 0; rows < bet; rows++) //bet in this case is 1
			{
				lineArray = Logic.CreateRows1DArray(array2D, rows);
				result = Logic.CheckCombinations(lineArray);
				cashSum = Logic.CalcCash(result, cashSum);
				UI.PrintWinLose(result, rows, "row");
			}

			if (bet > 2)
			{
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
			}

			if (cashSum != 0)
            {
				UI.AskToContinueGame(cashSum);
            }

		}
	}
}
