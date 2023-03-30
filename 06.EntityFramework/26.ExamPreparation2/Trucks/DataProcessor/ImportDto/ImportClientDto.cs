using System.ComponentModel.DataAnnotations;

namespace Trucks.DataProcessor.ImportDto;

public class ImportClientDto
{
    [MinLength(3)]
    [MaxLength(40)]
    public string Name { get; set; } = null!;

    [MinLength(2)]
    [MaxLength(40)]
    public string Nationality { get; set; } = null!;

    [Required(AllowEmptyStrings = false)]
    [DisplayFormat(ConvertEmptyStringToNull = false)]
    public string Type { get; set; } = null!;

    public HashSet<int> Trucks { get; set; }
}
