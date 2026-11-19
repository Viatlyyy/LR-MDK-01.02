using System.Collections.Generic;
using DemoLib.Models;

namespace DemoLib.Repositories
{
    public class DemoOrdersRepository : IOrdersRepository
    {
        public IEnumerable<Order> Load()
        {
            return new Order[0];
        }
    }
}
