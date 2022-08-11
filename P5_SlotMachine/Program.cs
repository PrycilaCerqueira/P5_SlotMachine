using System;

namespace P5_SlotMachine// Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static int GetRandomNumber()
        {
            Random rnd = new Random();
            int num = rnd.Next(1, 10);
            return num;
        }
        static void Main(string[] args)
        {
            //Creates an instance of the SlotMachine Obejct and set values for its properties
            Obj_SlotMachine smObj = new Obj_SlotMachine();
            smObj.row = 3;
            smObj.column = 3;
            smObj.item = 1;

            //defines and initiates an array 3D - 3rows, 3colums, 1item.
            int[,,] array3D = new int [smObj.row, smObj.column, smObj.item];            
            
            //Nested loops to fill up the array with random numbers
            for (int row = 0 ; row < smObj.row; row++)
            {
                for (int column = 0; column < smObj.column; column++)
                {
                    for (int item = 0; item < smObj.item; item++) // This loop can be elimitated and use the direct index of 0.
                    {
                        array3D[row, column, item] = GetRandomNumber(); //assigns a rdn number to each array item
                    }
                }
            }
            UI.PrintArray3x3Matrix(array3D);
        }
    }
}