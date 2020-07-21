using Potter.Domain.Interfaces;
using Potter.Domain.Models;
using System.Linq;

namespace Potter.Core.Discounts
{
    public class Discount : IDiscount
    {
        public decimal DiscountedPercentage { get; set; }

        public int Quantity { get; set; }

        public Discount(int quantity, decimal discountedPercentage)
        {
            Quantity = quantity;
            DiscountedPercentage = discountedPercentage;
        }
    }
}
