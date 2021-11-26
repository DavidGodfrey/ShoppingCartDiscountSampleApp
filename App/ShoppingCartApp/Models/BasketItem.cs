using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Models
{
    public class BasketItem : Product
    {
        public Decimal DiscountedPrice { get; set; }
    }
}
