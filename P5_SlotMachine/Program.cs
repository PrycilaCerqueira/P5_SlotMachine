using System;
using System.Linq.Expressions;

namespace P5_SlotMachine// Note: actual namespace depends on the project name.
{
	internal class Program
	{
		static void Main(string[] args)
		{
            UI.PrintGameInstructions();

            do
			{
				int numOfRows = UI.MakeYourBet(); //bet dictates number of rows in grid

				string gridMoveStatus = "***Grid***";
				int[,] grid = Logic.CreateGrid(numOfRows);
				UI.PrintGrid(grid, gridMoveStatus);

				if (Logic.ShouldTheGridRotate(grid) == true)
				{
					gridMoveStatus = "*Rotated Grid*";
					grid = Logic.MoveGridElements(grid);
					UI.PrintGrid(grid, gridMoveStatus);
				}

				int cashSum = Logic.CheckGridSimilarElements(numOfRows, grid);

				while (cashSum != 0)
				{
					UI.PrintWinLoseMsg(cashSum);
					bool continuePlay = UI.AskToContinueGame();

					if (continuePlay == true)
					{
						if (cashSum > 4) //Calculates the new bet in case the player won more than $4. The limit per round is $3. 
						{
							int newBet = UI.MakeYourBet();
							cashSum = cashSum - newBet;
							numOfRows = newBet;
						}
						else
						{
							numOfRows = cashSum;
							cashSum = 0;
						}

						gridMoveStatus = "Original";
						grid = Logic.CreateGrid(numOfRows);
						UI.PrintGrid(grid, gridMoveStatus);

						if (Logic.ShouldTheGridRotate(grid) == true)
						{
							gridMoveStatus = "Rotated";
							grid = Logic.MoveGridElements(grid);
							UI.PrintGrid(grid, gridMoveStatus);
						}

						int cash = Logic.CheckGridSimilarElements(numOfRows, grid);
						cashSum = cashSum + cash;
					}
				}

				UI.PrintWinLoseMsg(cashSum);

			} while (UI.AskToContinueGame() == true);



		}
	}
}
