using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.PlayCatch
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int countOfExceptions = 0;
            while (countOfExceptions != 3)
            {
                string[] commands = Console.ReadLine().Split();
                string action = commands[0];

                try
                {
                    if (action == "Replace")
                    {
                        int index = int.Parse(commands[1]);
                        int element = int.Parse(commands[2]);

                        numbers[index] = element;
                    }
                    else if (action == "Print")
                    {
                        int startIndex = int.Parse(commands[1]);
                        int endIndex = int.Parse(commands[2]);

                        List<int> numbersToPrint = new List<int>();
                        for (int i = startIndex; i <= endIndex; i++)
                        {
                            numbersToPrint.Add(numbers[i]);
                        }

                        Console.WriteLine(string.Join(", ", numbersToPrint));
                    }
                    else if (action == "Show")
                    {
                        int index = int.Parse(commands[1]);
                        Console.WriteLine(numbers[index]);
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("The variable is not in the correct format!");
                    countOfExceptions++;
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("The index does not exist!");
                    countOfExceptions++;
                }
            }

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
