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
            List<Product> actual = loader.LoadProduct();

            List<Product> expected = new List<Product>
            {
                new Product {Name = "Виноград", Price = 1000, Count = 5 },
                new Product {Name = "Сливы", Price = 500, Count = 3 },
                new Product {Name = "Яблоки зеленые", Price = 100, Count = 1 },
                new Product {Name = "Бананы", Price = 300, Count = 3 }
            };

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
