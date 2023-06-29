using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Models.Animal.Mammals
{
    using _04.WildFarm.Models.Food;

    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override double WeightGainPerUnitOfFood => 0.10;

        public override void Eat(Food food)
        {
            if (!(food is Vegetable) && !(food is Fruit))
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
            base.Eat(food);
        }

        public override string ProduceSound()
        {
            return "Squeak";
        }
    }
}
