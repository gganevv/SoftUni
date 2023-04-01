namespace Boardgames.DataProcessor.ImportDto;

using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

[XmlType("Boardgame")]
public class ImportBoardgameDto
{
    [MinLength(10)]
    [MaxLength(20)]
    public string Name { get; set; } = null!;

    [Range(1, 10)]
    public double Rating { get; set; }

    [Range(2018, 2023)]
    public int YearPublished { get; set; }

    public int CategoryType { get; set; }

    [Required(AllowEmptyStrings = false)]
    [DisplayFormat(ConvertEmptyStringToNull = false)]
    public string Mechanics { get; set; } = null!;
}
