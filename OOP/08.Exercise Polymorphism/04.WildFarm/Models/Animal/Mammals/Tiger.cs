using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Models.Animal.Mammals
{
    using _04.WildFarm.Models.Food;

    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        public override double WeightGainPerUnitOfFood => 1.00;

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
            return "ROAR!!!";
        }
    }
}
