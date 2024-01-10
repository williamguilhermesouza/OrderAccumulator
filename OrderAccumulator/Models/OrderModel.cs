using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OrderAccumulator.Models
{
    public class OrderModel
    {
        public int Id {  get; set; }
        [JsonPropertyName("ativo")]
        public required string Name { get; set; }
        [JsonPropertyName("lado")]
        public required string Side { get; set; }
        [JsonPropertyName("quantidade")]
        public required int Quantity { get; set; }
        [JsonPropertyName("preco")]
        public required decimal Price { get; set; }
    }
}
