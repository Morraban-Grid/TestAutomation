using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
namespace TestAutomation.Tests.PageObjectPattern.Factories
{
    public static class WebDriverFactory
    {
        public static IWebDriver GetWebDriver(string browsername)
        {
            switch (browsername)
            {
                case "edge": return new EdgeDriver();
                case "chrome": return new ChromeDriver();
                case "firefox": return new FirefoxDriver();
                default:
                    throw new NotSupportedException($"The browser {browsername} is not supported");
            }
        }
    }
}