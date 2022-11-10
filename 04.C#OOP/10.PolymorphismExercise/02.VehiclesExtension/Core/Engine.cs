namespace Vehicles.Core
{
    using System.Linq;
    using System.Collections.Generic;

    using Interfaces;
    using Factories.Interfaces;
    using IO.Interfaces;
    using Models.Interfaces;
    using System;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IVehicleFactory vehicleFactory;
        private readonly ICollection<IVehicle> vehicles;

        private Engine()
        {
            this.vehicles = new HashSet<IVehicle>();
        }

        public Engine(IReader reader, IWriter writer, IVehicleFactory vehicleFactory)
            : this()
        {
            this.reader = reader;
            this.writer = writer;
            this.vehicleFactory = vehicleFactory;
        }
        public void Run()
        {

            CreateVehicles();
            int numberOfCommands = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfCommands; i++)
            {
                ProcessCommand();
            }
            foreach (var vehicle in vehicles)
            {
                Console.WriteLine(vehicle.ToString());
            }

        }

        private void CreateVehicles()
        {

            string[] carInfo = reader.ReadLine().Split();
            vehicles.Add(vehicleFactory.CreateVehicle(carInfo[0], double.Parse(carInfo[1]), double.Parse(carInfo[2]), double.Parse(carInfo[3])));

            string[] truckInfo = reader.ReadLine().Split();
            vehicles.Add(vehicleFactory.CreateVehicle(truckInfo[0], double.Parse(truckInfo[1]), double.Parse(truckInfo[2]), double.Parse(truckInfo[3])));

            string[] busInfo = reader.ReadLine().Split();
            vehicles.Add(vehicleFactory.CreateVehicle(busInfo[0], double.Parse(busInfo[1]), double.Parse(busInfo[2]), double.Parse(busInfo[3])));
        }

        private void ProcessCommand()
        {
            string[] tokens = Console.ReadLine().Split();
            string command = tokens[0];
            string type = tokens[1];
            double value = double.Parse(tokens[2]);
            IVehicle vehicle = vehicles.First(x => x.GetType().Name == type);

            if (command == "Drive")
            {
                writer.WriteLine(vehicle.Drive(value));
            }
            else if (command == "Refuel")
            {
                vehicle.Refuel(value);
            }
            else if (command == "DriveEmpty")
            {
                ((Bus)vehicle).DriveEmpty(value);
            }
        }
    }
}