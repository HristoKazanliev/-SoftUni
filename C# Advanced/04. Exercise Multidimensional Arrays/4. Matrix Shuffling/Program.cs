using System;
using System.Linq;

namespace _4._Matrix_Shuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = input[0];
            int cols = input[1];
            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] rowInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowInput[col];
                }
            }

            string command = Console.ReadLine();
            while (command != "END")
            {
                if (! IsValidCommand(command, rows, cols))
                {
                    Console.WriteLine("Invalid input!");
                    command = Console.ReadLine();
                    continue;
                }
                else
                {
                    string[] cmdArray = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                    int row1 = int.Parse(cmdArray[1]);
                    int col1 = int.Parse(cmdArray[2]);
                    int row2 = int.Parse(cmdArray[3]);
                    int col2 = int.Parse(cmdArray[4]);

                    string firstElement = matrix[row1, col1];
                    string secondElement = matrix[row2, col2];
                    matrix[row1, col1] = secondElement;
                    matrix[row2, col2] = firstElement;
                }

                PrintMatrix(matrix);

                command = Console.ReadLine();
            }
        }

        private static void PrintMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }

        private static bool IsValidCommand(string command, int rows, int cols)
        {
            string[] cmdArray = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            if (cmdArray[0] == "swap" && cmdArray.Length == 5)
            {
                int row1 = int.Parse(cmdArray[1]);
                int col1 = int.Parse(cmdArray[2]);
                int row2 = int.Parse(cmdArray[3]);
                int col2 = int.Parse(cmdArray[4]);

                if (row1 >= 0 && row1 < rows
                    && col1 >= 0 && col1 < cols
                    && row2 >= 0 && row2 < rows
                    && col2 >= 0 && col2 < cols)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
