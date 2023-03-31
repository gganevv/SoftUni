namespace Trucks.DataProcessor;

using Data;
using Newtonsoft.Json;
using Trucks.Data.Models.Enums;
using Trucks.DataProcessor.ExportDto;
using Trucks.Util;

public class Serializer
{
    public static string ExportDespatchersWithTheirTrucks(TrucksContext context)
    {
        XmlHelper xmlHelper = new XmlHelper();

        var despatcherDtos = context.Despatchers
            .Where(d => d.Trucks.Count > 0)
            .Select(d => new ExportDespatcherDto()
            {
                TrucksCount = d.Trucks.Count(),
                Name = d.Name,
                Trucks = d.Trucks
                    .Select(t => new ExportTruckDto()
                    {
                        RegistrationNumber = t.RegistrationNumber,
                        Make = t.MakeType.ToString()
                    })
                    .OrderBy(t => t.RegistrationNumber)
                    .ToArray()
            })
            .OrderByDescending(d => d.Trucks.Count())
            .ThenBy(d => d.Name)
            .ToArray();

        var despatchers = xmlHelper.Serialize<ExportDespatcherDto[]>(despatcherDtos, "Despatchers");

        return despatchers;
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
