namespace CarDealer.DTOs.Export;

using System.Xml.Serialization;

[XmlType("sale")]
public class ExportSalesWithDiscountDto
{
    [XmlElement("car")]
    public SaleCarDto SaleCar { get; set; }

    [XmlElement("discount")]
    public decimal SaleDiscount { get; set; }

    [XmlElement("customer-name")]
    public string CustomerName { get; set; } = null!;

    [XmlElement("price")]
    public decimal Price { get; set; }

    [XmlElement("price-with-discount")]
    public string PriceWithDiscount { get; set; } = null!;
}


public class SaleCarDto
{
    [XmlAttribute("make")]
    public string CarMake { get; set; } = null!;

    [XmlAttribute("model")]
    public string CarModel { get; set; } = null!;

    [XmlAttribute("traveled-distance")]
    public long CarTravelledDistance { get; set; }
}