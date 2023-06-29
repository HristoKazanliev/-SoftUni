using System;

namespace _04.WildFarm
{
    using Core;
    using Factories;

    class Program
    {
        static void Main(string[] args)
        {
            IFoodFactory foodFactory = new FoodFactory();
            IAnimalFactory animalFactory = new AnimalFactory();

            IEngine engine = new Engine(foodFactory, animalFactory);
            engine.Start();
        }
    }
}
