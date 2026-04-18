using System.Text.Json.Serialization;

namespace ChaitraliAPI.Model
{
    public class ProductCT
    {
        [JsonPropertyName("products")]
        public List<Product1>? Product { get; set; }
    }
    public class Product1
    {
        public string? Product_ID { get; set; }
        public string? Category { get; set; }
        public string? Sub_Category { get; set; }
        public string? Product_Name { get; set; }
    }
}
