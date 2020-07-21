using Potter.Repository.Interfaces;
using System.Collections.Generic;

namespace Potter.Repository
{
    public class PriceRepository : IPriceRepository
    {
        public IDictionary<int, decimal> GetPrices()
        {
            return new Dictionary<int, decimal>()
            {
                { 1, 8m },
                { 2, 8m },
                { 3, 8m },
                { 4, 8m },
                { 5, 8m }
            };
        }
    }
}
