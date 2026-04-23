using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace TestAutomation.Tests.Selectores
{
    [TestFixture]
    public class SelectoresTests
    {
        #pragma warning disable NUnit1032
        IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            // Espera implícita
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

            driver.Url = "https://curso.testautomation.es";
        }

        [TearDown]
        public void TearDownTest()
        {
            driver.Quit();
        }

        [Test]
        public void GetEachOfTheElements()
        {
            // Ir a la página de selectores
            driver.FindElement(By.Id("SelectorsWeb")).Click();

            // Element 1 (por ID correcto)
            driver.FindElement(By.Id("myId")).Text.Should().Be("Element 1");

            // Element 2 (por ClassName)
            driver.FindElement(By.ClassName("className")).Text.Should().Be("Element 2");

            // Element 3 - opción 1: lista (IDs duplicados)
            driver.FindElements(By.Id("myId"))[1].Text.Should().Be("Element 3");

            // Element 3 - opción 2: dentro de una sección
            var elementsSection = driver.FindElement(By.Name("elements"));
            elementsSection.FindElement(By.Id("myId")).Text.Should().Be("Element 3");

            // Element 3 - opción 3: selector CSS
            driver.FindElement(By.CssSelector("[name='elements'] #myId"))
                  .Text.Should().Be("Element 3");

            // Element 4 - por Name
            driver.FindElement(By.Name("myName")).Text.Should().Be("Element 4");

            // Element 5 - por CSS (atributo style)
            driver.FindElement(By.CssSelector("div[style='color:magenta']"))
                  .Text.Should().Be("Element 5");

            // Element 5 - por XPath (contiene texto)
            driver.FindElement(By.XPath("//*[contains(text(),'Element 5')]"))
                  .Text.Should().Be("Element 5");

            // Element 6 - por atributo personalizado (autotestid)
            driver.FindElement(By.CssSelector("[autotestid='Element6']"))
                  .Text.Should().Be("Element 6");

            // Element 7 y 8 - lista de divs dentro de la sección
            var divElementsSection = driver.FindElements(By.CssSelector("[name='elements'] div"));

            divElementsSection[5].Text.Should().Be("Element 7"); // índice 5 (empieza en 0)
            divElementsSection[6].Text.Should().Be("Element 8");

            // Home 1 y Home 2 - usando CSS
            var homeButtons = driver.FindElements(By.CssSelector("[name='refs'] div > a"));

            homeButtons[0].Text.Should().Be("Home1");
            homeButtons[1].Text.Should().Be("Home2");

            // Alternativa: usando PartialLinkText (hay 3 "Home")
            homeButtons = driver.FindElements(By.PartialLinkText("Home"));

            homeButtons[1].Text.Should().Be("Home1");
            homeButtons[2].Text.Should().Be("Home2");

            // Alternativa: filtrando primero la sección
            var refsSection = driver.FindElement(By.Name("refs"));
            homeButtons = refsSection.FindElements(By.PartialLinkText("Home"));

            homeButtons[0].Text.Should().Be("Home1");
            homeButtons[1].Text.Should().Be("Home2");

            // Botón "Click me 2" usando selector relativo
            var home1 = homeButtons[0];

            var button2 = driver.FindElement(
                RelativeBy.WithLocator(By.TagName("button")).RightOf(home1)
            );

            button2.Text.Should().Be("Click me 2");

            // Tabla de usuarios inactivos - obtener "Sandra"
            var inactiveTable = driver.FindElements(By.ClassName("styled-table"))[1];

            var inactiveUsers = inactiveTable.FindElements(By.CssSelector("tbody tr"));

            Console.WriteLine(inactiveUsers[1].Text);
        }
    }
}