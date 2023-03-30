namespace Trucks.DataProcessor.ImportDto;

using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

[XmlType("Truck")]
public class ImportTruckDto
{
    [MinLength(8)]
    [MaxLength(8)]
    public string RegistrationNumber { get; set; } = null!;

    [MinLength(17)]
    [MaxLength(17)]
    public string VinNumber { get; set; } = null!;

    [Range(950, 1420)]
    public int TankCapacity { get; set; }

    [Range(5000, 29000)]
    public int CargoCapacity { get; set; }

    public int CategoryType { get; set; }

    public int MakeType { get; set; }
}
