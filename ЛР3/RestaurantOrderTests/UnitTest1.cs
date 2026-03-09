
using RestaurantOrderLibrary;
using Xunit;

namespace RestaurantOrder.Tests
{
    public class OrderServiceTests
    {
        [Fact]
        public void CalculateTotal_ReturnsCorrectValue()
        {
            MenuItem item = new MenuItem
            {
                Name = "Pizza",
                Price = 10
            };

            OrderService service = new OrderService();

            double result = service.CalculateTotal(item, 3);

            Assert.Equal(30, result);
        }
    }
}