using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Models.Food
{
    public abstract class Food
    {
        protected Food(int quantity)
        {
            this.Quantity = quantity;
        }

        public int Quantity { get; }
    }
}
