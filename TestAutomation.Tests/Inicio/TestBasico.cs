using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
//using OpenQA.Selenium.Firefox;

namespace TestAutomation.Tests.Inicio
{
    [TestFixture]
    public class TestBasico
    {
        [Test]
        public void TestBasicWebPage()
        {
            var driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://curso.testautomation.es";

            var normalLoadWeb = driver.FindElement(By.Id("NormalWeb"));
            normalLoadWeb.Click();
        }

    }
}
