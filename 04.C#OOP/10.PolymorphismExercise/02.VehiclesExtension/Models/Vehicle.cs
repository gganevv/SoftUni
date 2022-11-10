using System;
using Vehicles.Models.Interfaces;

namespace _02._Vehicles_Extension
{
    public class Vehicle : IVehicle
    {

        public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            FuelConsumption = fuelConsumption;
            TankCapacity = tankCapacity;

            if (fuelQuantity <= tankCapacity)
                FuelQuantity = fuelQuantity;
        }

        public double FuelQuantity { get; set; }

        public double FuelConsumption { get; set; }

        public double TankCapacity { get; set; }

        public virtual string Drive(double distance)
        {
            double newFuelAmount = FuelQuantity - FuelConsumption * distance;
            if (newFuelAmount < 0)
                return $"{this.GetType().Name} needs refueling";
            else
            {
                FuelQuantity = newFuelAmount;
                return $"{this.GetType().Name} travelled {distance} km";
            }
        }

        public virtual void Refuel(double liters)
        {
            if (liters <= 0)
                Console.WriteLine("Fuel must be a positive number");
            else if (FuelQuantity + liters > TankCapacity)
                Console.WriteLine($"Cannot fit {liters} fuel in the tank");
            else
                FuelQuantity += liters;
        }

        public override string ToString()
        => $"{this.GetType().Name}: {FuelQuantity:f2}";
    }
}