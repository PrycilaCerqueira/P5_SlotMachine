using System;

namespace P5_SlotMachine// Note: actual namespace depends on the project name.
{
	internal class Program
	{
		static void Main(string[] args)
		{
			/*TODO: CashCount to replay or not
					Improve WinLose print messages
					Imput error verifications
			*/

			UI.PrintGame1stInstructions();
			int bet = UI.MakeYourBet();

			int[,] array2D = new int[bet, 3]; //Defines and initiates an array 2D - 1 to 3 rows and 3 colums.
 			Logic.FillUp2DArray(array2D);
			UI.PrintArrayMatrix(array2D);

			int cashSum = Logic.CheckSimilarElements(bet, array2D);
			UI.PrintWinLose(cashSum);

			while (cashSum != 0)
            {
				bool yesNo = UI.AskToContinueGame(cashSum);

				if (yesNo == true)
                {
					bet = cashSum;
					array2D = new int[bet, 3];
					Logic.FillUp2DArray(array2D);
					UI.PrintArrayMatrix(array2D);
					cashSum = Logic.CheckSimilarElements(bet, array2D);

                }
			}
			UI.PrintWinLose(cashSum);

		}
	}
}
