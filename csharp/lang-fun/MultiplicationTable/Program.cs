using System;

namespace MultiplicationTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] multiTable = new int[10,10];

            for (int i = 0; i < 10; i++)
            {
                for(int j = 0; j < 10; j++)
                {
                    multiTable[i,j] = ((j+1)*(i+1));
                }
            }
            // print array
            for (int i = 0; i < multiTable.GetLength(0); i++)
            {
                Console.Write("[  ");
                for (int j = 0; j < multiTable.GetLength(1); j++)
                {
                    if(j == 9)
                    {
                        Console.Write(multiTable[i,j]);
                    }
                    else
                    {
                        Console.Write(multiTable[i,j] + ",\t");
                    }
                }
                Console.Write(" ]");
                Console.WriteLine();
            }
        }
    }
}
