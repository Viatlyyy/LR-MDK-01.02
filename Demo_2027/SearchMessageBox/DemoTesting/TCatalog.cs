using System.Linq;
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
            ProductsModel model = new ProductsModel();
            model.UpdatePrices(new DemoOrdersRepository());
            Product[] original = model.Load().ToArray();

            var products = model.GetCatalog(null, true);

            CollectionAssert.AreEqual(new[] { 375.0, 375.0, 1200.0, 1492.5 },
                products.Select(product => product.Price).ToArray());
            Assert.AreSame(original[1], products[0]);
            Assert.AreSame(original[2], products[1]);
            CollectionAssert.AreEqual(original, model.Load().ToArray());
        }

        [TestMethod]
        public void GetCatalog_Descending_UsesNumericPricesAndKeepsEqualPriceOrder()
        {
            ProductsModel model = new ProductsModel();
            Product[] original = model.Load().ToArray();

            var products = model.GetCatalog(null, false);

            CollectionAssert.AreEqual(new[] { 1990.0, 1600.0, 500.0, 500.0 },
                products.Select(product => product.Price).ToArray());
            Assert.AreSame(original[1], products[2]);
            Assert.AreSame(original[2], products[3]);
            CollectionAssert.AreEqual(original, model.Load().ToArray());
        }

        [TestMethod]
        public void GetCatalog_NamePart_TrimsAndIgnoresCaseWithoutCombiningMatches()
        {
            ProductsModel model = new ProductsModel();

            var products = model.GetCatalog("  ТУФ  ", null);

            CollectionAssert.AreEqual(new[] { 3, 7 },
                products.Select(product => product.Count).ToArray());
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

            var products = model.GetCatalog("  ", null);

            CollectionAssert.AreEqual(model.Load(), products);
            Assert.AreNotSame(model.Load(), products);
        }
    }
}
