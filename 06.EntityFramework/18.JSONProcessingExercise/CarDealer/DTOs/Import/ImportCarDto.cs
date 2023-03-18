namespace CarDealer.DTOs.Import;

using Newtonsoft.Json;

public class ImportCarDto
{
    public ImportCarDto()
    {
        this.PartsCars = new HashSet<int>();
    }

    [JsonProperty("make")]
    public string Make { get; set; } = null!;

    [JsonProperty("model")]
    public string Model { get; set; } = null!;

    [JsonProperty("travelledDistance")]
    public long TravelledDistance {  get; set; }

    [JsonProperty("partsId")]
    public IEnumerable<int> PartsCars { get; set; }
}
