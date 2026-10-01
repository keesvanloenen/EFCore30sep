using System;
using System.Collections.Generic;
using System.Text;

namespace MyWebShop.ConsoleApp.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }

        public int CustomerId { get; set; }

        // Navigation property
        public Customer Customer { get; set; } = null!;     // don't use required for navigation properties
    }
}
