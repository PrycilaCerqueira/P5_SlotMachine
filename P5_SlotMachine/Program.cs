using System;

namespace P5_SlotMachine// Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,,] array3D = new int [3, 3, 3]; //defined the my array 3D

            Random rnd = new Random();
            int num1 = rnd.Next(1, 11);
            int num2 = rnd.Next(1, 11);
            int num3 = rnd.Next(1, 11);

            for (int index = 0 ; index < 3; index++)
            {
                array3D[0,0,0] = num1;
                array3D[0,0,1] = num2;
                array3D[0,0,2] = num3;
            }


            string test = array3D.ToString();
            Console.Write(test);
        }
    }
}