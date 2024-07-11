using System;

namespace OrderService.Models
{
    public class Order
    {
        public int id { get; set; }
        public string description { get; set; }
        public string pickupAddress { get; set; }
        public string deliveryAddress { get; set; }
        public string status { get; set; } = "New";  // Установить значение по умолчанию
        public string comment { get; set; }
        public DateTime createdDate { get; set; }
        public DateTime updatedDate { get; set; }

        public Order() { }
    }
}
