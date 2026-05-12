using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAutomation.Tests.PageObjectPattern.Models;

namespace TestAutomation.Tests.PageObjectPattern.PageObject.HomePage
{
    public class HomePageObject
    {
        //definiendo el driver
        //para las frutas que seran una lista

        private readonly IWebDriver driver; 
        private List<IWebElement> DisplayedFruits => driver.FindElements(By.ClassName("fruit")).Where(fruit => fruit.Displayed).ToList();
    }
}
