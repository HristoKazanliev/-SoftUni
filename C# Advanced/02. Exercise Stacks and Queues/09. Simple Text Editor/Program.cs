using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _09._Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            int operationCount = int.Parse(Console.ReadLine());
            StringBuilder sb = new StringBuilder();
            Stack<string> text = new Stack<string>();

            for (int i = 0; i < operationCount; i++)
            {
                string[] token = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                int command = int.Parse(token[0]);

                if (command == 1)
                {
                    text.Push(sb.ToString());
                    sb.Append(token[1]);
                }
                else if (command == 2)
                {
                    text.Push(sb.ToString());
                    int count = int.Parse(token[1]);
                    sb.Remove(sb.Length - count, count);
                }
                else if (command == 3)
                {
                    int index = int.Parse(token[1]);
                    Console.WriteLine(sb[index - 1]);
                }
                else if (command == 4)
                {
                    sb.Clear();
                    sb.Append(text.Pop());
                }
            }
        }
    }
}
