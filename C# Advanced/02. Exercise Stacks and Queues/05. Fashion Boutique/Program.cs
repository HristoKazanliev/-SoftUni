using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] clothesInBox = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> clothes = new Stack<int>(clothesInBox);
            int capacityOfRack = int.Parse(Console.ReadLine());

            int counterOfNeededRack = 1;
            int sum = 0;
            while (clothes.Count != 0)
            {
                sum += clothes.Peek();
                if (sum > capacityOfRack)
                {
                    sum = 0;
                    counterOfNeededRack++;
                    continue;
                }

                clothes.Pop();
            }

            Console.WriteLine(counterOfNeededRack);
        }
    }
}
