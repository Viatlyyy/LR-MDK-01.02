using System;
using System.Collections.Generic;
using DemoLib;
using DemoLib.Models;
using DemoLib.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DemoTesting
{
    [TestClass]
    public class TOrder
    {
        [TestMethod]
        public void UpdatePrices_LoadsOrdersFromRepositoryOnce_AndUsesThemForDiscount()
        {
            DateTime today = DateTime.Today;
            DateTime previousMonth = new DateTime(today.Year, today.Month, 1).AddMonths(-1);
            Product soldProduct = new Product { Name = "Товар A", Price = 1000.0 };
            Product unsoldProduct = new Product { Name = "Товар B", Price = 2000.0 };
            List<Order> orders = new List<Order>
            {
                new Order
                {
                    Id = 1,
                    Items = new List<OrderItem>
                    {
                        new OrderItem { ProductItem = soldProduct.Name, Count = 1, SaleDate = previousMonth }
                    }
                }
            };
            Mock<IOrdersRepository> repository = new Mock<IOrdersRepository>();
            repository.Setup(repo => repo.Load()).Returns(orders);
            ProductsModel model = new ProductsModel();
            model.Load().Clear();
            model.Load().Add(soldProduct);
            model.Load().Add(unsoldProduct);

            model.UpdatePrices(repository.Object);

            repository.Verify(repo => repo.Load(), Times.Once());
            Assert.AreEqual(1000.0, soldProduct.Price);
            Assert.AreEqual(1500.0, unsoldProduct.Price);
        }

        [TestMethod]
        public void UpdatePrices_NullRepository_KeepsPrices()
        {
            ProductsModel model = new ProductsModel();
            model.Load().Clear();
            Product product = new Product { Name = "Товар A", Price = 1000.0 };
            model.Load().Add(product);

            model.UpdatePrices(null);

            Assert.AreEqual(1000.0, product.Price);
        }

        [TestMethod]
        public void UpdatePrices_NoOrders_ReducesPriceBy25Percent()
        {
            ProductsModel model = new ProductsModel();
            model.Load().Clear();
            Product product = new Product { Name = "Товар A", Price = 1000.0 };
            model.Load().Add(product);
            Mock<IOrdersRepository> repository = new Mock<IOrdersRepository>();
            repository.Setup(repo => repo.Load()).Returns(new List<Order>());

            model.UpdatePrices(repository.Object);

            Assert.AreEqual(750.0, product.Price);
        }

        [TestMethod]
        public void UpdatePrices_SaleOnFirstDayOfPreviousMonth_KeepsPrice()
        {
            DateTime today = DateTime.Today;
            DateTime currentMonth = new DateTime(today.Year, today.Month, 1);
            DateTime previousMonth = currentMonth.AddMonths(-1);
            ProductsModel model = new ProductsModel();
            model.Load().Clear();
            Product product = new Product { Name = "Товар A", Price = 1000.0 };
            model.Load().Add(product);
            List<Order> orders = new List<Order>
            {
                new Order
                {
                    Items = new List<OrderItem>
                    {
                        new OrderItem { ProductItem = product.Name, Count = 1, SaleDate = previousMonth }
                    }
                }
            };
            Mock<IOrdersRepository> repository = new Mock<IOrdersRepository>();
            repository.Setup(repo => repo.Load()).Returns(orders);

            model.UpdatePrices(repository.Object);

            Assert.AreEqual(1000.0, product.Price);
        }

        [TestMethod]
        public void UpdatePrices_SaleAtEndOfLastDayOfPreviousMonth_KeepsPrice()
        {
            DateTime today = DateTime.Today;
            DateTime currentMonth = new DateTime(today.Year, today.Month, 1);
            ProductsModel model = new ProductsModel();
            model.Load().Clear();
            Product product = new Product { Name = "Товар A", Price = 1000.0 };
            model.Load().Add(product);
            List<Order> orders = new List<Order>
            {
                new Order
                {
                    Items = new List<OrderItem>
                    {
                        new OrderItem { ProductItem = product.Name, Count = 1, SaleDate = currentMonth.AddTicks(-1) }
                    }
                }
            };
            Mock<IOrdersRepository> repository = new Mock<IOrdersRepository>();
            repository.Setup(repo => repo.Load()).Returns(orders);

            model.UpdatePrices(repository.Object);

            Assert.AreEqual(1000.0, product.Price);
        }

        [TestMethod]
        public void UpdatePrices_SalesOutsidePreviousMonth_ReducesPrice()
        {
            DateTime today = DateTime.Today;
            DateTime currentMonth = new DateTime(today.Year, today.Month, 1);
            DateTime previousMonth = currentMonth.AddMonths(-1);
            ProductsModel model = new ProductsModel();
            model.Load().Clear();
            Product product = new Product { Name = "Товар A", Price = 1000.0 };
            model.Load().Add(product);
            List<Order> orders = new List<Order>
            {
                new Order
                {
                    Items = new List<OrderItem>
                    {
                        new OrderItem { ProductItem = product.Name, Count = 1, SaleDate = previousMonth.AddTicks(-1) }
                    }
                },
                new Order
                {
                    Items = new List<OrderItem>
                    {
                        new OrderItem { ProductItem = product.Name, Count = 1, SaleDate = currentMonth }
                    }
                }
            };
            Mock<IOrdersRepository> repository = new Mock<IOrdersRepository>();
            repository.Setup(repo => repo.Load()).Returns(orders);

            model.UpdatePrices(repository.Object);

            Assert.AreEqual(750.0, product.Price);
        }

        [TestMethod]
        public void UpdatePrices_OnlyOneProductWasSold_DiscountsOnlyUnsoldProduct()
        {
            DateTime today = DateTime.Today;
            DateTime currentMonth = new DateTime(today.Year, today.Month, 1);
            DateTime previousMonth = currentMonth.AddMonths(-1);
            ProductsModel model = new ProductsModel();
            model.Load().Clear();
            Product product = new Product { Name = "Товар A", Price = 1000.0 };
            Product other = new Product { Name = "Товар B", Price = 2000.0 };
            model.Load().Add(product);
            model.Load().Add(other);
            List<Order> orders = new List<Order>
            {
                new Order
                {
                    Items = new List<OrderItem>
                    {
                        new OrderItem { ProductItem = other.Name, Count = 1, SaleDate = previousMonth.AddDays(10) }
                    }
                }
            };
            Mock<IOrdersRepository> repository = new Mock<IOrdersRepository>();
            repository.Setup(repo => repo.Load()).Returns(orders);

            model.UpdatePrices(repository.Object);

            Assert.AreEqual(750.0, product.Price);
            Assert.AreEqual(2000.0, other.Price);
        }

        [TestMethod]
        public void UpdatePrices_AllThreeProductsOrderedThisMonth_DiscountsSecondAndThirdProducts()
        {
            DateTime today = DateTime.Today;
            DateTime currentMonth = new DateTime(today.Year, today.Month, 1);
            DateTime previousMonth = currentMonth.AddMonths(-1);
            DateTime twoMonthsAgo = currentMonth.AddMonths(-2);
            DateTime threeMonthsAgo = currentMonth.AddMonths(-3);
            ProductsModel model = new ProductsModel();
            model.Load().Clear();
            Product first = new Product { Name = "Товар A", Price = 1000.0 };
            Product second = new Product { Name = "Товар B", Price = 2000.0 };
            Product third = new Product { Name = "Товар C", Price = 3000.0 };
            model.Load().Add(first);
            model.Load().Add(second);
            model.Load().Add(third);
            List<Order> orders = new List<Order>
            {
                new Order
                {
                    Items = new List<OrderItem>
                    {
                        new OrderItem { ProductItem = third.Name, Count = 1, SaleDate = threeMonthsAgo }
                    }
                },
                new Order
                {
                    Items = new List<OrderItem>
                    {
                        new OrderItem { ProductItem = second.Name, Count = 1, SaleDate = twoMonthsAgo }
                    }
                },
                new Order
                {
                    Items = new List<OrderItem>
                    {
                        new OrderItem { ProductItem = first.Name, Count = 1, SaleDate = previousMonth }
                    }
                },
                new Order
                {
                    Items = new List<OrderItem>
                    {
                        new OrderItem { ProductItem = first.Name, Count = 1, SaleDate = today },
                        new OrderItem { ProductItem = second.Name, Count = 1, SaleDate = today },
                        new OrderItem { ProductItem = third.Name, Count = 1, SaleDate = today }
                    }
                }
            };
            Mock<IOrdersRepository> repository = new Mock<IOrdersRepository>();
            repository.Setup(repo => repo.Load()).Returns(orders);

            model.UpdatePrices(repository.Object);

            Assert.AreEqual(1000.0, first.Price);
            Assert.AreEqual(1500.0, second.Price);
            Assert.AreEqual(2250.0, third.Price);
        }
    }
}
