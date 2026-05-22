using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAutomation.Tests.PageObjectPattern.Helpers;
using TestAutomation.Tests.PageObjectPattern.Models;

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
        private IWebElement ShoppingCartIcon => driver.FindElement(By.Id("carticon"));
        public int GetShoppingCartIconNumberOfItems() => int.Parse(ShoppingCartIcon.Text);
        // Para abrir el carrito de compras
        public void ClickShoppingCartIcon()
        {
            ShoppingCartIcon.Click();
        }


    }

}
