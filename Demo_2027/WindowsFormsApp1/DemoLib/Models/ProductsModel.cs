using System;
using System.Collections.Generic;
using System.Linq;
using DemoLib.Repositories;

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
            data_.Add(new Product
            {
                Name = "Кроссовки детские «Радуга» экокожа перфорированная",
                Category = "Детская обувь",
                Count = 60,
                Price = 1990.0,
                Supplier = "Лапушка",
                Parts = "Верх — экокожа перфорированная, вставки — нейлон, стелька — ортопедическая с латексной подушкой, подошва — ЭВА",
                ImagePath = "..\\..\\..\\Images\\IMG_KS_195222.png"
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

        public void UpdatePrices(IOrdersRepository ordersRepository)
        {
            if (ordersRepository == null)
            {
                return;
            }

            // Один снимок загрузки: источник БД не перечисляется заново для каждого товара.
            IEnumerable<Order> orders = ordersRepository.Load().ToArray();
            DateTime current = DateTime.Today;
            DateTime end = new DateTime(current.Year, current.Month, 1);
            DateTime start = end.AddMonths(-1);

            List<Product> discountProducts = data_
                .Where(product => !orders
                    .SelectMany(order => order.Items)
                    .Any(item => item.ProductItem == product.Name
                        && item.SaleDate >= start
                        && item.SaleDate < end))
                .ToList();

            foreach (Product product in discountProducts)
            {
                product.Price *= 0.75;
            }
        }
    }
}
