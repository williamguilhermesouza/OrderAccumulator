using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

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
        [Precision(18, 2)]
        public required decimal Price { get; set; }
    }
}
