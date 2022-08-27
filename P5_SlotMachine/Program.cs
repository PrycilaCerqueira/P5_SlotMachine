using System;

namespace P5_SlotMachine// Note: actual namespace depends on the project name.
{
	internal class Program
	{
		static void Main(string[] args)
		{

			/*
			 * TODO: 
			 * Make it so that rows can have a rocket ship icon which can alter the result.
			 * If the rocket ship is pointing up, when the person lands on it it will move that wheel up 1 spot.
			 * If the rocket ship is pointing down, it will move the wheel down one slot.
			 */

			UI.PrintGameInstructions();
			int bet = UI.MakeYourBet(bet = 0);
			int[,] grid = new int[bet, 3]; //Defines and initiates an array 2D - 1 to 3 rows and 3 colums.
 			Logic.FillUpGrid(grid);
			
			
			UI.PrintGrid(grid);

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
			
					grid = new int[bet, 3];
					Logic.FillUpGrid(grid);
					UI.PrintGrid(grid);
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
