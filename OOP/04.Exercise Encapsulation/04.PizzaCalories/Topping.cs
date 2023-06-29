using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private Dictionary<string, double> typeOfToppingCalories = new Dictionary<string, double>
        {
            {"meat", 1.2},
            {"veggies", 0.8},
            {"cheese", 1.1},
            {"sauce", 0.9},
        };

        private const int CaloriesPerGram = 2;

        private string type;
        private double weight;

        public Topping(string type, double weight)
        {
            Type = type;
            Weight = weight;
        }

        public string Type
        {
            get 
            { 
                return type;
            }
            private set 
            {
                if (!typeOfToppingCalories.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                type = value;
            }
        }


        public double Weight
        {
            get 
            { 
                return weight;
            }
            private set 
            {
                if (value<1|| value>50)
                {
                    throw new ArgumentException($"{this.type} weight should be in the range [1..50].");
                }
                weight = value;
            }
        }

        public double Calories
            => 2 * Weight * typeOfToppingCalories[this.Type.ToLower()];
    }
}
