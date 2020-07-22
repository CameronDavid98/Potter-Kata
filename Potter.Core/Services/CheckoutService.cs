using Potter.Domain.Interfaces;
using Potter.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace Potter.Core.Services
{
    public class CheckoutService : ICheckoutService
    {
        private readonly decimal _pricePerBook;
        public IList<IDiscount> Discounts { get; private set; }

        public CheckoutService(decimal pricePerBook, IList<IDiscount> discounts)
        {
            _pricePerBook = pricePerBook;
            Discounts = discounts;
        }

        public decimal CalculateTotal(ShoppingCart cart)
        {
            decimal totalPrice = 0;
            var itemsLeft = cart.Items.Count();

            var bookSets = GetBookSets(cart.Items);

            foreach (var set in bookSets)
            {
                var discount = Discounts.FirstOrDefault(d => d.Quantity == set.Count());
                if (discount != null)
                {
                    itemsLeft -= discount.Quantity;
                    totalPrice += (discount.Quantity * _pricePerBook) * discount.DiscountedPercentage;
                }
                else
                {
                    totalPrice += _pricePerBook;
                }
            }

            return totalPrice;
        }

        private List<List<int>> GetBookSets(IEnumerable<int> books)
        {
            var bookSets = new List<List<int>>() { new List<int>() };

            foreach (var bookNo in books)
            {
                var set = bookSets.FirstOrDefault(x => !x.Contains(bookNo));

                if (set != null)
                {
                    set.Add(bookNo);
                }
                else
                {
                    bookSets.Add(new List<int>() { bookNo });
                }
            }

            return bookSets;
        }
    }
}
