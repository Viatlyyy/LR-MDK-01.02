using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using RestaurantOrder;

namespace TRestaurant
{
    [TestClass]
    public class TRestaurant
    {
        [TestMethod]
        public void TestGetDescription()
        {
           
            MenuItem item = new MenuItem();
            item.Name = "Борщ";
            item.Price = 250.50;
            item.Ingredients = "Свекла, капуста, мясо";
            item.ImagePath = "path.jpg";

           
            string description = item.GetDescription();

            
            string expectedPrice = item.Price.ToString("F2");
            Assert.IsTrue(description.Contains(expectedPrice), $"Цена {expectedPrice} не найдена");
            Assert.IsTrue(description.Contains(item.Ingredients), "Ингредиенты не найдены");
            Assert.IsTrue(description.Contains("Стоимость:"), "Заголовок 'Стоимость:' отсутствует");
            Assert.IsTrue(description.Contains("Ингредиенты:"), "Заголовок 'Ингредиенты:' отсутствует");
        }

        [TestMethod]
        public void TestMenuItemProperties()
        {
            
            MenuItem item = new MenuItem();
            item.Name = "Плов";
            item.Price = 180;
            item.Ingredients = "Рис, мясо, морковь";
            item.ImagePath = "plov.jpg";

            
            Assert.AreEqual("Плов", item.Name);
            Assert.AreEqual(180, item.Price);
            Assert.AreEqual("Рис, мясо, морковь", item.Ingredients);
            Assert.AreEqual("plov.jpg", item.ImagePath);
        }

        [TestMethod]
        public void TestMenuItemDefaultValues()
        {
            
            MenuItem item = new MenuItem();

            
            Assert.IsNull(item.Name);
            Assert.AreEqual(0, item.Price);
            Assert.IsNull(item.Ingredients);
            Assert.IsNull(item.ImagePath);
        }
    }

    [TestClass]
    public class TestMenuGroup
    {
        [TestMethod]
        public void TestMenuGroupCreation()
        {
           
            MenuGroup group = new MenuGroup();
            group.Name = "Завтрак";

           
            Assert.AreEqual("Завтрак", group.Name);
            Assert.IsNotNull(group.Items);
            Assert.AreEqual(0, group.Items.Count);
        }

        [TestMethod]
        public void TestMenuGroupAddItems()
        {
            
            MenuGroup group = new MenuGroup();

            MenuItem item1 = new MenuItem { Name = "Каша", Price = 100 };
            MenuItem item2 = new MenuItem { Name = "Яичница", Price = 150 };

           
            group.Items.Add(item1);
            group.Items.Add(item2);

           
            Assert.AreEqual(2, group.Items.Count);
            Assert.AreEqual("Каша", group.Items[0].Name);
            Assert.AreEqual("Яичница", group.Items[1].Name);
        }

        [TestMethod]
        public void TestMenuGroupMultipleGroups()
        {
           
            MenuGroup breakfast = new MenuGroup { Name = "Завтрак" };
            MenuGroup lunch = new MenuGroup { Name = "Обед" };
            MenuGroup dinner = new MenuGroup { Name = "Ужин" };

            
            breakfast.Items.Add(new MenuItem { Name = "Каша" });
            lunch.Items.Add(new MenuItem { Name = "Суп" });
            dinner.Items.Add(new MenuItem { Name = "Плов" });

            
            Assert.AreEqual(1, breakfast.Items.Count);
            Assert.AreEqual(1, lunch.Items.Count);
            Assert.AreEqual(1, dinner.Items.Count);
            Assert.AreEqual("Завтрак", breakfast.Name);
            Assert.AreEqual("Обед", lunch.Name);
            Assert.AreEqual("Ужин", dinner.Name);
        }
    }
}
