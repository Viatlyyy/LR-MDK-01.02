using System.Collections.Generic;
using DemoLib.Models;
using DemoLib.Repositories;

namespace DemoTesting.Mocks
{
    // Ручной мок: возвращает тестовые заказы и записывает вызовы загрузки.
    public class OrdersRepositoryMock : IOrdersRepository
    {
        private IEnumerable<Order> orders_;

        public int LoadCallCount { get; set; }

        public OrdersRepositoryMock(IEnumerable<Order> orders)
        {
            orders_ = orders;
        }

        public IEnumerable<Order> Load()
        {
            LoadCallCount++;
            return orders_;
        }
    }
}
