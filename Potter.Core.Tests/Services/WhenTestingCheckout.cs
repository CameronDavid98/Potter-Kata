using Microsoft.VisualStudio.TestTools.UnitTesting;
using Potter.Core.Discounts;
using Potter.Core.Services;
using Potter.Domain.Globals;
using Potter.Domain.Interfaces;
using Potter.Domain.Models;
using System.Collections.Generic;

namespace Potter.Core.Tests.Services
{
    [TestClass]
    public class WhenTestingCheckout
    {
        private List<IDiscount> _discounts;
        private decimal _pricePerBook;

        public WhenTestingCheckout()
        {
            _discounts = new List<IDiscount>()
            {
                new Discount(2, 0.95m),
                new Discount(3, 0.90m),
                new Discount(4, 0.80m),
                new Discount(5, 0.75m)
            };

            _pricePerBook = 8m;
        }

        [TestMethod]
        public void Given8BooksItShouldApply2Discounts()
        {
            //Arrange
            ICheckoutService checkout = new CheckoutService(_pricePerBook, _discounts);
            var cart = new ShoppingCart()
            {
                Items = new[] { PotterBooks.FIRST, PotterBooks.FIRST, PotterBooks.SECOND, PotterBooks.SECOND, PotterBooks.THIRD, PotterBooks.THIRD, PotterBooks.FOURTH, PotterBooks.FIFTH }
            };
            var expectedResult = 51.60m;

            //Act
            var result = checkout.CalculateTotal(cart);

            //Assert
            Assert.AreEqual(expectedResult, result);

        }

        [TestMethod]
        public void Given6BooksItShouldApply2Discounts()
        {
            //Arrange
            ICheckoutService checkout = new CheckoutService(_pricePerBook, _discounts);
            var cart = new ShoppingCart()
            {
                Items = new[] { PotterBooks.FIRST, PotterBooks.FIRST, PotterBooks.SECOND, PotterBooks.SECOND, PotterBooks.THIRD, PotterBooks.THIRD }
            };
            var expectedResult = 43.2m;

            //Act
            var result = checkout.CalculateTotal(cart);

            //Assert
            Assert.AreEqual(expectedResult, result);

        }

        [TestMethod]
        public void Given12BooksItShouldApply2Discounts()
        {
            //Arrange
            ICheckoutService checkout = new CheckoutService(_pricePerBook, _discounts);
            var cart = new ShoppingCart()
            {
                Items = new[] { PotterBooks.FIRST, PotterBooks.FIRST, PotterBooks.SECOND, PotterBooks.SECOND, PotterBooks.THIRD, PotterBooks.THIRD, PotterBooks.FIRST,
                                PotterBooks.FIRST, PotterBooks.SECOND, PotterBooks.SECOND, PotterBooks.THIRD, PotterBooks.THIRD }
            };
            var expectedResult = 86.4m;

            //Act
            var result = checkout.CalculateTotal(cart);

            //Assert
            Assert.AreEqual(expectedResult, result);

        }

        [TestMethod]
        public void Given4BooksItShouldApply2Discounts()
        {
            //Arrange
            ICheckoutService checkout = new CheckoutService(_pricePerBook, _discounts);
            var cart = new ShoppingCart()
            {
                Items = new[] { PotterBooks.FOURTH, PotterBooks.FOURTH, PotterBooks.FIFTH, PotterBooks.FIFTH}
            };
            var expectedResult = 30.4m;

            //Act
            var result = checkout.CalculateTotal(cart);

            //Assert
            Assert.AreEqual(expectedResult, result);

        }

        [TestMethod]
        public void Given1BookItShouldReturnFullPrice()
        {
            //Arrange
            ICheckoutService checkout = new CheckoutService(_pricePerBook, _discounts);
            var cart = new ShoppingCart()
            {
                Items = new[] { PotterBooks.FIRST }
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
            ICheckoutService checkout = new CheckoutService(_pricePerBook, _discounts);
            var cart = new ShoppingCart()
            {
                Items = new[] { PotterBooks.FIRST, PotterBooks.FIRST }
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
            ICheckoutService checkout = new CheckoutService(_pricePerBook, _discounts);
            var cart = new ShoppingCart()
            {
                Items = new[] { PotterBooks.FIRST, PotterBooks.SECOND }
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
            ICheckoutService checkout = new CheckoutService(_pricePerBook, _discounts);
            var cart = new ShoppingCart()
            {
                Items = new[] { PotterBooks.FIRST, PotterBooks.SECOND, PotterBooks.THIRD }
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
            ICheckoutService checkout = new CheckoutService(_pricePerBook, _discounts);
            var cart = new ShoppingCart()
            {
                Items = new[] { PotterBooks.FIRST, PotterBooks.SECOND, PotterBooks.THIRD, PotterBooks.FOURTH }
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
            ICheckoutService checkout = new CheckoutService(_pricePerBook, _discounts);
            var cart = new ShoppingCart()
            {
                Items = new[] { PotterBooks.FIRST, PotterBooks.SECOND, PotterBooks.THIRD, PotterBooks.FOURTH, PotterBooks.FIFTH }
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
            ICheckoutService checkout = new CheckoutService(_pricePerBook, _discounts);
            var cart = new ShoppingCart()
            {
                Items = new[] { PotterBooks.FIRST, PotterBooks.SECOND, PotterBooks.SECOND }
            };
            var expectedResult = 23.2m;

            //Act
            var result = checkout.CalculateTotal(cart);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Given0BooksItShouldReturn0()
        {
            //Arrange
            ICheckoutService checkout = new CheckoutService(_pricePerBook, _discounts);
            var cart = new ShoppingCart()
            {
                Items = new int[0]
            };
            var expectedResult = 0m;

            //Act
            var result = checkout.CalculateTotal(cart);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}
