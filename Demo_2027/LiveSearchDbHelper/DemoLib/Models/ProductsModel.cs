using System;
using System.Collections.Generic;
using System.Linq;
using DemoLib.Repositories;
using DemoLib.Data;

namespace DemoLib.Models
{
    public class ProductsModel : IProductsModel
    {
        private List<Product> data_;

        public ProductsModel(DatabaseHelper database) : this(database.LoadProducts())
        {
        }

        public ProductsModel(IEnumerable<Product> products)
        {
            data_ = products.ToList();
        }

        public List<Product> Load()
        {
            return data_;
        }

        public List<Product> GetCatalog(string namePart, bool? ascending)
        {
            IEnumerable<Product> products = data_;
            string query = (namePart ?? string.Empty).Trim();
            if (query.Length > 0)
            {
                products = products.Where(product =>
                    product.Name?.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    product.Description?.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0);
            }

            if (ascending.HasValue)
            {
                products = ascending.Value
                    ? products.OrderBy(product => product.Price)
                    : products.OrderByDescending(product => product.Price);
            }

            return products.ToList();
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
                    .Any(item => item.Count > 0
                        && (item.ProductId.HasValue ? item.ProductId.Value == product.Id : item.ProductItem == product.Name)
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
