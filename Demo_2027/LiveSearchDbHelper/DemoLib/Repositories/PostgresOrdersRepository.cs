using System.Collections.Generic;
using DemoLib.Data;
using DemoLib.Models;

namespace DemoLib.Repositories
{
    public class PostgresOrdersRepository : IOrdersRepository
    {
        private DatabaseHelper database_;

        public PostgresOrdersRepository(DatabaseHelper database)
        {
            database_ = database;
        }

        public IEnumerable<Order> Load()
        {
            return database_.LoadOrders();
        }
    }
}
