using System;
using System.Collections.Generic;
using System.IO;
using DemoLib.Models;
using Npgsql;

namespace DemoLib.Data
{
    public class DatabaseHelper
    {
        private string connectionString_;

        public DatabaseHelper(string connectionString)
        {
            connectionString_ = connectionString;
        }

        private T Read<T>(string sql, Func<NpgsqlDataReader, T> mapResult)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString_))
            using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
            {
                connection.Open();
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    return mapResult(reader);
                }
            }
        }

        public List<Product> LoadProducts()
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

            return Read(sql, reader =>
            {
                List<Product> products = new List<Product>();
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
                return products;
            });
        }

        public List<Order> LoadOrders()
        {
            const string sql = @"
                SELECT o.order_id, o.order_date, p.product_id, p.name, i.quantity
                FROM chudo_obuv.orders AS o
                LEFT JOIN chudo_obuv.order_items AS i ON i.order_id = o.order_id
                LEFT JOIN chudo_obuv.stock_items AS s ON s.stock_item_id = i.stock_item_id
                LEFT JOIN chudo_obuv.products AS p ON p.product_id = s.product_id
                ORDER BY o.order_id, i.order_item_id;";

            return Read(sql, reader =>
            {
                List<Order> orders = new List<Order>();
                Order order = null;
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    if (order == null || order.Id != id)
                    {
                        order = new Order { Id = id, Items = new List<OrderItem>() };
                        orders.Add(order);
                    }

                    if (!reader.IsDBNull(2))
                    {
                        order.Items.Add(new OrderItem
                        {
                            ProductId = reader.GetInt32(2),
                            ProductItem = reader.GetString(3),
                            Count = reader.GetInt32(4),
                            SaleDate = reader.GetDateTime(1)
                        });
                    }
                }
                return orders;
            });
        }
    }
}
