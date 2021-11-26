using NUnit.Framework;
using System;
using System.Collections.Generic;
using ShoppingCart;
using ShoppingCart.Models;

namespace TestBasket
{
    public class BasketDiscountTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestBasketNoDiscount()
        {

            //create basket
            Basket basket = new Basket();
            List<BasketItem> _products = new List<BasketItem>();
            _products = basket.GenerateBasket();


            //enable discounts
            DiscountList discounts = new DiscountList(false, false, false);
            List<Discount> discountsList = discounts.Discounts;

            //apply discount
            _products = basket.ApplyDiscountToBasket(_products, discountsList);

            //calculate total to pay with discounts applied
            Decimal totalDiscountBasketValue = basket.totalDiscountedBasket(_products);


            Assert.AreEqual(111.5, totalDiscountBasketValue);
        }

        [Test]
        public void TestSpend50Get10()
        {

            //create basket
            Basket basket = new Basket();
            List<BasketItem> _products = new List<BasketItem>();
            _products = basket.GenerateBasket();

            //enable discounts
            DiscountList discounts = new DiscountList(true,  false, true);
            List<Discount> discountsList = discounts.Discounts;

            //apply discount
             _products = basket.ApplyDiscountToBasket(_products, discountsList);

            //calculate total to pay with discounts applied
            Decimal totalDiscountBasketValue = basket.totalDiscountedBasket(_products);

            Assert.AreEqual(100.35, totalDiscountBasketValue);
        }

        [Test]
        public void TestLargeDiscount()
        {

            //create basket
            Basket basket = new Basket();
            List<BasketItem> _products = new List<BasketItem>();
            _products = basket.GenerateBasket();

            //enable discounts
            DiscountList discounts = new DiscountList(false, false, true);
            List<Discount> discountsList = discounts.Discounts;

            //apply discount
            _products = basket.ApplyDiscountToBasket(_products, discountsList);

            //calculate total to pay with discounts applied
            Decimal totalDiscountBasketValue = basket.totalDiscountedBasket(_products);

            Assert.AreEqual(111.5, totalDiscountBasketValue);
        }

        [Test]
        public void TestAllDiscounts()
        {

            //create basket
            Basket basket = new Basket();
            List<BasketItem> _products = new List<BasketItem>();
            _products = basket.GenerateBasket();

            //enable discounts
            DiscountList discounts = new DiscountList(true, true, true);
            List<Discount> discountsList = discounts.Discounts;

            //apply discount
            _products = basket.ApplyDiscountToBasket(_products, discountsList);

            //calculate total to pay with discounts applied
            Decimal totalDiscountBasketValue = basket.totalDiscountedBasket(_products);

            Assert.AreEqual(81.9, totalDiscountBasketValue);
        }
    }
}