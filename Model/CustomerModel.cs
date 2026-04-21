using System.Text.Json.Serialization;

namespace ChaitraliAPI.Model
{
    public class CustomerModel
    {
        [JsonPropertyName("customers")]
        public List<Customers>? Customers { get; set; }

    }
    public class Customers
    {
        public int Customer_ID { get; set; }
        public string? Customer_Name { get; set; }
        public string? Segment { get; set; }
    }
}
