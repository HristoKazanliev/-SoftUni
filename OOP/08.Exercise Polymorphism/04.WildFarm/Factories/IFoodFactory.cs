using _04.WildFarm.Models.Food;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Factories
{
    public interface IFoodFactory
    {
        Food CreateFood(string type, int quantity);
    }
}
