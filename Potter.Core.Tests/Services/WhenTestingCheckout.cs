using Microsoft.VisualStudio.TestTools.UnitTesting;
using Potter.Core.Discounts;
using Potter.Core.Services;
using Potter.Domain.Interfaces;
using Potter.Domain.Models;
using System.Collections.Generic;

namespace Potter.Core.Tests.Services
{
    [TestClass]
    public class WhenTestingCheckout
    {
        private List<IDiscount> _discounts;
        private Dictionary<int, decimal> _prices;

        public WhenTestingCheckout()
        {
            _discounts = new List<IDiscount>()
            {
                new Discount(2, 0.95m),
                new Discount(3, 0.90m),
                new Discount(4, 0.80m),
                new Discount(5, 0.75m)
            };

            _prices = new Dictionary<int, decimal>()
            {
                { 1 ,8m },
                { 2 ,8m },
                { 3 ,8m },
                { 4 ,8m },
                { 5 ,8m },
            };
        }

        [TestMethod]
        public void Given8BooksItShouldApply2Discounts()
        {
            //Arrange
            ICheckoutService checkout = new CheckoutService(_prices, _discounts);
            var cart = new ShoppingCart()
            {
                Items = new[] { 1, 1, 2, 2, 3, 3, 4, 5 }
            };
            var expectedResult = 51.60m;

            //Act
            var result = checkout.CalculateTotal(cart);

            //Assert
            Assert.AreEqual(expectedResult, result);

        }

        [TestMethod]
        public void Given1BookItShouldReturnFullPrice()
        {
            //Arrange
            ICheckoutService checkout = new CheckoutService(_prices, _discounts);
            var cart = new ShoppingCart()
            {
                Items = new[] { 1 }
            };
            var expectedResult = 8m;

            //Act
            var result = checkout.CalculateTotal(cart);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Given2SameBooksItShouldReturnFullPrice()
        {
            //Arrange
            ICheckoutService checkout = new CheckoutService(_prices, _discounts);
            var cart = new ShoppingCart()
            {
                Items = new[] { 1, 1 }
            };
            var expectedResult = 16m;

            //Act
            var result = checkout.CalculateTotal(cart);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Given2DifferentBooksItShouldReturnDiscountedPrice()
        {
            //Arrange
            ICheckoutService checkout = new CheckoutService(_prices, _discounts);
            var cart = new ShoppingCart()
            {
                Items = new[] { 1, 2 }
            };
            var expectedResult = 15.2m;

            //Act
            var result = checkout.CalculateTotal(cart);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Given3DifferentBooksItShouldReturnDiscountedPrice()
        {
            //Arrange
            ICheckoutService checkout = new CheckoutService(_prices, _discounts);
            var cart = new ShoppingCart()
            {
                Items = new[] { 1, 2, 3 }
            };
            var expectedResult = 21.6m;

            //Act
            var result = checkout.CalculateTotal(cart);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Given4DifferentBooksItShouldReturnDiscountedPrice()
        {
            //Arrange
            ICheckoutService checkout = new CheckoutService(_prices, _discounts);
            var cart = new ShoppingCart()
            {
                Items = new[] { 1, 2, 3, 4 }
            };
            var expectedResult = 25.6m;

            //Act
            var result = checkout.CalculateTotal(cart);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Given5DifferentBooksItShouldReturnDiscountedPrice()
        {
            //Arrange
            ICheckoutService checkout = new CheckoutService(_prices, _discounts);
            var cart = new ShoppingCart()
            {
                Items = new[] { 1, 2, 3, 4, 5 }
            };
            var expectedResult = 30m;

            //Act
            var result = checkout.CalculateTotal(cart);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Given3BooksItShouldReturnDiscountedPrice()
        {
            //Arrange
            ICheckoutService checkout = new CheckoutService(_prices, _discounts);
            var cart = new ShoppingCart()
            {
                Items = new[] { 1, 2, 2  }
            };
            var expectedResult = 23.2m;

            //Act
            var result = checkout.CalculateTotal(cart);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}
