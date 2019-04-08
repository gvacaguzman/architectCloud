using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderService.Models
{
    public class OrderItem
    {
        public string OrderItemId { get; set; }
        public string ItemCode { get; set; }
        public string Description { get; set; }
        public string Quantity { get; set; }

        public string OrderId { get; set; }
        public Order Order { get; set; }
    }
}
