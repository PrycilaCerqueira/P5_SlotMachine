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

        
        static void CheckRowsCombinatios(int[,] array2D)
        {
            //int aux = array2D[0,0];
            
            if (array2D[0,0] == array2D[0,1])
            {
                    Console.WriteLine($" {array2D[0,0]} {array2D[0,1]}");
            }
            if (array2D[0,0] == array2D[0,2])
            {
                Console.WriteLine($" {array2D[0,0]} {array2D[0,2]}");
            }
            if (array2D[0,1] == array2D[0,2])
            {
                Console.WriteLine($" {array2D[0,1]} {array2D[0,2]}");
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
            CheckRowsCombinatios(array2D);

        }

    }
}