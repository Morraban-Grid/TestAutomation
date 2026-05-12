using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomation.Tests.PageObjectPattern.PageObject.HomePage
{
    public class FruitWebElement
    {
        //Implementamos un IwebElement
        private readonly IWebElement fruitWebElement;
        public string Name =>
        fruitWebElement.FindElement(By.TagName("h2")).Text;
        //Ahora, implmentamos el precio.
        public string Price => fruitWebElement.FindElement(By.TagName("p")).Text;
        //Establecemos la descripción, que es el segundo párrafo, por eso el [1]
        public string Description => fruitWebElement.FindElements(By.TagName("p"))[1].Text;
        // Definimos el constructor cuando se crea la variable fruitElement, así tendrá un valor

        public FruitWebElement(IWebElement fruitWebElement)
        {
            this.fruitWebElement = fruitWebElement;
        }
    }
}
