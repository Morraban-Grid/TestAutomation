using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace TestAutomation.Tests.PageObjectPattern.PageObject.HomePage
{
    public class SearchBarWebElement
    {
        private readonly IWebDriver driver;
        // Definimos el constructor
        public SearchBarWebElement(IWebDriver driver)
        {
            this.driver = driver;
        }


        // La barra de input y el botón de search son elementos web,
        // por lo que los definimos como propiedades privadas
        private IWebElement InputSearchProduct =>
        driver.FindElement(By.Id("product-search"));
        private IWebElement ButtonSearch => driver.FindElement(By.Id("search-button"));
        // acciones del input y boton search
        public SearchBarWebElement InputSearch(string termToSearch)
        {
            InputSearchProduct.Clear();
            InputSearchProduct.SendKeys(termToSearch);
            return this;
        }
        //pulsamos click sobre el boton
        public HomePageObject ClickSearch()
        {
            ButtonSearch.Click();
            return new HomePageObject(driver);
        }
        //pulsando Enter
        public HomePageObject ClickEnter()
        {
            new Actions(driver).SendKeys(Keys.Enter).Perform();
            return new HomePageObject(driver);
        }
    }
}