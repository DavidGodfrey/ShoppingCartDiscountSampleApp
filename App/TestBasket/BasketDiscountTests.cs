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

        //test basket total works with no discounts applied
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

        //spend 50 get 10 percent off test
        [Test]
        public void TestSpend50Get10()
        {

            //create basket
            Basket basket = new Basket();
            List<BasketItem> _products = new List<BasketItem>();
            _products = basket.GenerateBasket();

            //enable discounts
            DiscountList discounts = new DiscountList(true,  false, false);
            List<Discount> discountsList = discounts.Discounts;

            //apply discount
             _products = basket.ApplyDiscountToBasket(_products, discountsList);

            //calculate total to pay with discounts applied
            Decimal totalDiscountBasketValue = basket.totalDiscountedBasket(_products);

            Assert.AreEqual(100.35, totalDiscountBasketValue);
        }

        //test large discount isnt applied as basket doesn't contain enough products
        [Test]
        public void TestLargeDiscount6Products()
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

        //test large discount is applied as basket contains enough products
        [Test]
        public void TestLargeDiscount25Products()
        {

            //create basket
            Basket basket = new Basket();
            List<BasketItem> _products = new List<BasketItem>();
            _products = basket.GenerateLargeBasket();

            //enable discounts
            DiscountList discounts = new DiscountList(false, false, true);
            List<Discount> discountsList = discounts.Discounts;

            //apply discount
            _products = basket.ApplyDiscountToBasket(_products, discountsList);

            //calculate total to pay with discounts applied
            Decimal totalDiscountBasketValue = basket.totalDiscountedBasket(_products);

            Assert.AreEqual(613.35, totalDiscountBasketValue);
        }

        //test all discounts at the same time on smaller basket
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

        //test all discounts at the same time on smaller basket (overall discount should include 3-4-2 and 20% overall discount)
        [Test]
        public void TestAllDiscountsLargeBasket()
        {

            //create basket
            Basket basket = new Basket();
            List<BasketItem> _products = new List<BasketItem>();
            _products = basket.GenerateLargeBasket();

            //enable discounts
            DiscountList discounts = new DiscountList(true, true, true);
            List<Discount> discountsList = discounts.Discounts;

            //apply discount
            _products = basket.ApplyDiscountToBasket(_products, discountsList);

            //calculate total to pay with discounts applied
            Decimal totalDiscountBasketValue = basket.totalDiscountedBasket(_products);

            Assert.AreEqual(384.8, totalDiscountBasketValue);
        }
    }
}