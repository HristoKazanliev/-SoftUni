using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    public class Car : Vehicle
    {
        private const double CarConsumption = 0.9;

        public Car(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption)
        {
        }

        protected override double AdditionalConsumption => CarConsumption;
    }
}
