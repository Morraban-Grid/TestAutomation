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
        // Mantener referencia al driver como campo de clase para que la instancia
        // no sea liberada automáticamente al salir del método de prueba.
        // Si quieres que la ventana permanezca abierta para cerrarla manualmente,
        // no llames a Quit/Dispose en el TearDown.
        private ChromeDriver? _driver;

        [SetUp]
        public void SetUp()
        {
            // Inicializa el driver antes de cada test
            _driver = new ChromeDriver();
        }

        [TearDown]
        public void TearDown()
        {
            // Intencionalmente vacío para mantener el navegador abierto después
            // de la ejecución del test. Para liberar recursos manualmente, ejecuta:
            // _driver?.Quit(); _driver?.Dispose();
        }
        [Test]
        public void TestBasicWebPage()
        {
            if (_driver == null) throw new InvalidOperationException("Driver no inicializado");

            // Sentencia para maximizar la ventana del navegador,
            // asegurando que el test se ejecute en una vista completa.
            _driver.Manage().Window.Maximize();

            // Navegar a la página de pruebas y mantener la ventana abierta para cerrarla manualmente.
            _driver.Navigate().GoToUrl("https://curso.testautomation.es");
        }
    }
}
