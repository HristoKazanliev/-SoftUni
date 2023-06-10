using System;
using System.Linq;

namespace _6._Jagged_Array_Modification
{
    class Program
    {
        static void Main(string[] args)
        {
            int rowsCount = int.Parse(Console.ReadLine());
            int[][] jaggedArray = new int[rowsCount][];

            for (int row = 0; row < rowsCount; row++)
            {
                jaggedArray[row] = Console.ReadLine().Split().Select(int.Parse).ToArray();
            }

            string cmd = Console.ReadLine();
            while (cmd != "END")
            {
                string[] cmdArray = cmd.Split().ToArray();

                string action = cmdArray[0];
                int row = int.Parse(cmdArray[1]);
                int col = int.Parse(cmdArray[2]);
                int value = int.Parse(cmdArray[3]);

                if (row < 0 || row >= jaggedArray.Length || col < 0 || col >= jaggedArray[row].Length)
                {
                    Console.WriteLine($"Invalid coordinates");
                }
                else
                {
                    if (action == "Add")
                    {
                        jaggedArray[row][col] += value;
                    }
                    else if (action == "Subtract")
                    {
                        jaggedArray[row][col] -= value;
                    }
                }

                cmd = Console.ReadLine();
            }

            for (int row = 0; row < jaggedArray.Length; row++)
            {
                Console.WriteLine(String.Join(" ", jaggedArray[row]));
            }
        }
    }
}
