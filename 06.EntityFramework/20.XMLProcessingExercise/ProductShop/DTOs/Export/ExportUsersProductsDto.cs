using System.Xml.Serialization;

namespace ProductShop.DTOs.Export;

[XmlType("User")]
public class ExportUsersProductsDto
{
    [XmlElement("firstName")]
    public string FirstName { get; set; }

    [XmlElement("lastName")]
    public string LastName { get; set; }

    [XmlElement("age")]
    public int? Age { get; set; }

    [XmlElement("SoldProducts")]
    public ProductWrapper ProductSold { get; set; }
}

[XmlType("Users")]
public class UserWrapper
{
    [XmlElement("count")]
    public int Count { get; set; }

    [XmlArray("users")]
    public ExportUsersProductsDto[] Users { get; set; }
}
