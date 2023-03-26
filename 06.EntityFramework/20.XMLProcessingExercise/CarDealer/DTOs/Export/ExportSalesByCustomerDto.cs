namespace CarDealer.DTOs.Export;

using System.Xml.Serialization;

[XmlType("customer")]
public class ExportSalesByCustomerDto
{
    [XmlAttribute("full-name")]
    public string FullName { get; set; } = null!;

    [XmlAttribute("bought-cars")]
    public int BoughtCars { get; set; }

    [XmlAttribute("spent-money")]
    public decimal SpentMoney { get; set; }
}
