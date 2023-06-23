using System;

namespace _7._Knight_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string rowInput = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowInput[col];
                }
            }

            int removedKnights = 0;

            while (true)
            {
                int maxAttacks = 0;
                int knightRow = 0;
                int knightCol = 0;

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (matrix[row, col] == '0')
                        {
                            continue;
                        }

                        int currAttacks = 0;
                        //upLeft and upRight
                        if (IsInRange(matrix, row - 2, col - 1) && matrix[row - 2, col - 1] == 'K')
                        {
                            currAttacks++;
                        }
                        if (IsInRange(matrix, row - 2, col + 1) && matrix[row - 2, col + 1] == 'K')
                        {
                            currAttacks++;
                        }

                        //downLeft and downRight
                        if (IsInRange(matrix, row + 2, col - 1) && matrix[row + 2, col - 1] == 'K')
                        {
                            currAttacks++;
                        }
                        if (IsInRange(matrix, row + 2, col + 1) && matrix[row + 2, col + 1] == 'K')
                        {
                            currAttacks++;
                        }

                        //leftUp and rightUp
                        if (IsInRange(matrix, row - 1, col - 2) && matrix[row - 1, col - 2] == 'K')
                        {
                            currAttacks++;
                        }
                        if (IsInRange(matrix, row - 1, col + 2) && matrix[row - 1, col + 2] == 'K')
                        {
                            currAttacks++;
                        }

                        //leftDown and rightDown
                        if (IsInRange(matrix, row + 1, col - 2) && matrix[row + 1, col - 2] == 'K')
                        {
                            currAttacks++;
                        }
                        if (IsInRange(matrix, row + 1, col + 2) && matrix[row + 1, col + 2] == 'K')
                        {
                            currAttacks++;
                        }

                        if (currAttacks > maxAttacks)
                        {
                            maxAttacks = currAttacks;
                            knightRow = row;
                            knightCol = col;
                        }
                    }
                }

                if (maxAttacks > 0)
                {
                    removedKnights++;
                    matrix[knightRow, knightCol] = '0';
                }
                else
                {
                    Console.WriteLine(removedKnights);
                    break;
                }
            }
        }

        private static bool IsInRange(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) &&
                    col >= 0 && col < matrix.GetLength(1);
        }
    }
}
