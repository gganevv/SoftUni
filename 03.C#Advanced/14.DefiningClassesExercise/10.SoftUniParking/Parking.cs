using System.Collections.Generic;
using System.Linq;

namespace SoftUniParking
{
    public class Parking
    {
        private int capacity;
        private List<Car> cars;

        public Parking(int capacity)
        {
            this.capacity = capacity;
            cars = new List<Car>();
        }

        public int Count { get { return cars.Count; } }

        public string AddCar(Car car)
        {
            if (cars.Any(x => x.RegistrationNumber == car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }
            else if (cars.Count == this.capacity)
            {
                return "Parking is full!";
            }
            else
            {
                cars.Add(car);
                return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
            }
        }

        public Car GetCar(string registrationNumber)
        {
            return cars.FirstOrDefault(x => x.RegistrationNumber == registrationNumber);
        }

        public string RemoveCar(string registrationNumber)
        {
            if (!cars.Any(x => x.RegistrationNumber == registrationNumber))
            {
                return "Car with that registration number, doesn't exist!";
            }
            else
            {
                cars.Remove(cars.First(x => x.RegistrationNumber == registrationNumber));
                return $"Successfully removed {registrationNumber}";
            }
        }

        public void RemoveSetOfRegistrationNumber(List<string> RegistrationNumbers)
        {
            foreach (var regNumber in RegistrationNumbers)
            {
                RemoveCar(regNumber);
            }
        }
    }
}
