using Potter.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Potter.Domain.Interfaces
{
    public interface IDiscount
    {
        decimal DiscountedPercentage { get; set; }

        int Quantity { get; set; }
    }
}
