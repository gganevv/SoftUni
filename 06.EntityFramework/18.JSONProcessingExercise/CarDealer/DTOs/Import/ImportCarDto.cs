namespace CarDealer.DTOs.Import;

using Newtonsoft.Json;

public class ImportCarDto
{
    [JsonProperty("make")]
    public string Make { get; set; } = null!;

    [JsonProperty("model")]
    public string Model { get; set; } = null!;

    [JsonProperty("travelledDistance")]
    public long TravelledDistance {  get; set; }
}
