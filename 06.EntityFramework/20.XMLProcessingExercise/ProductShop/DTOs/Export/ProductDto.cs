namespace ProductShop.DTOs.Export;

using System.Xml.Serialization;

[XmlType("Product")]
public class ProductDto
{
    [XmlElement("name")]
    public string ProductName { get; set; }

    [XmlElement("price")]
    public decimal Price { get; set; }
}

[XmlType("SoldProducts")]
public class ProductWrapper
{
    [XmlElement("count")]
    public int Count { get; set; }

    [XmlArray("products")]
    public ProductDto[] Products { get; set; }
}