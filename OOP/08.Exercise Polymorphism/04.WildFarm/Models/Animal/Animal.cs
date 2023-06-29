using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Models.Animal
{
    using _04.WildFarm.Models.Food;

    public abstract class Animal
    {
        protected Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        public string Name { get; }

        public double Weight { get; protected set; }

        public int FoodEaten { get; protected set; } 

        public abstract double WeightGainPerUnitOfFood { get; }

        public abstract string ProduceSound();

        public virtual void Eat(Food food)
        {
            Weight += WeightGainPerUnitOfFood * food.Quantity;
            FoodEaten += food.Quantity;
        }
    }
}
