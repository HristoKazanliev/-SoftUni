using System;
using System.Collections.Generic;
using System.Text;

namespace _02.VehiclesExtension
{
    public abstract class Vehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;
        private double tankCapacity;

        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
            this.IsEmpty = false;
        }

        public double TankCapacity
        {
            get { return tankCapacity; }
            private set { tankCapacity = value; }
        }

        public double FuelQuantity
        {
            get
            { 
                return fuelQuantity; 
            }
            protected set 
            {
                if (value > TankCapacity)
                {
                    fuelQuantity = 0;
                }
                else
                {
                   fuelQuantity = value; 
                }
            }
        }

        public double FuelConsumption
        {
            get { return fuelConsumption; }
            private set { fuelConsumption = value; }
        }

        protected abstract double AdditionalConsumption { get; }

        public bool IsEmpty { get; set; }

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
            if (liters <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }
            else if (FuelQuantity + liters > tankCapacity)
            {
                throw new ArgumentException($"Cannot fit {liters} fuel in the tank");
            }

            FuelQuantity += liters;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
