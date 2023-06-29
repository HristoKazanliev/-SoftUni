using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    public class Truck : Vehicle
    {
        private const double TruckConsumption = 1.6;
        private const double TruckRefill = 0.95;

        public Truck(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption)
        {
        }

        protected override double AdditionalConsumption => TruckConsumption;

        public override void Refuel(double liters)
        {
            base.Refuel(liters * TruckRefill);
        }
    }
}
