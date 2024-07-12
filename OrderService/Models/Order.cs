namespace OrderService.Models
{
    public class Order
    {
        public int id { get; set; }
        public string description { get; set; } = string.Empty; // Значение по умолчанию
        public string pickupAddress { get; set; } = string.Empty; // Значение по умолчанию
        public string deliveryAddress { get; set; } = string.Empty; // Значение по умолчанию
        public string status { get; set; } = "New";  // Значение по умолчанию
        public string? comment { get; set; } // Разрешено значение null
        public DateTime createdDate { get; set; }
        public DateTime updatedDate { get; set; }
        public string executor { get; set; } = string.Empty; // Значение по умолчанию
        public double width { get; set; }
        public double height { get; set; }
        public double depth { get; set; }
        public double weight { get; set; }

        public Order() { }
    }
}
