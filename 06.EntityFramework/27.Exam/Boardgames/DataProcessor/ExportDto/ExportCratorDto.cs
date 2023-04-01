namespace Boardgames.DataProcessor.ExportDto;

using System.Xml.Serialization;

[XmlType("Creator")]
public class ExportCreatorDto
{
    [XmlAttribute("BoardgamesCount")]
    public int BoardgamesCount { get; set; }

    public string CreatorName { get; set; } = null!;

    public ExportBoardgameDto[] Boardgames { get; set; }
}
