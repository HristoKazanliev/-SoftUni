using System;
using System.Collections.Generic;

namespace _08._Balanced_Parenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> parentheses = new Stack<char>();
            bool balanced = false;

            foreach (char bracket in input)
            {
                if (bracket == '{' || bracket == '(' || bracket == '[')
                {
                    parentheses.Push(bracket);
                }
                else if (bracket == '}' || bracket == ']' || bracket == ')')
                {
                    if (parentheses.Count == 0)
                    {
                        balanced = false;
                        break;
                    }

                    char lastOpen = parentheses.Pop();

                    if (lastOpen == '{' && bracket == '}')
                    {
                        balanced = true;
                    }
                    else if (lastOpen == '(' && bracket == ')')
                    {
                        balanced = true;
                    }
                    else if (lastOpen == '[' && bracket == ']')
                    {
                        balanced = true;
                    }
                    else
                    {
                        balanced = false;
                        break;
                    }
                }
            }

            if (balanced)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
