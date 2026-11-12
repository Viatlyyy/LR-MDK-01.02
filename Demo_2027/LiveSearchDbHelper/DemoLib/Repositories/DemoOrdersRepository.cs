using System.Collections.Generic;
using DemoLib.Models;

namespace DemoLib.Repositories
{
    // Временный источник без БД: при запуске исходного проекта заказы также были пустыми.
    public class DemoOrdersRepository : IOrdersRepository
    {
        public IEnumerable<Order> Load()
        {
            return new Order[0];
        }
    }
}
