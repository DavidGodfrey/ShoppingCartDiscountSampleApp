using System;
using System.Collections.Generic;
using System.Text;
using ShoppingCart.Models;
using System.Reflection;
using System.Linq;

namespace ShoppingCart
{
    public class Basket
    {
        

        public List<BasketItem> GenerateBasket()
        {
            List<BasketItem> basketItems = new List<BasketItem>();
            basketItems.Add(new BasketItem { ID = 1, Name = "t-shirt", Price = 10, Quantity = 2, DiscountedPrice = 10 });
            basketItems.Add(new BasketItem { ID = 2, Name = "shoes", Price = 20.50M, Quantity = 3, DiscountedPrice = 20.50M });
            basketItems.Add(new BasketItem { ID = 3, Name = "pants", Price = 30, Quantity = 1, DiscountedPrice = 30 });

            return basketItems;

        }

        public List<BasketItem> ApplyDiscountToBasket(List<BasketItem> basket, List<Discount> discounts)
        {

            var type = typeof(IDiscount);
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p));

            foreach (Type _type in types)
            {
                
                Type t = _type;
                //check discount is enabled before applying it
                if (discounts.Where(x => x.Name == t.Name && x.Enabled).Any())
                {
                    var methodNames = type.GetMethods()
                                .Select(x => x.Name)
                                .Distinct()
                                .OrderBy(x => x);

                    foreach(String _method in methodNames)
                    {
                        //check if discount enabled
                      
                            ConstructorInfo discountConstructor = t.GetConstructor(Type.EmptyTypes);
                            object discountClassObject = discountConstructor.Invoke(new object[] { });

                            MethodInfo discountMethod = t.GetMethod("applyDiscount");
                            object discountValue = discountMethod.Invoke(discountClassObject, new object[] { basket });
                        
                    }
 
                }
                
                
            }

            return basket;
        }

        public Decimal totalBasket(List<BasketItem> basket)
        {
            Decimal _total = 0;
            foreach (BasketItem product in basket)
            {
                _total = _total + (product.Price * product.Quantity);
            }

            return _total;
        }
        public Decimal totalDiscountedBasket(List<BasketItem> basket)
        {
            Decimal _total = 0;
            foreach (BasketItem product in basket)
            {
                _total = _total + (product.DiscountedPrice * product.Quantity);
            }

            return _total;
        }

    }
}
