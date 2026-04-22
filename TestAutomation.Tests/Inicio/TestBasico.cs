using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Diagnostics;

namespace TestAutomation.Tests.Inicio
{
    [TestFixture]
    public class TestBasico
    {
        #pragma warning disable NUnit1032
        private ChromeDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            // Desactivamos implicit wait para usar solo esperas explícitas
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.Zero;

            driver.Url = "https://curso.testautomation.es";
        }

        [TearDown]
        public void TearDown()
        {
            if (driver == null) return;

            try
            {
                driver.Quit();
            }
            catch (Exception ex)
            {
                TestContext.WriteLine($"Error cerrando driver: {ex.Message}");
            }
            finally
            {
                driver.Dispose();
                driver = null;
            }
        }

        [Test]
        public void TestBasicWebPage()
        {
            var normalLoadWeb = WaitUntilElementClickable(By.Id("NormalWeb"), TimeSpan.FromSeconds(10));
            normalLoadWeb.Click();

            var titulo = WaitUntilElementVisible(By.CssSelector("h1"), TimeSpan.FromSeconds(5));
            titulo.Text.Should().Be("Normal load website");
        }

        [Test]
        public void TestSlowLoadWebPage()
        {
            var slowLoadWeb = WaitUntilElementClickable(By.Id("SlowLoadWeb"), TimeSpan.FromSeconds(10));
            slowLoadWeb.Click();

            WaitUntilElementTextEquals(By.Id("title"), "Slow load website", TimeSpan.FromSeconds(10));

            var titulo = driver.FindElement(By.Id("title"));
            titulo.Text.Should().Be("Slow load website");
        }

        [Test]
        public void TestSlowLoadTextWebPage()
        {
            var slowLoadTextWeb = WaitUntilElementClickable(By.Id("SlowSpeedTextWeb"), TimeSpan.FromSeconds(10));
            slowLoadTextWeb.Click();

            WaitUntilElementTextEquals(By.Id("title"), "Slow load website", TimeSpan.FromSeconds(10));

            var titulo = driver.FindElement(By.Id("title"));
            titulo.Text.Should().Be("Slow load website");
        }

        // =========================
        // MÉTODOS DE ESPERA
        // =========================

        private IWebElement WaitUntilElementClickable(By locator, TimeSpan timeout)
        {
            var wait = new WebDriverWait(driver, timeout);
            return wait.Until(d =>
            {
                var element = d.FindElement(locator);
                return (element != null && element.Displayed && element.Enabled) ? element : null;
            });
        }

        private IWebElement WaitUntilElementVisible(By locator, TimeSpan timeout)
        {
            var wait = new WebDriverWait(driver, timeout);
            return wait.Until(d =>
            {
                var element = d.FindElement(locator);
                return element.Displayed ? element : null;
            });
        }

        private void WaitUntilElementTextEquals(By locator, string expectedText, TimeSpan timeout)
        {
            var wait = new WebDriverWait(driver, timeout);
            wait.Until(d =>
            {
                try
                {
                    var text = d.FindElement(locator).Text;
                    return text.Equals(expectedText);
                }
                catch
                {
                    return false;
                }
            });
        }

        // Método alternativo genérico (lo dejamos porque está bien implementado)
        private void WaitForCondition(Func<bool> condition, int msTimeout = 4000)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            Exception ex = null;

            do
            {
                try
                {
                    ex = null;
                    if (condition()) return;
                }
                catch (Exception e)
                {
                    ex = e;
                }
            } while (stopWatch.ElapsedMilliseconds < msTimeout);

            stopWatch.Stop();

            if (ex != null)
                throw new TimeoutException("Error executing the condition", ex);

            throw new TimeoutException("Condition was false");
        }
    }
}