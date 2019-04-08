using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderService.Models
{
    public class Order
    {
        public string OrderId { get; set; }
        public string CreationDateTime { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public string StatusDescription
        {
            get
            {
                return this.OrderStatus.ToString();
            }
        }

        public ICollection<OrderItem> Items { get; set; }
    }

    public enum OrderStatus
    {
        Created,
        Placed,
        Delivered
    }
}
