using System;
using Calculate;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class TCalculator
    {
        Calculate.Calculator calculator1 = new Calculate.Calculator();

        
        [DataRow(4, 2, 2)]
        [DataRow(7, 2, 3.5)]
        [DataRow(2, 5, 0.4)]
        [DataRow(5, 5, 1)]
        [DataRow(5, 1, 5)]
        [DataRow(-20, 4, -5)]
        [DataRow(-20, -4, 5)]
        [DataRow(0, 5, 0)]

        [TestMethod]
        public void TestCalculateDevidend()
        {
            TCalculator calculator = new TCalculator();
            double a = 4;
            double b = 2;

            double expected = 2;
            double actual = calculator1.CalculateDevidend(a, b);
            Assert.AreEqual(expected, actual);
        }
        
        
    }
}
