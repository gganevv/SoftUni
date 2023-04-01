using System.ComponentModel.DataAnnotations;

namespace Boardgames.DataProcessor.ImportDto;

public class ImportSellerDto
{
    [MinLength(5)]
    [MaxLength(20)]
    public string Name { get; set; } = null!;

    [MinLength(2)]
    [MaxLength(30)]
    public string Address { get; set; } = null!;

    [Required(AllowEmptyStrings = false)]
    [DisplayFormat(ConvertEmptyStringToNull = false)]
    public string Country { get; set; } = null!;

    [RegularExpression(@"www.[A-Za-z\d/-]+.com")]
    [Required(AllowEmptyStrings = false)]
    [DisplayFormat(ConvertEmptyStringToNull = false)]
    public string Website { get; set; } = null!;

    public int[] Boardgames { get; set; }
}
