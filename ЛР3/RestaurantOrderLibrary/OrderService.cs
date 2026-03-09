using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrderLibrary
{
    public class OrderService
    {
        public double CalculateTotal(MenuItem item, int quantity)
        {
            return item.Price * quantity;
        }

        public string CreateOrderLine(string groupName, MenuItem item, int quantity)
        {
            double total = CalculateTotal(item, quantity);

            return "Группа: " + groupName +
                   " | Позиция: " + item.Name +
                   " | Кол-во: " + quantity +
                   " | Сумма: " + total.ToString("F2") + " руб.";
        }
    }
}
