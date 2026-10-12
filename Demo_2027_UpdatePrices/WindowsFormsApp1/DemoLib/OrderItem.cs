using System;
using System.Security.AccessControl;

namespace DemoLib
{
    public class OrderItem
    {
        public string ProductItem { get; set; }

        public int Count { get; set; }

        public DateTime SaleDate { get; set; }
    }
}
