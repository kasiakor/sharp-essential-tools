using System.Collections.Generic;
using System.Linq;

namespace EssentialTools.Models
{
    public class LinqValueCalculatorInterface : IValueCalculator
    {

        private IDiscountHelper discounter;
        //ctor declares dependency on IDiscountHelper interface
        public LinqValueCalculatorInterface(IDiscountHelper discountParam)
        {
            discounter = discountParam;
        }

        //class will calculate the total price of collection of product objects
        public decimal ValueProducts(IEnumerable<Product> products)
        {
            return discounter.ApplyDiscount(products.Sum(e => e.Price));
        }
    }
}