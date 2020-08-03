using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EssentialTools.Models
{
    public class LinqValueCalculator
    {
        //class will calculate the total price of collection of Product objects
        public decimal ValueProducts(IEnumerable<Product> products)
        {
            return products.Sum(e => e.Price);
        }
    }
}