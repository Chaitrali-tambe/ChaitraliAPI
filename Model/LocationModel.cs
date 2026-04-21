using System.Text.Json.Serialization;

namespace ChaitraliAPI.Model
{
    public class LocationModel
    {
        [JsonPropertyName("locations")]
        public List<Location>? Location { get; set; }
    }

    public class Location
    {
        public string? Country_Region { get; set; }
        public string? City { get; set; }
        public string? State_Province { get; set; }
        public int Postal_Code { get; set; }
        public string? Region { get; set; }
    }
}
