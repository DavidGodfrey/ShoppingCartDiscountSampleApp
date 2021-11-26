using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Models
{
    public class Discount
    {
        public int ID { get; set; }

        public string Name  { get; set; }

        public bool Enabled { get; set; }

        public string Description { get; set; }

        public Discount()
        {

        }
    }

    public class DiscountList
    {
        public List<Discount> Discounts { get; set; }

        public DiscountList(bool _PercentDiscount = false, bool _QuantityDiscount = false, bool _LargeQuantityDiscount = false)
        {
            List<Discount> discountList = new List<Discount>();
            discountList.Add(new Discount { ID = 1, Name = "PercentDiscount", Enabled = _PercentDiscount, Description = "Deduct 10% from original price if basket total is equal to or more than £50" });
            discountList.Add(new Discount { ID = 1, Name = "QuantityDiscount", Enabled = _QuantityDiscount, Description = "Apply 3 for 2 on each item" });
            discountList.Add(new Discount { ID = 1, Name = "LargeQuantityDiscount", Enabled = _LargeQuantityDiscount, Description = "Deduct 10% from original price if total basket qty is greater than 10 items" });

            Discounts = discountList;
        }
    }
}
