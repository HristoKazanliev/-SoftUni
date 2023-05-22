using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Songs_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ").ToArray();
            Queue<string> songs = new Queue<string>(input);

            while (songs.Count() != 0)
            {
                string command = Console.ReadLine();

                if (command.StartsWith("Play"))
                {
                    songs.Dequeue();
                }
                else if (command.StartsWith("Add"))
                {
                    string currSong = command.Substring(4);

                    if (songs.Contains(currSong))
                    {
                        Console.WriteLine($"{currSong} is already contained!");
                    }
                    else
                    {
                        songs.Enqueue(currSong);
                    }
                }
                else if (command.StartsWith("Show"))
                {
                    Console.WriteLine(string.Join(", ", songs));
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}
