using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAutomation.Tests.PageObjectPattern.Helpers;
using TestAutomation.Tests.PageObjectPattern.Models;
using TestAutomation.Tests.PageObjectPattern.PageObject.ShoppingCart;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TestAutomation.Tests.PageObjectPattern.PageObject.HomePage
{
    public class HomePageObject
    {
        //definiendo el driver
        //para las frutas que seran una lista

        private readonly IWebDriver driver;

        private List<IWebElement> DisplayedFruits => driver.FindElements(By.ClassName("fruit")).Where(fruit => fruit.Displayed).ToList();

        // definimos el contructor
        public HomePageObject(IWebDriver driver)
        {
            this.driver = driver;
        }

        

        //Mostramos la lista de frutas
        public IList<FruitWebElement> DisplayedFruitWebElements()
        {
            return FruitHelper.Parse(DisplayedFruits);
        }

        // Método que muestre la lista de frutas
        public IList<FruitModel> DisplayedFruitModel() => FruitHelper.Parse(DisplayedFruitWebElements());

        public PageBarWebElement PageNavegation => new PageBarWebElement(driver);

        // Método que devulve la lista de frutas
        public IList<FruitModel> DisplayedFruitModels() => FruitHelper.Parse(DisplayedFruitWebElements());
        // Métodos para el segundo test
        public SearchBarWebElement SearchBar => new SearchBarWebElement(driver);

        // Método para el carrito de compras: Test 3
        private IWebElement ShoppingCartIcon => driver.FindElement(By.Id("cart-icon"));
        public bool IsShoppingCartIconNumberOfItems(int number)
        {
            try
            {
                WaitHelper.WaitForCondition(() =>
                int.Parse(ShoppingCartIcon.Text).Equals(number));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        // Para abrir el carrito de compras
        public ShoppingCartPageObject ClickShoppingCartIcon()
        {
            ShoppingCartIcon.Click();
            return new ShoppingCartPageObject(driver);
        }

        public ShoppingCartPageObject ClickShoppingCartIcon()
        {
            ShoppingCartIcon.Click();
            return new ShoppingCartPageObject(driver);
        }

        // Para el 4 test: verificar que el carrito se vacia al hacer click en el icono del carrito
        private IWebElement ButtonContactUs => driver.FindElement(By.Id("openContactPopup"));

    }

}
