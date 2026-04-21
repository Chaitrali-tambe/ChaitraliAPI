using System.Text.Json.Serialization;

namespace ChaitraliAPI.Model
{
    public class CategoriesModel
    {
        [JsonPropertyName("orders")]
        public List<Categories>? Categories { get; set; }
    }
    public class Categories
    {
        public string? Category { get; set; }
        public string[]? Sub_Categories { get; set; }
    }
}
