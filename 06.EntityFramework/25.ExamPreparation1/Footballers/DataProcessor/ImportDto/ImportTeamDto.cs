using Footballers.Data.Models;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Footballers.DataProcessor.ImportDto
{
    public class ImportTeamDto
    {
        [MinLength(3)]
        [MaxLength(40)]
        public string Name { get; set; } = null!;

        [MinLength(2)]
        [MaxLength(40)]
        public string Nationality { get; set; } = null!;

        [Range(1, int.MaxValue)]
        public int Trophies { get; set; }

        [JsonProperty("Footballers")]
        public HashSet<int> Footballers { get; set; }
    }
}
