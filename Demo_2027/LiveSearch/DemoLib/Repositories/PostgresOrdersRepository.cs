using System.Collections.Generic;
using DemoLib.Models;
using Npgsql;

namespace DemoLib.Repositories
{
    public class PostgresOrdersRepository : IOrdersRepository
    {
        private string connectionString_;

        public PostgresOrdersRepository(string connectionString)
        {
            connectionString_ = connectionString;
        }

        public IEnumerable<Order> Load()
        {
            const string sql = @"
                SELECT o.order_id, o.order_date, p.product_id, p.name, i.quantity
                FROM chudo_obuv.orders AS o
                LEFT JOIN chudo_obuv.order_items AS i ON i.order_id = o.order_id
                LEFT JOIN chudo_obuv.stock_items AS s ON s.stock_item_id = i.stock_item_id
                LEFT JOIN chudo_obuv.products AS p ON p.product_id = s.product_id
                ORDER BY o.order_id, i.order_item_id;";

            List<Order> orders = new List<Order>();
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString_))
            using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
            {
                connection.Open();
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
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
                }
            }
            return orders;
        }
    }
}
