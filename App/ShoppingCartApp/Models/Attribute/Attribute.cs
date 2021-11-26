using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Models.Attribute
{
    internal class Attribute
    {
        [AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
        public class Enabled : System.Attribute
        {
        }

    }
}
