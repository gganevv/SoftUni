using Footballers.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Footballers.DataProcessor.ImportDto
{
    [XmlType("Coach")]
    public class ImportCoachDto
    {
        [XmlElement("Name")]
        [MinLength(3)]
        [MaxLength(40)]
        [Required]
        public string Name { get; set; } = null!;

        [Required]
        [XmlElement("Nationality")]
        public string Nationality { get; set; } = null!;

        [XmlArray("Footballers")]
        public ImportFootballerDto[] Footballers { get; set; }
    }

    [XmlType("Footballer")]
    public class ImportFootballerDto
    {
        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        public string Name { get; set; } = null!;

        [Required]
        public string ContractStartDate { get; set; } = null!;

        [Required]
        public string ContractEndDate { get; set; } = null!;

        [Required]
        public int BestSkillType { get; set; }

        [Required]
        public int PositionType { get; set; }
    }
}
