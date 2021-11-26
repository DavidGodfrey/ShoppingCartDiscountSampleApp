using System;
using System.Collections.Generic;
using ShoppingCart.Models;

namespace ShoppingCart
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Basket basket = new Basket();

            //create basket
            List<BasketItem> _products = new List<BasketItem>();
            _products = basket.GenerateBasket();

            //enable discounts
            DiscountList discounts = new DiscountList(true, true, false);
            List<Discount> discountsList = discounts.Discounts;

            //apply discount
            _products  = basket.ApplyDiscountToBasket(_products, discountsList);

            Decimal totalBasketValue = basket.totalBasket(_products);
            Decimal totalDiscountBasketValue = basket.totalDiscountedBasket(_products);

            //return result
            var indent = new string(' ', 1 * 8);
            Console.WriteLine("Total Basket Value: $" + totalBasketValue.ToString("0.00"));
            Console.WriteLine("Total Discounted Basket Value: $" + totalDiscountBasketValue.ToString("0.00"));
            Console.WriteLine("Discounts Applied:");
            foreach (Discount discount in discountsList)
            {
                if (discount.Enabled) { 
                Console.WriteLine(indent + discount.Name);
                }
            }
        }


    }
}
