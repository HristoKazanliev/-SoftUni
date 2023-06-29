using System;

namespace _08.CollectionHierarchy
{
    using Models;
    using Models.Interfaces;

    class Program
    {
        static void Main(string[] args)
        {
            string[] strings = Console.ReadLine().Split();
            int removeOperations = int.Parse(Console.ReadLine());

            IAddCollection<string> addCollection = new AddCollection<string>();
            IAddRemoveCollection<string> addRemoveCollection =new AddRemoveCollection<string>();
            IMyList<string> myList = new MyList<string>();

            AddToCollection(addCollection, strings);
            AddToCollection(addRemoveCollection, strings);
            AddToCollection(myList, strings);

            RemoveFromCollection(addRemoveCollection, removeOperations);
            RemoveFromCollection(myList, removeOperations);
        }

        private static void AddToCollection(IAddCollection<string> addCollection, string[] strings)
        {
            foreach (var @string in strings)
            {
                Console.Write(addCollection.Add(@string) + " ");
            }
            Console.WriteLine();
        }

        private static void RemoveFromCollection(IAddRemoveCollection<string> addRemoveCollection, int removeOperations)
        {
            for (int i = 0; i < removeOperations; i++)
            {
                Console.Write(addRemoveCollection.Remove() + " ");
            }
            Console.WriteLine();
        }
    }
}
