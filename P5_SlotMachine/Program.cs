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
				int auxIndex1 = i + 1;
				int auxIndex2 = i + 2;
								
				if (auxIndex1 < 3)
                {
					if (auxArray[i] == auxArray[auxIndex1])
					{
						Console.WriteLine($"They are the same {auxArray[i]} = {auxArray[auxIndex1]}");

					}
				}
				
				if (auxIndex2 < 3)
                {
					if (auxArray[i] == auxArray[auxIndex2])
					{
						Console.WriteLine($"They are the same {auxArray[i]} = {auxArray[auxIndex2]}");
					}

				}
				/*
				if (auxIndex1 < 3 && auxIndex2 < 3)
                {
					if (auxArray[auxIndex1] == auxArray[i] && auxArray[auxIndex2] == auxArray[i] && auxArray[auxIndex1] == auxArray[auxIndex2])
                    {
						Console.WriteLine("You win!!");
						break;
                    }
                }
				*/
				
				


			}
			
		}





		static void Main(string[] args)
		{
			//Creates an instance of the SlotMachine Obejct and set values for its properties
			SlotMachine smObj = new SlotMachine();
			smObj.row = 3;
			smObj.column = 3;


			//Defines and initiates an array 2D - 3rows, 3colums.
			int[,] array2D = new int[smObj.row, smObj.column];

			//Nested loops to fill up the array with random numbers
			for (int row = 0; row < smObj.row; row++)
			{
				for (int column = 0; column < smObj.column; column++)
				{
					array2D[row, column] = GetRandomNumber(); //assigns a rdn number to each array item
				}
			}
			UI.PrintArraMatrix(array2D);

			int[] auxArray = { 5, 5, 5 };
			Console.WriteLine($" {auxArray[0]} {auxArray[1]} {auxArray[2]}");

		            /*
			for (int col = 0; col < array2D.GetLength(0); col++)
			{
				auxArray[col] = array2D[0,col];
			}
			*/
            CheckRowsCombinatios(auxArray);

		

	}
}