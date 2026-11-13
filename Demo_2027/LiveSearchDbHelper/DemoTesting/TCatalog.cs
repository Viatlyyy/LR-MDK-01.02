using System.Collections.Generic;
using DemoLib;
using DemoLib.Models;
using DemoLib.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DemoTesting
{
    [TestClass]
    public class TCatalog
    {
        [TestMethod]
        public void GetCatalog_Ascending_UsesDiscountedPricesAndKeepsEqualPriceOrder()
        {
            ProductsModel model = CreateModel();
            model.UpdatePrices(new DemoOrdersRepository());

            var products = model.GetCatalog(null, true);

            Assert.AreEqual(4, products.Count);
            Assert.AreEqual(375.0, products[0].Price);
            Assert.AreEqual(375.0, products[1].Price);
            Assert.AreEqual(1200.0, products[2].Price);
            Assert.AreEqual(1492.5, products[3].Price);
            Assert.AreEqual(3, products[0].Count);
            Assert.AreEqual(7, products[1].Count);
        }

        [TestMethod]
        public void GetCatalog_Descending_UsesNumericPricesAndKeepsEqualPriceOrder()
        {
            ProductsModel model = CreateModel();

            var products = model.GetCatalog(null, false);

            Assert.AreEqual(4, products.Count);
            Assert.AreEqual(1990.0, products[0].Price);
            Assert.AreEqual(1600.0, products[1].Price);
            Assert.AreEqual(500.0, products[2].Price);
            Assert.AreEqual(500.0, products[3].Price);
            Assert.AreEqual(3, products[2].Count);
            Assert.AreEqual(7, products[3].Count);
        }

        [TestMethod]
        public void GetCatalog_NamePart_TrimsAndIgnoresCaseWithoutCombiningMatches()
        {
            ProductsModel model = CreateModel();

            var products = model.GetCatalog("  ТУФ  ", null);

            Assert.AreEqual(2, products.Count);
            Assert.AreEqual("Черные туфли в классическом стиле", products[0].Name);
            Assert.AreEqual("Черные туфли в классическом стиле", products[1].Name);
            Assert.AreEqual(3, products[0].Count);
            Assert.AreEqual(7, products[1].Count);
        }

        [TestMethod]
        public void GetCatalog_DescriptionPart_TrimsAndIgnoresCase()
        {
            ProductsModel model = CreateModel();

            var products = model.GetCatalog("  ДЛЯ ПРОГУЛОК  ", null);

            Assert.AreEqual(1, products.Count);
            Assert.AreEqual("Кроссовки", products[0].Name);
        }

        [TestMethod]
        public void GetCatalog_QueryPresentOnlyInComposition_ReturnsNoProducts()
        {
            ProductsModel model = CreateModel();

            var products = model.GetCatalog("натуральная кожа", null);

            Assert.AreEqual(0, products.Count);
        }

        [TestMethod]
        public void GetCatalog_BlankQuery_ReturnsAllProductsInOriginalOrder()
        {
            ProductsModel model = CreateModel();
            model.GetCatalog(null, true);
            model.GetCatalog(null, false);

            var products = model.GetCatalog("  ", null);

            Assert.AreEqual(4, products.Count);
            Assert.AreEqual(1600.0, products[0].Price);
            Assert.AreEqual(500.0, products[1].Price);
            Assert.AreEqual(500.0, products[2].Price);
            Assert.AreEqual(1990.0, products[3].Price);
            Assert.AreEqual(3, products[1].Count);
            Assert.AreEqual(7, products[2].Count);
            Assert.AreNotSame(model.Load(), products);
        }

        [TestMethod]
        public void GetCatalog_CategoryCombinesWithSearchAndPriceOrder()
        {
            ProductsModel model = new ProductsModel(new List<Product>
            {
                new Product { Name = "Кеды", Category = "Мужская", Price = 900 },
                new Product { Name = "Кроссовки", Description = "Лёгкие кеды", Category = "Детская", Price = 500 },
                new Product { Name = "Кеды высокие", Category = "Детская", Price = 700 },
                new Product { Name = "Сапоги", Category = "Детская", Price = 1000 }
            });

            var products = model.GetCatalog("  КЕДЫ  ", false, "Детская");

            Assert.AreEqual(2, products.Count);
            Assert.AreEqual("Кеды высокие", products[0].Name);
            Assert.AreEqual("Кроссовки", products[1].Name);

            products = model.GetCatalog("кеды", false);
            Assert.AreEqual(3, products.Count);
            Assert.AreEqual("Кеды", products[0].Name);
        }

        private ProductsModel CreateModel()
        {
            return new ProductsModel(new List<Product>
            {
                new Product { Name = "Босоножки", Price = 1600.0, Count = 10 },
                new Product { Name = "Черные туфли в классическом стиле", Price = 500.0, Count = 3, Parts = "натуральная кожа" },
                new Product { Name = "Черные туфли в классическом стиле", Price = 500.0, Count = 7 },
                new Product { Name = "Кроссовки", Description = "Лёгкая обувь для прогулок", Price = 1990.0, Count = 60 }
            });
        }

    }
}
