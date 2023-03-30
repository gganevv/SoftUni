namespace Trucks.DataProcessor.ImportDto;

using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

[XmlType("Despatcher")]
public class ImportDespatcherDto
{
    [MinLength(2)]
    [MaxLength(40)]
    public string Name { get; set; } = null!;

    [Required(AllowEmptyStrings = false)]
    [DisplayFormat(ConvertEmptyStringToNull = false)]
    public string Position { get; set; } = null!;

    [XmlArray("Trucks")]
    public ImportTruckDto[] Trucks { get; set; }
}
