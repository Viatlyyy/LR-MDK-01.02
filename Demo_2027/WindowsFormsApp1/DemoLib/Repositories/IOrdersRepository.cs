using System.Collections.Generic;
using DemoLib.Models;

namespace DemoLib.Repositories
{
    public interface IOrdersRepository
    {
        /// <summary>
        /// Загружает заказы из источника данных; при отсутствии заказов возвращает пустую последовательность.
        /// </summary>
        IEnumerable<Order> Load();
    }
}
