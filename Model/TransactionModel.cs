using System.Text.Json.Serialization;

namespace ChaitraliAPI.Model
{
    public class TransactionModel
    {
        [JsonPropertyName("locations")]
        public List<Transaction>? Transaction { get; set; }
        
    }

    public class Transaction
    {
        public string? Order_ID { get; set; }
        public string? Product_ID { get; set; }
        public string? Sales { get; set; }
        public string? Quantity { get; set; }
        public string? Discount { get; set; }
        public string? Profit { get; set; }
    }

}
