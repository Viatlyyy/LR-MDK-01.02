using System;
using System.Collections.Generic;
using DemoLib;
using DemoLib.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DemoTesting
{
    [TestClass]
    public class TOrder
    {
        private ProductsModel model;
        private Product product;
        private DateTime currentMonth;
        private DateTime previousMonth;

        [TestInitialize]
        public void SetUp()
        {
            DateTime today = DateTime.Today;
            currentMonth = new DateTime(today.Year, today.Month, 1);
            previousMonth = currentMonth.AddMonths(-1);
            model = new ProductsModel();
            model.Load().Clear();
            product = new Product { Name = "Товар A", Price = 1000.0 };
            model.Load().Add(product);
        }

        [TestMethod]
        public void UpdatePrices_NoOrders_ReducesPriceBy25Percent()
        {
            model.UpdatePrices(new List<Order>());

            Assert.AreEqual(750.0, product.Price, 0.001);
        }

        [TestMethod]
        public void UpdatePrices_SaleOnFirstDayOfPreviousMonth_KeepsPrice()
        {
            model.UpdatePrices(OrdersFor(product.Name, previousMonth));

            Assert.AreEqual(1000.0, product.Price, 0.001);
        }

        [TestMethod]
        public void UpdatePrices_SaleAtEndOfLastDayOfPreviousMonth_KeepsPrice()
        {
            model.UpdatePrices(OrdersFor(product.Name, currentMonth.AddTicks(-1)));

            Assert.AreEqual(1000.0, product.Price, 0.001);
        }

        [TestMethod]
        public void UpdatePrices_SalesOutsidePreviousMonth_ReducesPrice()
        {
            List<Order> orders = OrdersFor(product.Name, previousMonth.AddTicks(-1));
            orders.AddRange(OrdersFor(product.Name, currentMonth));

            model.UpdatePrices(orders);

            Assert.AreEqual(750.0, product.Price, 0.001);
        }

        [TestMethod]
        public void UpdatePrices_OnlyOneProductWasSold_DiscountsOnlyUnsoldProduct()
        {
            Product other = new Product { Name = "Товар B", Price = 2000.0 };
            model.Load().Add(other);

            model.UpdatePrices(OrdersFor(other.Name, previousMonth.AddDays(10)));

            Assert.AreEqual(750.0, product.Price, 0.001);
            Assert.AreEqual(2000.0, other.Price, 0.001);
        }

        [TestMethod]
        public void UpdatePrices_OrderWithoutItems_ReducesPrice()
        {
            List<Order> orders = new List<Order>
            {
                new Order { Items = new List<OrderItem>() }
            };

            model.UpdatePrices(orders);

            Assert.AreEqual(750.0, product.Price, 0.001);
        }

        [TestMethod]
        public void UpdatePrices_MultipleProductsInOneOrder_KeepsBothPrices()
        {
            Product other = new Product { Name = "Товар B", Price = 2000.0 };
            model.Load().Add(other);
            List<Order> orders = OrdersFor("Товар вне каталога", previousMonth.AddDays(10));
            orders[0].Items.Add(new OrderItem
            {
                ProductItem = product.Name, Count = 1, SaleDate = previousMonth.AddDays(10)
            });
            orders[0].Items.Add(new OrderItem
            {
                ProductItem = other.Name, Count = 2, SaleDate = previousMonth.AddDays(10)
            });

            model.UpdatePrices(orders);

            Assert.AreEqual(1000.0, product.Price, 0.001);
            Assert.AreEqual(2000.0, other.Price, 0.001);
        }

        [TestMethod]
        public void UpdatePrices_SaleInLaterOrder_KeepsPrice()
        {
            List<Order> orders = OrdersFor(product.Name, previousMonth.AddDays(-1));
            orders.AddRange(OrdersFor("Другой товар", previousMonth.AddDays(10)));
            orders.AddRange(OrdersFor(product.Name, previousMonth.AddDays(15)));

            model.UpdatePrices(orders);

            Assert.AreEqual(1000.0, product.Price, 0.001);
        }

        private static List<Order> OrdersFor(string productName, DateTime saleDate)
        {
            return new List<Order>
            {
                new Order
                {
                    Items = new List<OrderItem>
                    {
                        new OrderItem { ProductItem = productName, Count = 1, SaleDate = saleDate }
                    }
                }
            };
        }
    }
}
