using System;
using System.Collections.Generic;
using System.Text;

namespace _02.VehiclesExtension
{
    public class Truck : Vehicle
    {
        private const double TruckConsumption = 1.6;
        private const double TruckRefill = 0.05;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        protected override double AdditionalConsumption => TruckConsumption;

        public override void Refuel(double liters)
        {
            base.Refuel(liters);
            FuelQuantity -= liters * TruckRefill;
        }
    }
}
