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
        public static int[,] CreateGrid(int numberOfRows)
        {
            Random rnd = new Random();

            int[,] grid = new int[numberOfRows, 3]; //Defines and initiates an array 2D - 1 to 3 rows and 3 colums.
            for (int row = 0; row < grid.GetLength(0); row++)
            {
                for (int column = 0; column < grid.GetLength(1); column++)
                {
                    int num = rnd.Next(1, 10); //TODO: change range 1-10
                    grid[row, column] = num; //assigns a rdn number to each array item

                }
            }

            //TODO: Random location for the rocket (10 or 11). Use randim method
            int columnPosition = rnd.Next(0, 3);
            int rowPosition = rnd.Next(0, numberOfRows);
            int numReplacement = rnd.Next(10, 12);

            if (rowPosition != 0)
            {
                grid[rowPosition, columnPosition] = numReplacement;
            }
            
            return grid;
        }

        public static int[,] MoveGridElements(int[,] grid)
        {

            int[] currentColumn = new int[grid.GetLength(0)]; // array size is based on the number of rows

            for (int col = 0; col < grid.GetLength(1); col++) //iteration of the array is based on the number of columns
            {
                currentColumn = GetGridColumn(grid, col);

                int lastElement;
                int firstElement;
                int searchNum = 10; //rocket pointing up
                int index = Array.IndexOf(currentColumn, searchNum);
                if (index != -1)
                {
                    firstElement = grid[grid.GetLowerBound(0), col];  //get the frist element of current column
                    for (int row = grid.GetLowerBound(0); row < grid.GetUpperBound(0); row++)
                    {
                        grid[row,col] = grid[row + 1,col];
                    } 
                    grid[grid.GetUpperBound(0), col] = firstElement;
                }

                searchNum = 11; //rocket pointing down
                index = Array.IndexOf((currentColumn), searchNum);
                if (index != -1)
                {
                    lastElement = grid[grid.GetUpperBound(0),col];
                    for (int row = grid.GetUpperBound(0); row > grid.GetLowerBound(0); row--) //update 2D grid
                    {
                        grid[row,col] = grid[row - 1, col];
                    }
                    grid[grid.GetLowerBound(0), col] = lastElement;
                }
            }
            return grid;

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
        public static int[] GetGridColumn(int[,] grid, int col)
        {
            int[] newGrid = new int[grid.GetLength(0)];

            for (int row = 0; row < grid.GetLength(0); row++)
            {
                newGrid[row] = grid[row,col];
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
                for (int columns = 0; columns < grid.GetLength(0); columns++)
                {
                    newGrid = GetGridColumn(grid, columns);
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
