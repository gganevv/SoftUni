namespace Trucks.DataProcessor;

using Data;
using Newtonsoft.Json;
using Trucks.Data.Models.Enums;

public class Serializer
{
    public static string ExportDespatchersWithTheirTrucks(TrucksContext context)
    {
        throw new NotImplementedException();
    }

    public static string ExportClientsWithMostTrucks(TrucksContext context, int capacity)
    {
        var trucks = context.Clients
            .Where(c => c.ClientsTrucks.Any(t => t.Truck.CargoCapacity >= capacity))
            .Select(c => new
            {
                Name = c.Name,
                Trucks = c.ClientsTrucks
                    .Where(c => c.Truck.TankCapacity >= capacity)
                    .OrderBy(t => t.Truck.MakeType)
                    .ThenByDescending(t => t.Truck.CargoCapacity)
                    .Select(t => new
                    {
                        TruckRegistrationNumber = t.Truck.RegistrationNumber,
                        VinNumber = t.Truck.VinNumber,
                        TankCapacity = t.Truck.TankCapacity,
                        CargoCapacity = t.Truck.CargoCapacity,
                        CategoryType = t.Truck.CategoryType.ToString(),
                        MakeType = t.Truck.MakeType.ToString()
                    })
                    .ToArray()
            })
            .OrderByDescending(c => c.Trucks.Count())
            .ThenBy(c => c.Name)
            .Take(10)
            .ToArray();

        return JsonConvert.SerializeObject(trucks, Formatting.Indented);
    }
}
