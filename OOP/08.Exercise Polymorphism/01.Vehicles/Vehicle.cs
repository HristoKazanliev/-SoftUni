using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    public abstract class Vehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;

        protected Vehicle(double fuelQuantity, double fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity
        {
            get { return fuelQuantity; }
            private set { fuelQuantity = value; }
        }

        public double FuelConsumption
        {
            get { return fuelConsumption; }
            private set { fuelConsumption = value; }
        }

        protected abstract double AdditionalConsumption { get; }

        public string Drive(double kilometers)
        {
            double fuelConsumed = (this.FuelConsumption + AdditionalConsumption) * kilometers;
            if (fuelConsumed <= FuelQuantity)
            {
                FuelQuantity -= fuelConsumed;
                return $"{this.GetType().Name} travelled {kilometers} km";
            }
            else
            {
                return $"{this.GetType().Name} needs refueling";
            }
        }

        public virtual void Refuel(double liters)
        {
            FuelQuantity += liters;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
