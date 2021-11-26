using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Models
{
    public class Product
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public Decimal Price { get; set; }

        public int Quantity { get; set; }

    }
}
