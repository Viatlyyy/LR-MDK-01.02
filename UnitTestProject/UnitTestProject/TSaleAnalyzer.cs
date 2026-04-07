using System;
using System.Collections.Generic;
using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class TSaleAnalyzer
    {
        [TestMethod]
        public void TestCalculateCalculateRevenue()
        {
            {
                SaleAnalyzer analyzer = new SaleAnalyzer();
                string productName = "Бананы";
                double expectedRevenue = 300 * 3; 

                
                double actualRevenue = analyzer.CalculateRevenue(productName);

                
                Assert.AreEqual(expectedRevenue, actualRevenue);
            }
        }
    }
}
