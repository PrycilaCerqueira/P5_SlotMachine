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
            int[,,] array3D = new int [3, 3, 3]; //defined the my array 3D
          
            for (int row = 0 ; row < 3; row++)
            {
                for (int column = 0; column < 3; column++)
                {
                    for (int item = 0; item < 3; item++)
                    {
                        array3D[row, column, item] = GetRandomNumber();
                    }
                }
            }

            foreach (int row in array3D)
            {
                Console.WriteLine(row);
            }
        }
    }
}