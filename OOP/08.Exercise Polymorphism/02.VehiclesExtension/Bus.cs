using System;
using System.Collections.Generic;
using System.Text;

namespace _02.VehiclesExtension
{
    public class Bus : Vehicle
    {
        private const double BusConsumption = 1.4;

        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        protected override double AdditionalConsumption => this.IsEmpty ? 0 : BusConsumption;
    }
}
