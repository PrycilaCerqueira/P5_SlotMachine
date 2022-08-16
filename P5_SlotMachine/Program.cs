using System;

namespace P5_SlotMachine// Note: actual namespace depends on the project name.
{
	internal class Program
	{
		/// <summary>
		/// Generates a random number
		/// </summary>
		/// <returns>Int number from 1 to 9</returns>
		static int GetRandomNumber()
		{
			Random rnd = new Random();
			int num = rnd.Next(1, 10);
			return num;
		}

		
		static void CheckRowsCombinatios(int[] auxArray)
		{
			for (int i = 0; i < auxArray.GetLength(0); i++)
			{
				for (int j = 1; j < auxArray.GetLength(0); j++)
                {
                    if (i == j)
                    {
                        continue;
                    }
					if (auxArray[i] == auxArray[j])
					{
						Console.WriteLine($"They are the same {auxArray[i]} = {auxArray[j]}");

					}

				}
				
			}
		}
			

	
		

		static void Main(string[] args)
		{
			//Creates an instance of the SlotMachine Obejct and set values for its properties
			SlotMachine smObj = new SlotMachine();
			smObj.row = 3;
			smObj.column = 3;
			

			//Defines and initiates an array 2D - 3rows, 3colums.
			int[,] array2D = new int [smObj.row, smObj.column];            
			
			//Nested loops to fill up the array with random numbers
			for (int row = 0 ; row < smObj.row; row++)
			{
				for (int column = 0; column < smObj.column; column++)
				{
					array2D[row, column] = GetRandomNumber(); //assigns a rdn number to each array item
				}
			}
			UI.PrintArraMatrix(array2D);

			int[] auxArray = new int[3];
			for (int col = 0; col < array2D.GetLength(0); col++)
			{
				auxArray[col] = array2D[0,col];
			}
			CheckRowsCombinatios(auxArray);

		}

	}
}