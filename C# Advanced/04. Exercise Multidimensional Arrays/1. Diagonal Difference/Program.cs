using System;
using System.Linq;

namespace _1._Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeOfSquare = int.Parse(Console.ReadLine());
            int[,] matrix = new int[sizeOfSquare, sizeOfSquare];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] rowInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowInput[col];
                }
            }

            int sumPrimaryDiagonal = 0;
            int sumSecondaryDiagonal = 0;
            int tempCol = matrix.GetLength(1) - 1;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                sumPrimaryDiagonal += matrix[row, row];
                sumSecondaryDiagonal += matrix[row, tempCol];
                tempCol--;
            }

            Console.WriteLine($"{Math.Abs(sumPrimaryDiagonal - sumSecondaryDiagonal)}");
        }
    }
}
