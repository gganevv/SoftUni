using System;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main()
        {
            Car car = new Car();

            car.Make = "VW";
            car.Model = "MK3";
            car.Year = 1992;

            Console.WriteLine($"Make: {car.Make}\nModel: {car.Model}\nYear: {car.Year}");
        }
    }

    public class Car
    {
        private string make;
        private string model;
        private int year;

        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
    }
}
