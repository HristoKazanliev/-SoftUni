using System;
using System.Collections.Generic;

namespace _04.WildFarm.Core
{
    using _04.WildFarm.Factories;
    using Models.Animal;
    using Models.Food;

    public class Engine : IEngine
    {
        private readonly List<Animal> animals;
        private readonly IFoodFactory foodFactory;
        private readonly IAnimalFactory animalFactory;

        public Engine()
        {
            this.animals = new List<Animal>();
        }

        public Engine(IFoodFactory foodFactory, IAnimalFactory animalFactory)
           : this()
        {
            this.foodFactory = foodFactory;
            this.animalFactory = animalFactory;
        }

        public void Start()
        {
            string input = Console.ReadLine();
            while (input != "End")
            {
                try
                {
                    string[] animalArray = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    Animal animal = animalFactory.CreateAnimal(animalArray);

                    string[] foodArray = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    Food food = foodFactory.CreateFood(foodArray[0], int.Parse(foodArray[1]));

                    animals.Add(animal);
                    Console.WriteLine(animal.ProduceSound());
                    animal.Eat(food);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                input = Console.ReadLine();
            }

            foreach (var animal1 in animals)
            {
                Console.WriteLine(animal1);
            }
        }
    }
}
