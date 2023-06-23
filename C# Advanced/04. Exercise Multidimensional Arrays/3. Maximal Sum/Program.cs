using System;
using System.Linq;

namespace _3._Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[,] matrix = new int[input[0], input[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] rowInput = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowInput[col];
                }
            }

            int startIndexOfRow = 0;
            int startIndexOfCol = 0;
            int sum = int.MinValue;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    int tempSumOfSubMatrix = 0;

                    if (row + 3 <= matrix.GetLength(0) && col + 3 <= matrix.GetLength(1))
                    {
                        for (int tempRow = row; tempRow < row + 3; tempRow++)
                        {
                            for (int tempCol = col; tempCol < col + 3; tempCol++)
                            {
                                tempSumOfSubMatrix += matrix[tempRow, tempCol];
                            }
                        }

                        if (tempSumOfSubMatrix > sum)
                        {
                            sum = tempSumOfSubMatrix;
                            startIndexOfRow = row;
                            startIndexOfCol = col;
                        }
                    }
                }
            }

            Console.WriteLine($"Sum = {sum}");

            for (int row = startIndexOfRow; row < startIndexOfRow + 3; row++)
            {
                for (int col = startIndexOfCol; col < startIndexOfCol + 3; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
