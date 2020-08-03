using System.Collections.Generic;
using System.Linq;

namespace EssentialTools.Models
{
    public class LinqValueCalculatorInterface : IValueCalculator
    {
        //class will calculate the total price of collection of Product objects
        public decimal ValueProducts(IEnumerable<Product> products)
        {
            return products.Sum(e => e.Price);
        }
    }
}