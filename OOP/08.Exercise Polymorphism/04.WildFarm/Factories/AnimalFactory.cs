using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Factories
{
    using Models.Animal;
    using Models.Animal.Mammals;
    using Models.Animal.Birds;
    using Core;

    public class AnimalFactory : IAnimalFactory
    {
        public Animal CreateAnimal(params string[] data)
        {
            string type = data[0];
            string name = data[1];
            double weight = double.Parse(data[2]);

            if (type == "Tiger")
            {
                string livingRegion = data[3];
                string breed = data[4];
                return new Tiger(name, weight, livingRegion, breed);
            }
            else if (type == "Cat")
            {
                string livingRegion = data[3];
                string breed = data[4];
                return new Cat(name, weight, livingRegion, breed);
            }
            else if (type == "Dog")
            {
                string livingRegion = data[3];
                return new Dog(name, weight, livingRegion);
            }
            else if (type == "Mouse")
            {
                string livingRegion = data[3];
                return new Mouse(name, weight, livingRegion);
            }
            else if (type == "Hen")
            {
                double wingSize = double.Parse(data[3]);
                return new Hen(name, weight, wingSize);
            }
            else if (type == "Owl")
            {
                double wingSize = double.Parse(data[3]);
                return new Owl(name, weight, wingSize);
            }
            else
            {
                throw new ArgumentException("Invalid animal!");
            }
            
        }
    }
}
