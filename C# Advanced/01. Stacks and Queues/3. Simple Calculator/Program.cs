using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Simple_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Reverse().ToArray();
            Stack<string> stack = new Stack<string>(input);

            while (stack.Count > 1)
            {
                int firstNumber = int.Parse(stack.Pop());
                string operation = stack.Pop();
                int secondNumber = int.Parse(stack.Pop());

                if (operation == "+")
                {
                    stack.Push((firstNumber + secondNumber).ToString());
                }
                else if (operation == "-")
                {
                    stack.Push((firstNumber - secondNumber).ToString());
                }
            }

            Console.WriteLine(stack.Peek());
        }
    }
}
