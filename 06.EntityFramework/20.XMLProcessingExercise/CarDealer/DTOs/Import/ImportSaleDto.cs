namespace CarDealer.DTOs.Import;

using System.Xml.Serialization;

[XmlType("Sale")]
public class ImportSaleDto
{
    [XmlElement("discount")]
    public decimal Discount { get; set; }

    [XmlElement("carId")]
    public virtual int CarId { get; set; }

    [XmlElement("customerId")]
    public virtual int CustomerId { get; set; }
}
