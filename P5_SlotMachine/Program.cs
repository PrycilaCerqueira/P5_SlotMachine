using System;
using System.Linq.Expressions;

namespace P5_SlotMachine// Note: actual namespace depends on the project name.
{
	internal class Program
	{
		static void Main(string[] args)
		{
			UI.PrintGameInstructions();
			int bet = UI.MakeYourBet(bet = 0); //bet dictates number of rows in grid

			string gridMoveStatus = "Original";
            int[,] grid = Logic.CreateGrid(bet);
			UI.PrintGrid(grid, gridMoveStatus);


			gridMoveStatus = "Rotated";
			grid = Logic.MoveGridElements(grid);
			UI.PrintGrid(grid, gridMoveStatus);

			int cashSum = Logic.CheckGridSimilarElements(bet, grid);
			
			while (cashSum != 0)
			{
				UI.PrintWinLoseMsg(cashSum);
				bool continuePlay = UI.AskToContinueGame();
								
				if (continuePlay == true)
                {		
					if (cashSum > 4) //Calculates the new bet in case the player won more than $4. The limit per round is $3. 
					{
						int newBet = UI.MakeYourBet(newBet = 0);
						cashSum = cashSum - newBet;
						bet = newBet;
					}
                    else
                    {
						bet = cashSum;
						cashSum = 0;
					}

                    gridMoveStatus = "Original";
                    grid = Logic.CreateGrid(bet);
                    UI.PrintGrid(grid, gridMoveStatus);

					
					gridMoveStatus = "Rotated";
                    grid = Logic.MoveGridElements(grid);
                    UI.PrintGrid(grid, gridMoveStatus);

                    int cash = Logic.CheckGridSimilarElements(bet, grid);
					cashSum = cashSum + cash;
				}
				else
				{
					UI.PrintWinLoseMsg(cashSum);
					Environment.Exit(0);
                }
			}
			UI.PrintWinLoseMsg(cashSum);


		}
	}
}
