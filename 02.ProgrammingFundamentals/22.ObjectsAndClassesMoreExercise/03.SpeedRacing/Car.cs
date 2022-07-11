using System;

namespace _03.SpeedRacing
{
    public class Car
    {
        public Car(string model, double fuel, double consumption)
        {
            Model = model;
            Fuel = fuel;
            Consumption = consumption;
            TraveledDistance = 0;
        }

        public string Model { get; set; }
        public double Fuel { get; set; }
        public double Consumption { get; set; }
        public int TraveledDistance { get; set; }

        public void Drive(int distance)
        {
            if (Fuel - (distance * Consumption) >= 0)
            {
                Fuel -= distance * Consumption;
                TraveledDistance += distance;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }

        public override string ToString()
        {
            return $"{Model} {Fuel:f2} {TraveledDistance}";
        }
    }
}
