using _04.WildFarm.Models.Animal;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Factories
{
    public interface IAnimalFactory
    {
        Animal CreateAnimal(params string[] data);
    }
}
