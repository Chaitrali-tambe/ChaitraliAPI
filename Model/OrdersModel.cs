using System.Runtime.ConstrainedExecution;
using System.Text.Json.Serialization;

namespace ChaitraliAPI.Model
{
    public class OrdersModel
    {
        [JsonPropertyName("orders")]
        public List<Orders>? Orders { get; set; }
    }
    public class Orders
    {
        public int Row_ID { get; set; }
        public string? Order_ID { get; set; }
        public string? Order_Date { get; set; }
        public string? Ship_Date { get; set; }
        public string? Ship_Mode { get; set; }
        public string? Customer_ID { get; set; }
        public string? Customer_Name { get; set; }
        public string? Segment { get; set; }
        public string? Country_Region { get; set; }
        public string? City { get; set; }
        public string? State_Province { get; set; }
        public int Postal_Code { get; set; }
        public string? Region { get; set; }
        public string? Product_ID { get; set; }
        public string? Category { get; set; }
        public string? Sub_Category { get; set; }
        public string? Product_Name { get; set; }
        public float Sales { get; set; }
        public int Quantity { get; set; }
        public float Discount { get; set; }
        public float Profit { get; set; }
    }
}
