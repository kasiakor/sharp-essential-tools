﻿using EssentialTools.Models;
using System.Web.Mvc;
using Ninject;

namespace EssentialTools.Controllers
{
    public class HomeController : Controller
    {

        private Product[] products = {
        new Product {Name = " Kayak", Category = "Watersports", Price = 27.50M},
        new Product {Name = "Lifejacket", Category = "Watersports", Price = 48.95M},
        new Product {Name = "Soccer ball", Category = "Soccer", Price = 19.50M},
        new Product {Name = "Corner flag", Category = "Soccer", Price = 34.95M}
};
        // GET: Home
        public ActionResult Index()
        {
            //LinqValueCalculator calc = new LinqValueCalculator();

            //NINJECT 
            //create an instance of the kernel, object that is resolving dependencies and creating new objects
            IKernel ninjectKernel = new StandardKernel();

            //bing interface with implementation object
            //inetrface as a type, clas as a type
            //dependecies should be resolved by creating an instance of the LinqValueCalculator class
            ninjectKernel.Bind<IValueCalculator>().To<LinqValueCalculatorInterface>();

            //use Get method to create an object
            IValueCalculator calc = ninjectKernel.Get<IValueCalculator>();

            ShoppingCartInterface cart = new ShoppingCartInterface(calc) { Products = products };
            decimal totalValue = cart.CalculateProductTotal();

            return View(totalValue);
        }

        public ActionResult UseInterface()
        {
            IValueCalculator calc = new LinqValueCalculatorInterface();
            ShoppingCartInterface cart = new ShoppingCartInterface(calc) { Products = products };
            decimal totalValue = cart.CalculateProductTotal();

            return View(totalValue);
        }
    }
}