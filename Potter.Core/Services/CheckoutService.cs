using Potter.Domain.Interfaces;
using Potter.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using Potter.Core.Extentions;

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

            var bookSets = cart.Items.DistinctSplit();

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
    }
}
