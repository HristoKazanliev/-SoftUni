using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Factories
{
    using Models.Food;

    public class FoodFactory : IFoodFactory
    {
        public Food CreateFood(string type, int quantity)
        {
            if (type == "Fruit")
            {
                return new Fruit(quantity);
            }
            else if (type == "Meat")
            {
                return new Meat(quantity);
            }
            else if (type == "Seeds")
            {
                return new Seeds(quantity);
            }
            else if (type == "Vegetable")
            {
                return new Vegetable(quantity);
            }
            else
            {
                throw new ArgumentException("Invalid food!");
            } 
        }
    }
}
