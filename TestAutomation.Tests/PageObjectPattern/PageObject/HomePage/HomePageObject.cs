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

        // definimos el contructor
        public HomePageObject(IWebDriver driver)
        {
            this.driver = driver;
        }

        private List<IWebElement> DisplayedFruits => driver.FindElements(By.ClassName("fruit")).Where(fruit => fruit.Displayed).ToList();

        //Mostramos la lista de frutas
        public IList<FruitWebElement> DisplayedFruitWebElements()
        {
            return FruitHelper.Parse(DisplayedFruits);
        }


    }

}
