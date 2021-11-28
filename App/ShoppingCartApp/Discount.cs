using System;
using System.Collections.Generic;
using System.Text;
using ShoppingCart.Models;

namespace ShoppingCart
{

    public interface IDiscount
    {
        public List<BasketItem> applyDiscount(List<BasketItem> products);
   
    }

    public class PercentDiscount : IDiscount
    {

        public PercentDiscount()
        {

        }

        //if total spend is > £50 then deduct 10%
        public List<BasketItem> applyDiscount(List<BasketItem> products)
        {
           
            Decimal total = 0;

            foreach (Product product in products)
            {
                total = total + product.Price;
            }

            if (total > 50)
            {
                DiscountFunctions df = new DiscountFunctions();
                df.applyPercentDiscount(products, 10);
            }

            return products;
        }

    }

    public class QuantityDiscount : IDiscount
    {

        public QuantityDiscount()
        {

        }

        //3-4-2 discount
        public List<BasketItem> applyDiscount(List<BasketItem> products)
        {
            

            foreach (Product product in products)
            {
                int noOfDivisions = product.Quantity / 3;

                if (product.Quantity >= 3)
                {
                    product.Quantity = product.Quantity - (1 * noOfDivisions);
                }
            }


            return products;
        }


    }

    public class LargeQuantityDiscount :IDiscount
    {
        public LargeQuantityDiscount()
        {

        }

        //if total quantity of products in basket is over 10 then remove a further 10%
        public List<BasketItem> applyDiscount(List<BasketItem> products)
        {
            int productcount = 0;
            foreach (Product product in products)
            {
                productcount = productcount + product.Quantity;
            }

            if(productcount > 9)
            {
                DiscountFunctions df = new DiscountFunctions();
                df.applyPercentDiscount(products, 10);
            }

            return products;
        }


        }

    internal class DiscountFunctions
    {
        public List<BasketItem> applyPercentDiscount(List<BasketItem> products, int percentDiscount)
        {
            int percentToPay = 100 - percentDiscount;

            foreach (BasketItem product in products)
            {
                Decimal amountToReduce = (product.Price / 100) * percentDiscount;
                product.DiscountedPrice = product.DiscountedPrice - amountToReduce;
            }

            return products;
        }
    }

    

}
