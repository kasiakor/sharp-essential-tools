using EssentialTools.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Moq;


namespace EssentialTools.Tests
{
    [TestClass]
    public class UnitTest2
    {

        private Product[] products = {
            new Product {Name = " Kayak", Category = "Watersports", Price = 2M},
            new Product {Name = "Lifejacket", Category = "Watersports", Price = 4M},
            new Product {Name = "Soccer ball", Category = "Soccer", Price = 14M},
            new Product {Name = "Corner flag", Category = "Soccer", Price = 30M}
            };
        [TestMethod]
        public void Sum_Products_Correctly()
        {
            // arrange
            //create a strongly typed Mock<IDiscountHelper> object, which tells the Moq library the type it will be handling.
            //this is the IDiscountHelper interface for unit test
            Mock<IDiscountHelper> mock = new Mock<IDiscountHelper>();

            //method to test - LinqValueCalculatorInterface
            //establish a baseline behavior (select a method - ApplyDiscount )in the mock object  to test the functionality of the target object in the unit test
            //add parameter values 
            //specify the type of result using type param (decimal) and result itself using lambda expression
            //moq will pass the value recieved in applydiscount method - we receive a value passed through total => total
            mock.Setup(m => m.ApplyDiscount(It.IsAny<decimal>()))
            .Returns<decimal>(total => total);

            // use the mock object in the unit test  by reading the value of the Object property of the Mock < IDiscountHelper > object
            //the Object property returns an implementation of the IDiscountHelper interface where the ApplyDiscount method returns the value of the decimal parameter it is passed
            var target = new LinqValueCalculatorInterface(mock.Object);

            // act
            var result = target.ValueProducts(products);

            // assert
            Assert.AreEqual(products.Sum(e => e.Price), result);
        }
    }
}

