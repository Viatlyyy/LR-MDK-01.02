using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace DemoLib.Models
{
    public class ProductsModel : IProductsModel
    {
        private List<Product> data_ = new List<Product>();

        public ProductsModel()
        {
            data_.Add(new Product { Name = "Женские босоножки «Черный кофе» со скульптурным каблуком", Category = "Кроссовки", Count = 10, Price = 1600.0, Supplier = "Топ-Топ", Parts = " 87% кожа, 11% текстиль, 2% синтетика" ,
                ImagePath = "..\\..\\..\\Images\\IMG_WS_185528.png"
            });
            data_.Add(new Product { Name = "Черные туфли в классическом стиле", Category = "Туфли", Count = 3, Price = 500.0, Supplier = "Барбари", Parts = "натуральная кожа ",
            ImagePath = "..\\..\\..\\Images\\IMG_MSho_190514.png"
            });
            data_.Add(new Product
            {
                Name = "Черные туфли в классическом стиле",
                Category = "Туфли",
                Count = 7,
                Price = 500.0,
                Supplier = "Барбари",
                Parts = "натуральная кожа ",
                ImagePath = ""
            });
        }

        public List<Product> Load()
        {
            return data_;
        }

        public int GetCountProducts()
        {
            return data_.Count;
        }

        public void UpdatePrices(List<Order> orders)
        {
            DateTime current = DateTime.Today;
            DateTime end = new DateTime(current.Year, current.Month, 1);
            DateTime start = end.AddMonths(-1);

            List<Product> discountProducts = new List<Product>();
            foreach(Product product in data_)
            {
                int countPrevMonthOrders = 0;
                foreach(Order order in orders)
                {
                    foreach(OrderItem orderItem in order.Items)
                    {
                        if(orderItem.ProductItem == product.Name)
                        {
                            if(orderItem.SaleDate >= start && orderItem.SaleDate < end)
                            {
                                ++countPrevMonthOrders;
                            }
                        }
                    }
                }

                if (countPrevMonthOrders == 0)
                {
                    discountProducts.Add(product);
                }
            }

            foreach (Product product in discountProducts)
            {
                product.Price = product.Price * 0.75;
            }
        }
    }
}
