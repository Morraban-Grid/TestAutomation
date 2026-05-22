using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace TestAutomation.Tests.PageObjectPattern.PageObject.ShoppingCart
{
    public class ShoppingCartPageObject
    {
        private readonly IWebDriver driver;
        public ShoppingCartPageObject(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}