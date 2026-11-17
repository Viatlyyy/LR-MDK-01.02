using System.Collections.Generic;
using DemoLib.Models;

namespace DemoLib.Repositories
{
    public interface IOrdersRepository
    {
        IEnumerable<Order> Load();
    }
}
