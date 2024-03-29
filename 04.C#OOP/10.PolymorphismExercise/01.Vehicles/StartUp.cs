﻿namespace Vehicles
{
    using Vehicles.Core;
    using Vehicles.Factories;
    using Vehicles.Factories.Interfaces;
    using Vehicles.IO;
    using Vehicles.IO.Interfaces;

    public class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IVehicleFactory vehicleFactory = new VehicleFactory();
            Engine engine = new Engine(reader, writer, vehicleFactory);
            engine.Run();
        }
    }
}
