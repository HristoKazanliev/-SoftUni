using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Stack_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> stack = new Stack<int>(input);
            string command = Console.ReadLine().ToLower();

            while (command != "end")
            {
                string[] commandArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string splittedCommand = commandArgs[0];

                if (splittedCommand == "add")
                {
                    int firstNum = int.Parse(commandArgs[1]);
                    int secondNum = int.Parse(commandArgs[2]);

                    stack.Push(firstNum);
                    stack.Push(secondNum);
                }
                else if (splittedCommand == "remove")
                {
                    int count = int.Parse(commandArgs[1]);

                    if (count <= stack.Count)
                    {
                        for (int i = 0; i < count; i++)
                        {
                            stack.Pop();
                        }
                    }
                }

                command = Console.ReadLine().ToLower();
            }

            //int sum = stack.Sum();
            int sum = 0;
            while (stack.Count > 0)
            {
                sum += stack.Pop();
            }

            Console.WriteLine($"Sum: {sum}");
        }
    }
}
