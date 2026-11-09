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
            ProductsModel model = new ProductsModel();
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
            ProductsModel model = new ProductsModel();

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
            ProductsModel model = new ProductsModel();

            var products = model.GetCatalog("  ТУФ  ", null);

            Assert.AreEqual(2, products.Count);
            Assert.AreEqual("Черные туфли в классическом стиле", products[0].Name);
            Assert.AreEqual("Черные туфли в классическом стиле", products[1].Name);
            Assert.AreEqual(3, products[0].Count);
            Assert.AreEqual(7, products[1].Count);
        }

        [TestMethod]
        public void GetCatalog_QueryPresentOnlyInComposition_ReturnsNoProducts()
        {
            ProductsModel model = new ProductsModel();

            var products = model.GetCatalog("натуральная кожа", null);

            Assert.AreEqual(0, products.Count);
        }

        [TestMethod]
        public void GetCatalog_BlankQuery_ReturnsAllProductsInOriginalOrder()
        {
            ProductsModel model = new ProductsModel();
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
    }
}
