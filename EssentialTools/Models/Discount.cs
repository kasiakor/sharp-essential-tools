using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EssentialTools.Models
{

    //interface defines ApplyDiscount method
    public interface IDiscountHelper
    {
        decimal ApplyDiscount(decimal totalParam);
    }
    //DefaultDiscountHelper implements interface and applies fixed 10% discount
    public class DefaultDiscountHelper : IDiscountHelper
    {

        public decimal ApplyDiscount(decimal totalParam)
        {
            return (totalParam - (10m / 100m * totalParam));
        }
    }
}