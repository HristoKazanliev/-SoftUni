using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodShortage
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, IBuyer> buyers = new Dictionary<string, IBuyer>();
            IBuyer buyer = null;

            int numberOfPeople = int.Parse(Console.ReadLine());
            FillList(numberOfPeople, buyer, buyers);
            
            string buyerName = Console.ReadLine();
            while (buyerName != "End")
            {
                if (buyers.ContainsKey(buyerName))
                {
                    buyers[buyerName].BuyFood();
                }

                buyerName = Console.ReadLine();
            }

            int totalAmountOfFood = buyers.Values.Sum(x => x.Food);
            Console.WriteLine(totalAmountOfFood);
        }

        private static void FillList(int n, IBuyer buyer, Dictionary<string, IBuyer> buyers)
        {
            for (int i = 0; i < n; i++)
            {
                string[] buyersFromInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = buyersFromInput[0];

                if (buyersFromInput.Length == 4)
                {
                    int age = int.Parse(buyersFromInput[1]);
                    string id = buyersFromInput[2];
                    string birthdate = buyersFromInput[3];

                    buyer = new Citizen(name, age, id, birthdate);
                }
                else
                {
                    int age = int.Parse(buyersFromInput[1]);
                    string group = buyersFromInput[2];

                    buyer = new Rebel(name, age, group);
                }

                buyers[name] = buyer;
            }
        }
    }
}
