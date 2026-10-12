using System.Collections.Generic;

namespace DemoLib.Models
{
    public class Order
    {
        public List<OrderItem> Items { get; set; }

        public int Id { get; set; }
    }
}
