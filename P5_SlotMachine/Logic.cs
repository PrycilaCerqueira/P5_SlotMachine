using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P5_SlotMachine
{
    public class Logic
    {
		/// <summary>
		/// Nested loops to fill up the array with random numbers
		/// </summary>
		/// <param name="grid">Array [n,n]</param>
		/// <returns> Filled up array</returns>
		public static int[,] FillUpGrid(int[,] grid)
        {
			
			for (int row = 0; row < grid.GetLength(0); row++)
			{
				for (int column = 0; column < grid.GetLength(1); column++)
				{
					Random rnd = new Random();
					int num = rnd.Next(1, 12);

					grid[row, column] = num; //assigns a rdn number to each array item

				}
			}
			return grid;
		}

		public static int[,] MoveGridElements(int[,] grid)
        {
			int[,] newGrid = new int[grid.GetLength(0), grid.GetLength(1)];

			for (int column = 0; column < grid.GetLength(1); column++)
			{
				for (int row = 0; row < grid.GetLength(0); row++)
				{
					if ()
				}
			}

			return newGrid;
        }

		/// <summary>
		/// It creates a auxiliary 1D array 
		/// </summary>
		/// <param name="grid">Two dimensions array</param>
		/// <param name="row">Number of rows</param>
		/// <returns>One dimension array</returns>
		public static int[] CreateRowsGrid(int[,] grid, int row)
		{
			int[] newGrid = new int[grid.GetLength(1)];

			for (int col = 0; col < grid.GetLength(1); col++)
			{
				newGrid[col] = grid[row, col];
			}
			return newGrid;
		}

		/// <summary>
		/// It creates a auxiliary 1D array 
		/// </summary>
		/// <param name="grid">Two dimensions array</param>
		/// <param name="col">Number of columns</param>
		/// <returns>One dimension array</returns>
		public static int[] CreateColumnsGrid(int[,] grid, int col)
		{
			int[] newGrid = new int[grid.GetLength(1)];

			for (int row = 0; row < grid.GetLength(1); row++)
			{
				newGrid[row] = grid[row, col];
			}
			return newGrid;

		}

		/// <summary>
		/// It creates a auxiliary 1D array 
		/// </summary>
		/// <param name="grid">Two dimensions array</param>
		/// <param name="diag">Number of diagonals</param>
		/// <returns>One dimension array</returns>
		public static int[] CreateDiagonalGrid(int[,] grid, int diag)
		{
			int[] newGrid = new int[grid.GetLength(1)];
								
			for (int row = 0; row < grid.GetLength(0); row++)
			{
				for (int col = 0; col < grid.GetLength(1); col++)
				{ 
					if (diag == 0 && row == col)
					{
						newGrid[row] = grid[row, col];
					}
					else if (diag == 1 && row + col == grid.GetLength(1) - 1)
                    {
						newGrid[row] = grid[row, col];
                    }
				}
			}
			
			return newGrid;
		}


		/// <summary>
		/// It verifies if the array elements are the same 
		/// </summary>
		/// <param name="newGrid">Int array of 3 elements</param>
		/// <returns>True or False</returns>
		public static bool ConfirmEqualityOfElements(int[] newGrid)
		{
			if (newGrid[0] == newGrid[1] && newGrid[0] == newGrid[2])
			{
				return true;
			}
			else
			{
				return false;
			}

		}

		/// <summary>
		/// It calculates the total amount of cash earned in the game
		/// </summary>
		/// <param name="result">True or False</param>
		/// <param name="cash">Int cash</param>
		/// <returns>The accumulated cash</returns>
		public static int CalcCash(bool result, int cash)
		{
			if (result == true)
			{
				cash = cash + 1;
			}
			return cash;
		}

		/// <summary>
		/// It checks the arrays elements similarities
		/// </summary>
		/// <param name="bet">Int bet </param>
		/// <param name="grid">Array 2D</param>
		/// <returns>Int cashSum</returns>
		public static int CheckGridSimilarElements(int bet, int[,] grid)
        {
			bool result;
			int[] newGrid = new int[3];
			int cashSum = 0;

			//Check ROWS elements similarities
			for (int rows = 0; rows < bet; rows++)
			{
				newGrid = CreateRowsGrid(grid, rows);
				result = ConfirmEqualityOfElements(newGrid);
				cashSum = CalcCash(result, cashSum);
			}

			if (bet > 2)
			{
				//Check COLUMNS elements similarities
				for (int columns = 0; columns < grid.GetLength(1); columns++)
				{
					newGrid = CreateColumnsGrid(grid, columns);
					result = ConfirmEqualityOfElements(newGrid);
					cashSum = CalcCash(result, cashSum);
				}

				//Check DIAGONAL array elements similarities
				for (int diagonals = 0; diagonals < 2; diagonals++)
				{
					newGrid = CreateDiagonalGrid(grid, diagonals);
					result = ConfirmEqualityOfElements(newGrid);
					cashSum = CalcCash(result, cashSum);
				}
			}
			return cashSum;

		}

	}

}
