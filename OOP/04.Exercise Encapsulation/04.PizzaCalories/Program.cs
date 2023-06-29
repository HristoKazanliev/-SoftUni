using System;

namespace PizzaCalories
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] pizzaInfo = Console.ReadLine().Split(' ');
                string[] doughInfo = Console.ReadLine().Split(' ');

                string flourType = doughInfo[1];
                string bakingTechnique = doughInfo[2];
                double weight = double.Parse(doughInfo[3]);

                Dough dough = new Dough(flourType, bakingTechnique, weight);

                string pizzaName = pizzaInfo[1];
                Pizza pizza = new Pizza(pizzaName, dough);

                string input = Console.ReadLine();
                while (input!="END")
                {
                    string[] toppingInfo = input.Split();

                    string toppingType = toppingInfo[1];
                    double toppingWeight = double.Parse(toppingInfo[2]);
                    Topping topping = new Topping(toppingType, toppingWeight);
                    pizza.AddTopping(topping);

                    input = Console.ReadLine();
                }

                Console.WriteLine($"{pizza.Name} - {pizza.Calories:f2} Calories.");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

        }
    }
}
