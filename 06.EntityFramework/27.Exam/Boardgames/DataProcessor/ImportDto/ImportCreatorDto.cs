using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Boardgames.DataProcessor.ImportDto;

[XmlType("Creator")]
public class ImportCreatorDto
{
    [MinLength(2)]
    [MaxLength(7)]
    public string FirstName { get; set; } = null!;

    [MinLength(2)]
    [MaxLength(7)]
    public string LastName { get; set; } = null!;

    [XmlArray("Boardgames")]
    public ImportBoardgameDto[] BoardgameDtos { get; set; }
}
