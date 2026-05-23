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
        private IWebElement TotalPrice => driver.FindElement(By.Id("totalPrice"));
        private IWebElement ButtonClose => driver.FindElement(By.Id("CloseCart"));
        public ShoppingCartPageObject(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void ClickButtonClose() => ButtonClose.Click();
        public decimal GetTotalPrice() => decimal.Parse(TotalPrice.Text);
        private List<IWebElement> CartItems => driver.FindElements(By.ClassName("cartitem")).ToList();

        public IEnumerable<CartItemWebElement> CartItemWebElements => CartItems.Select(item => new CartItemWebElement(item));
        public decimal GetTotalPriceFromItems() => CartItemWebElements.Sum(item => item.GetTotalPrice());
    }
}