using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DemoLib.Repositories;
using Npgsql;

namespace DemoLib.Models
{
    public class ProductsModel : IProductsModel
    {
        private List<Product> data_;

        public ProductsModel(string connectionString) : this(ReadProducts(connectionString))
        {
        }

        public ProductsModel(IEnumerable<Product> products)
        {
            data_ = products.ToList();
        }

        private static List<Product> ReadProducts(string connectionString)
        {
            const string sql = @"
                SELECT p.product_id, p.name, c.name, m.name, p.composition, p.price_kopecks,
                       p.image_file_name, COALESCE(stock.quantity, 0), p.description
                FROM chudo_obuv.products AS p
                JOIN chudo_obuv.categories AS c ON c.category_id = p.category_id
                JOIN chudo_obuv.manufacturers AS m ON m.manufacturer_id = p.manufacturer_id
                LEFT JOIN (
                    SELECT product_id, SUM(available_quantity) AS quantity
                    FROM chudo_obuv.stock_items
                    GROUP BY product_id
                ) AS stock ON stock.product_id = p.product_id
                ORDER BY p.product_id;";

            List<Product> products = new List<Product>();
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
            {
                connection.Open();
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        products.Add(new Product
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Category = reader.GetString(2),
                            Supplier = reader.GetString(3),
                            Parts = reader.GetString(4),
                            Price = reader.GetInt32(5) / 100.0,
                            ImagePath = reader.IsDBNull(6) ? null : Path.GetFileName(reader.GetString(6)),
                            Count = checked((int)reader.GetInt64(7)),
                            Description = reader.GetString(8)
                        });
                    }
                }
            }
            return products;
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
