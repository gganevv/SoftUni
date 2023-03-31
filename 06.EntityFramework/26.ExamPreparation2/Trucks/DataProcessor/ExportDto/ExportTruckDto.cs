namespace Trucks.DataProcessor.ExportDto;

using System.Xml.Serialization;

[XmlType("Truck")]
public class ExportTruckDto
{
    public string RegistrationNumber { get; set; }

    public string Make { get; set; }
}
