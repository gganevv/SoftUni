namespace ProductShop.DTOs.Export;

using System.Xml.Serialization;

[XmlType("User")]
public class ExportSoldProductDto
{
    [XmlElement("firstName")]
    public string FirstName { get; set; }

    [XmlElement("lastName")]
    public string LastName { get; set; }

    [XmlArray("soldProducts")]
    public ProductDto[] ProductDtos { get; set; }
}

[XmlType("Product")]
public class ProductDto
{
    [XmlElement("name")]
    public string ProductName { get; set; }

    [XmlElement("price")]
    public decimal Price { get; set; }
}
