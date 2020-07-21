using Potter.Domain.Interfaces;
using Potter.Domain.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Potter.Core.Services
{
    public class CheckoutService : ICheckoutService
    {

        public IDictionary<int, decimal> Prices { get; private set; }
        public IList<IDiscount> Discounts { get; private set; }

        public CheckoutService(IDictionary<int, decimal> prices, IList<IDiscount> discounts)
        {
            Prices = prices;
            Discounts = discounts;
        }

        public decimal CalculateTotal(ShoppingCart cart)
        {
            decimal totalPrice = 0;

            foreach (var item in cart.Items)
            {
                totalPrice += Prices[item];
            }

            foreach (var discount in Discounts)
            {
                var distinctItems = cart.Items.Distinct();

                if(distinctItems.Count() == discount.Quantity)
                {
                    totalPrice *= discount.DiscountedPercentage;
                }
            }

            return totalPrice;
        }
    }
}
