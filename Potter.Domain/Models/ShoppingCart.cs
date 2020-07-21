using System;
using System.Collections.Generic;
using System.Text;

namespace Potter.Domain.Models
{
    public class ShoppingCart
    {
        public IEnumerable<int> Items { get; set; }
    }
}
