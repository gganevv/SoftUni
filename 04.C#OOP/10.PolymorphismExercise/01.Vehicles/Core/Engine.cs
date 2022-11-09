namespace Vehicles.Core
{
    using System.Linq;
    using System.Collections.Generic;

    using Interfaces;
    using Factories.Interfaces;
    using IO.Interfaces;
    using Models.Interfaces;
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
            :this()
        {
            this.reader = reader;
            this.writer = writer;
            this.vehicleFactory = vehicleFactory;
        }
        public void Run()
        {
            CreateVehicles();
            int numberOfCommands = int.Parse(reader.ReadLine());
            for (int i = 0; i < numberOfCommands; i++)
            {
                ProcessCommand();
            }

            foreach (var vehicle in vehicles)
            {
                writer.WriteLine(vehicle.ToString());
            }

        }

        private void CreateVehicles()
        {
            string[] carInfo = reader.ReadLine().Split();
            string[] truckInfo = reader.ReadLine().Split();
            vehicles.Add(vehicleFactory.CreateVehicle(carInfo[0], double.Parse(carInfo[1]), double.Parse(carInfo[2])));
            vehicles.Add(vehicleFactory.CreateVehicle(truckInfo[0], double.Parse(truckInfo[1]), double.Parse(truckInfo[2])));
        }

        private void ProcessCommand()
        {
            string[] inputArgs = reader.ReadLine().Split(" ");
            string command = inputArgs[0];
            string type = inputArgs[1];
            double argument = double.Parse(inputArgs[2]);
            IVehicle vehicle = vehicles.FirstOrDefault(x => x.GetType().Name == type);
            if (command == "Drive")
            {
                writer.WriteLine(vehicle.Drive(argument));
            }
            else if (command == "Refuel")
            {
                vehicle.Refuel(argument);
            }
        }
    }
}
