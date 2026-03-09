using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrderLibrary
{
    public class MenuItem
    {
        public string Name;
        public double Price;
        public string Ingredients;
        public string ImagePath;

        public string GetDescription()
        {
            return "Стоимость: " + Price.ToString("F2") +
                   " руб.\n\nИнгредиенты: " + Ingredients;
        }
    }
}
