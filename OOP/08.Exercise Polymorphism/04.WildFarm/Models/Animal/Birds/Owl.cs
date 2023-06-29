using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Models.Animal.Birds
{
    using _04.WildFarm.Models.Food;

    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override double WeightGainPerUnitOfFood => 0.25;

        public override void Eat(Food food)
        {
            if (!(food is Meat))
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
            base.Eat(food);
        }

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }
    }
}
