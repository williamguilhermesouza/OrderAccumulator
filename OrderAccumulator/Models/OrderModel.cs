using OrderAccumulator.Enums;
using System.Text.Json.Serialization;

namespace OrderAccumulator.Models
{
    public class OrderModel
    {
        public int Id {  get; set; }
        [JsonPropertyName("ativo")]
        public required Stock Name { get; set; }
        [JsonPropertyName("lado")]
        public required Side Side { get; set; }
        [JsonPropertyName("quantidade")]
        public required int Quantity { get; set; }
        [JsonPropertyName("preco")]
        public required decimal Price { get; set; }
    }
}
