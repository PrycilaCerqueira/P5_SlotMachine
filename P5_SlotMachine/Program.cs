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

				int sumCash = Logic.CheckGridSimilarElements(numOfRows, grid);
				UI.PrintWinLoseMsg(sumCash);

			} while (UI.AskToContinueGame() == true);

		}
	}
}
