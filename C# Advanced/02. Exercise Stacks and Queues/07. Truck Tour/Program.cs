using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            int pumpsCount = int.Parse(Console.ReadLine());
            Queue<string> queue = new Queue<string>();

            for (int i = 0; i < pumpsCount; i++)
            {
                queue.Enqueue(Console.ReadLine());
            }

            for (int i = 0; i < pumpsCount; i++)
            {
                bool isSuccessfull = true;
                int currPetrolAmount = 0;

                for (int j = 0; j < pumpsCount; j++)
                {
                    int[] pumpData = queue.Dequeue().Split(" ").Select(int.Parse).ToArray();
                    queue.Enqueue(string.Join(" ", pumpData));

                    currPetrolAmount += pumpData[0];
                    currPetrolAmount -= pumpData[1];

                    if (currPetrolAmount < 0)
                    {
                        isSuccessfull = false;
                    }
                }

                if (isSuccessfull)
                {
                    Console.WriteLine(i);
                    break;
                }

                queue.Enqueue(queue.Dequeue());
            }
        }
    }
}
