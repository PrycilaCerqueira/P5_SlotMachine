using System;

namespace P5_SlotMachine// Note: actual namespace depends on the project name.
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//TODO: Imput error verifications
			//Verify if the player is enetring a number and not a letter

			int bet = 0;
			UI.PrintGame1stInstructions();
			bet = UI.MakeYourBet(bet);

			int[,] array2D = new int[bet, 3]; //Defines and initiates an array 2D - 1 to 3 rows and 3 colums.
 			Logic.FillUp2DArray(array2D);
			UI.PrintArrayMatrix(array2D);

			int cashSum = Logic.CheckSimilarElements(bet, array2D);
			
			while (cashSum != 0)
			{
				UI.PrintWinLose(cashSum);
				bool yesNo = UI.AskToContinueGame();
								
				if (yesNo == true)
                {		
					if (cashSum > 4) //Calculates the new bet in case the player won more than $4. The limit per round is $3. 
					{
						int newBet = 0;
						newBet = UI.MakeYourBet(newBet);
						cashSum = cashSum - newBet;
						bet = newBet;
					}
                    else
                    {
						bet = cashSum;
					}
			
					array2D = new int[bet, 3];
					Logic.FillUp2DArray(array2D);
					UI.PrintArrayMatrix(array2D);
					int cash = Logic.CheckSimilarElements(bet, array2D);
					
					//TODO: If bet = cashSum, I cannot make the calc below
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
