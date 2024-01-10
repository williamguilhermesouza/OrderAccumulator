using System.Text.Json.Serialization;

namespace OrderAccumulator.Models
{
    public class ResponseDto
    {
        [JsonPropertyName("sucesso")]
        public bool Success { get; set; }
        [JsonPropertyName("exposicao_atual")]
        public decimal Exposure { get; set; }
        [JsonPropertyName("msg_erro")]
        public string? Error { get; set; }

    }
}
