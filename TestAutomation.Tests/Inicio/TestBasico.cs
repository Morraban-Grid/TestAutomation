using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
//using OpenQA.Selenium.Firefox;

namespace TestAutomation.Tests.Inicio
{
    [TestFixture]
    public class TestBasico
    {
        #pragma warning disable NUnit1032
        ChromeDriver driver;

        [SetUp]
        public void SetUp()
        {
            //Todo el contenido que está dentro de este bloque
            //se ejecutará antes de cualquier método
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            driver.Url = "https://curso.testautomation.es";
            var titulo = driver.FindElement(By.Id("title"));
            titulo.Text.Should().Be("Slow load website");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void TestBasicWebPage()
        {
            /*
            var driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://curso.testautomation.es";
            */

            var normalLoadWeb = driver.FindElement(By.Id("NormalWeb"));
            normalLoadWeb.Click();

            var titulo = driver.FindElement(By.CssSelector("h1"));
            titulo.Text.Should().Be("Normal load website"); //Para obtener el texto del elemento y compararlo con el valor esperado
        }

        [Test]
        public void TestSlowLoadWebPage()
        {
            /*
            var driver = new ChromeDriver();
            driver.Manage().Window.Maximize();  // sentencia para maximizar la ventana del navegador
            driver.Url = "https://curso.testautomation.es"; // sentencia para navegar a la URL especificada que vamos a testear
            */

            var sloLoadWeb = driver.FindElement(By.Id("SlowLoadWeb")); // para ubicar por el id el elemento del sitio web que queremos interactuar
            sloLoadWeb.Click();
            var titulo = driver.FindElement(By.Id("title"));

            titulo.Text.Should().Be("Slow load website");

            sloLoadWeb.Click();
            Thread.Sleep(3000); // para esperar 5 segundos antes de continuar con la siguiente acción, esto es útil para esperar a que se cargue completamente la página después de hacer clic en el botón "SlowLoadWeb"
        }

        [Test]
        public void TestSlowLoadTextWebPage()
        {
            /*
            var driver = new ChromeDriver();
            driver.Manage().Window.Maximize(); // sentencia para maximizar a dimensión completa la ventana del navegador
            driver.Url = "https://curso.testautomation.es"; // para navegar a la URL especificada que vamos a testear
            */

            var slowLoadTextWeb = driver.FindElement(By.Id("SlowSpeedTextWeb")); // para ubicar por el id el elemento del sitio web que queremos interactuar, en este caso el botón "SlowSpeedTextWeb"
            slowLoadTextWeb.Click();
            Thread.Sleep(1500); // para esperar 1.5 segundos antes de continuar con la siguiente acción, esto es útil para esperar a que se cargue completamente la página después de hacer clic en el botón "SlowSpeedTextWeb"s
            var titulo = driver.FindElement(By.Id("title")); // para ubicar por el id el elemento del sitio web que queremos interactuar, en este caso el título de la página después de hacer clic en el botón "SlowSpeedTextWeb"

            titulo.Text.Should().Be("Slow speed text website"); // para obtener el texto del elemento y compararlo con el valor esperado, en este caso "Slow speed text website"
            //slowLoadTextWeb.Click(); // para hacer clic nuevamente en el botón "SlowSpeedTextWeb", esto es útil para volver a cargar la página y verificar que el título se actualice correctamente después de hacer clic en el botón
            //var titulo = driver.FindElement(By.Id("title"));

            WaitForCondition(() => IsTextElement(titulo, "Slow load website"));// es una expresion lambda.
        }

        private void WaitForCondition(Func<bool> condition, int msTimeout = 4000)
        {
            // este codigo es muy util para controlar l
            var stopWatch = new Stopwatch(); // definimos una variable de tipo Stopwatch
            stopWatch.Start(); //iniciamos la variable.
            Exception? ex;
            do
            {
                try
                {
                    ex = null;
                    if (condition())
                    {
                        return;
                    }
                }
                catch (Exception e)
                {
                    ex = e;
                }
            } while (stopWatch.ElapsedMilliseconds < msTimeout);
            stopWatch.Stop();
            if (ex != null)
            {
                throw new TimeoutException("Error executing the condition", ex);
            }
            throw new TimeoutException("Error the condition was false", ex);// si la condicion es fase siempre
        }

        private bool IsTextElement(IWebElement element, string expectedText)
        {
            return element.Text.Equals(expectedText); // para comparar el texto del elemento con el valor esperado
        }
    }
}
