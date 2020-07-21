using System;
using System.Collections.Generic;
using System.Text;

namespace Potter.Repository.Interfaces
{
    public interface IPriceRepository
    {
        IDictionary<int, decimal> GetPrices();
    }
}
