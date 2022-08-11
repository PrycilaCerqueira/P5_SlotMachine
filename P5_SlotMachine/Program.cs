using System;

namespace P5_SlotMachine// Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static int GetRandomNumber()
        {
            Random rnd = new Random();
            int num = rnd.Next(1, 11);
            return num;
        }
        static void Main(string[] args)
        {
            int[,,] array3D = new int [3, 3, 1]; //defined the my array 3D - 3rows, 3colums, 1item.           
            
            //Nested loops to fill up the array with random number
            for (int row = 0 ; row < 3; row++)
            {
                for (int column = 0; column < 3; column++)
                {
                    for (int item = 0; item < 1; item++) // This loop can be elimitated and use the direct index of 0.
                    {
                        array3D[row, column, item] = GetRandomNumber();
                    }
                }
            }

            UI.PrintArray3x3Matrix(array3D);
        }
    }
}