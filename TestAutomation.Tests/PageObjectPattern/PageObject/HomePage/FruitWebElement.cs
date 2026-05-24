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

        // Selectores para el Test3: Quantity y Add to car.
        private IWebElement InputFieldQuantity =>
        fruitWebElement.FindElement(By.CssSelector("[id$='Quantity']"));

        // Para el boton
        private IWebElement ButtonAddToCart => fruitWebElement.FindElement(By.CssSelector("button"));

        // Definimos su constructor. cuando se cree la variable fruitElement tenga un valor
        public FruitWebElement(IWebElement fruitWebElement)
        {
            this.fruitWebElement = fruitWebElement;
        }

        public void ClickAddToCar() => ButtonAddToCart.Click();
        public FruitWebElement InputQuantity(int quantity)
        {
            InputFieldQuantity.Clear();
            InputFieldQuantity.SendKeys(quantity.ToString());
            return this;
        }

    }

}
