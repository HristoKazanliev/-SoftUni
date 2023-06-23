using System;
using System.Linq;

namespace _2._Squares_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            char[,] matrix = new char[input[0], input[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] rowInput = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowInput[col];
                }
            }

            int countOfEqualCells = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (row + 2 <= matrix.GetLength(0) && col + 2 <= matrix.GetLength(1))
                    {
                        int currCharacter = matrix[row, col];
                        if (currCharacter == matrix[row + 1, col] &&
                            currCharacter == matrix[row, col + 1] &&
                            currCharacter == matrix[row + 1, col + 1])
                        {
                            countOfEqualCells++;
                        }
                    }
                }
            }

            Console.WriteLine(countOfEqualCells);
        }
    }
}
