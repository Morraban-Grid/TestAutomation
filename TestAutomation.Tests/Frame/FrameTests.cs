using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace TestAutomation.Tests.Frame
{
    public class FrameTests
    {
        #pragma warning disable NUnit1032
        IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            driver.Url = "http://curso.testautomation.es";
        }

        [TearDown]
        public void TearDownTest()
        {
            driver.Quit();
        }

        [Test]
        public void FrameTest()
        {
            /*
            driver.FindElement(By.Id("DifferentFrames"));
            var webElement = driver.FindElement(By.CssSelector("h2"));
            */


            // Hacemos click en la primera sección de la página de inicio
            // y luego vamos a la segunda sección, que es la de los frames
            driver.FindElement(By.Id("DifferentFrames")).Click();
            // Hacemos click en el botón de la segunda página para cargar el frame
            // Se muestran los iframes disponibles en la página
            driver.FindElement(By.CssSelector("button")).Click();
            // Nos ubicamos en el primer iframe
            driver.SwitchTo().Frame(0);
            // Obtenemos el valor del texto
            var webElementLeft = driver.FindElement(By.CssSelector("h2")).Text;
            // Para el segundo iframe, primero volvemos al contexto principal
            // y luego nos ubicamos en el segundo iframe
            driver.SwitchTo().DefaultContent();
            driver.SwitchTo().Frame(1);
            // Obtenemos el valor del texto
            var webElementRight = driver.FindElement(By.CssSelector("h2"));
        }
    }
}
