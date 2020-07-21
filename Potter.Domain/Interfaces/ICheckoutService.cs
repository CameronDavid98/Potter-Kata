using Potter.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Potter.Domain.Interfaces
{
    public interface ICheckoutService
    {
        IDictionary<int, decimal> Prices { get; }
        IList<IDiscount> Discounts { get;  } 
        decimal CalculateTotal(ShoppingCart cart);
    }
}
