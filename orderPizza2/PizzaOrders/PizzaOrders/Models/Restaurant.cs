using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderService.Models
{
    public class Restaurant
    {
        public long RestaurantId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string RestaurantCode { get; set; }

        public ICollection<MenuItem> MenuItems { get; set; }
    }
}
