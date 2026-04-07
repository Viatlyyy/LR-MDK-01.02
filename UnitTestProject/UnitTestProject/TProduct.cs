using System;
using System.Collections.Generic;
using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class TProduct
    {
        [TestMethod]
        public void TestMethod1()
        {
            Sales loader = new Sales();
            List<Product> actualList = loader.LoadProduct();

            List<Product> expectedList = new List<Product>
            {
                new Product {Name = "Виноград", Price = 1000, Count = 5 },
                new Product {Name = "Сливы", Price = 500, Count = 3 },
                new Product {Name = "Яблоки зеленые", Price = 100, Count = 1 },
                new Product {Name = "Бананы", Price = 300, Count = 3 }
            };

            Assert.AreEqual(expectedList.Count, actualList.Count);
            for (int i = 0; i < expectedList.Count; i++)
            {
                Assert.AreEqual(expectedList[0].Name, actualList[0].Name);
                Assert.AreEqual(expectedList[0].Price, actualList[0].Price);
                Assert.AreEqual(expectedList[0].Count, actualList[0].Count);
            }
        }
    }
}
