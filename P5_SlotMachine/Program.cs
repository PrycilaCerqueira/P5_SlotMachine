using System;

namespace P5_SlotMachine// Note: actual namespace depends on the project name.
{
	internal class Program
	{
		static void Main(string[] args)
		{
			UI.PrintGameInstructions();
			int bet = UI.MakeYourBet(bet = 0);

			int[,] grid = new int[bet, 3]; //Defines and initiates an array 2D - 1 to 3 rows and 3 colums.
 			Logic.FillUpGrid(grid);
			UI.PrintGrid(grid);

			int cashSum = Logic.CheckGridElementSimilarities(bet, grid);
			
			while (cashSum != 0)
			{
				UI.PrintWinLose(cashSum);
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
			
					grid = new int[bet, 3];
					Logic.FillUpGrid(grid);
					UI.PrintGrid(grid);
					int cash = Logic.CheckGridElementSimilarities(bet, grid);
					cashSum = cashSum + cash;
				}
				else
				{
					UI.PrintWinLose(cashSum);
					Environment.Exit(0);
                }
			}
			UI.PrintWinLose(cashSum);

		}
	}
}
