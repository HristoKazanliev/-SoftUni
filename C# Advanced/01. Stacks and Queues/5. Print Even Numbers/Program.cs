using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Print_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
            Queue<string> evenNumbers = new Queue<string>();

            for (int i = 0; i < input.Length; i++)
            {
                if (int.Parse(input[i]) % 2 ==0)
                {
                    evenNumbers.Enqueue(input[i]);
                }
            }

            string result = string.Join(", ", evenNumbers);
            Console.WriteLine(result);
        }
    }
}
