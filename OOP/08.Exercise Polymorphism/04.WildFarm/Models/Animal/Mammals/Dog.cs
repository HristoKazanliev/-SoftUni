using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Models.Animal.Mammals
{
    using _04.WildFarm.Models.Food;

    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override double WeightGainPerUnitOfFood => 0.40;

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
            return "Woof!";
        }
    }
}
