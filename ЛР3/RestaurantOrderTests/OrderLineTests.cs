
using RestaurantOrderLibrary;
using Xunit;

namespace RestaurantOrder.Tests
{
    public class OrderLineTests
    {
        [Fact]
        public void CreateOrderLine_ReturnsCorrectText()
        {
            MenuItem item = new MenuItem
            {
                Name = "Burger",
                Price = 5
            };

            OrderService service = new OrderService();

            string result = service.CreateOrderLine("FastFood", item, 2);

            Assert.Contains("Burger", result);
            Assert.Contains("10", result);
        }
    }
}