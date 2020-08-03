using System.Collections.Generic;

namespace EssentialTools.Models
{
    public class ShoppingCartInterface
    {

        private IValueCalculator calc;

        public ShoppingCartInterface(IValueCalculator calcParam)
        {
            calc = calcParam;
        }

        public IEnumerable<Product> Products { get; set; }

        public decimal CalculateProductTotal()
        {
            return calc.ValueProducts(Products);
        }
    }
}
