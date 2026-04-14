using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
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

            var titulo = driver.FindElement(By.CssSelector("h1"));
            titulo.Text.Should().Be("Normal load website"); //Para obtener el texto del elemento y compararlo con el valor esperado
            driver.Quit(); // para liberar recursos, cerrar el navegador al finalizar la prueba
        }

        [Test]
        public void TestSlowLoadWebPage()
        {
            var driver = new ChromeDriver();
            driver.Manage().Window.Maximize();  // sentencia para maximizar la ventana del navegador
            driver.Url = "https://curso.testautomation.es"; // sentencia para navegar a la URL especificada que vamos a testear
            var sloLoadWeb = driver.FindElement(By.Id("SlowLoadWeb")); // para ubicar por el id el elemento del sitio web que queremos interactuar
            sloLoadWeb.Click();
            var titulo = driver.FindElement(By.Id("title"));

            titulo.Text.Should().Be("Slow load website");

            sloLoadWeb.Click();
            Thread.Sleep(3000); // para esperar 5 segundos antes de continuar con la siguiente acción, esto es útil para esperar a que se cargue completamente la página después de hacer clic en el botón "SlowLoadWeb"
            //driver.Quit();
        }
    }
}
