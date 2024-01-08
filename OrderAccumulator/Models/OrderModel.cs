namespace OrderAccumulator.Models
{
    public class OrderModel
    {
        public int Id {  get; set; }
        public required string Name { get; set; }
        public required string Side { get; set; }
        public required int Quantity { get; set; }
        public required decimal Price { get; set; }
    }
}
