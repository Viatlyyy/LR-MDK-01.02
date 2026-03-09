
using RestaurantOrderLibrary;
using Xunit;

namespace RestaurantOrder.Tests
{
    public class MenuItemTests
    {
        [Fact]
        public void GetDescription_ReturnsCorrectText()
        {
            MenuItem item = new MenuItem
            {
                Price = 12.5,
                Ingredients = "Cheese, Tomato"
            };

            string result = item.GetDescription();

            Assert.Contains("12", result);
            Assert.Contains("Cheese", result);
        }
    }
}