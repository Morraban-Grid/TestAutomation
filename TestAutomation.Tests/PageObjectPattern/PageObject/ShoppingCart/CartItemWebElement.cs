using OpenQA.Selenium;
namespace TestAutomation.Tests.PageObjectPattern.PageObject.ShoppingCart
{
    public class CartItemWebElement
    {
        private IWebElement element;
        private IWebElement ButtonRemove => element.FindElement(By.CssSelector("button"));
        private IWebElement InfoText => element.FindElement(By.CssSelector("span"));
        private IWebElement InputFieldQuantity => element.FindElement(By.CssSelector("input"));
        public CartItemWebElement(IWebElement element)
        {
            this.element = element;
        }
        public void ClickButtonRemove() => ButtonRemove.Click();
        public string GetText() => InfoText.Text;
        public void InputQuantity(int quantity)
        {
            InputFieldQuantity.Clear();
            InputFieldQuantity.SendKeys(quantity.ToString());
            InputFieldQuantity.SendKeys(Keys.Tab);
        }

        public int GetQuantity() => int.Parse(InputFieldQuantity.GetAttribute("value"));
        public decimal GetTotalPrice() => GetQuantity() * GetPrice();
        public decimal GetPrice() => decimal.Parse(InfoText.Text.Split(" ")[1]);

    }
}