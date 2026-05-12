using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAutomation.Tests.PageObjectPattern.Models;
using TestAutomation.Tests.PageObjectPattern.PageObject.HomePage;

namespace TestAutomation.Tests.PageObjectPattern.Helpers
{
    public class FruitHelper
    {
        public static IList<FruitWebElement> Parse(IList<IWebElement> fruits)
        {
            return fruits.Select(fruit => new FruitWebElement(fruit)).ToList();
        }
        //Método que nos retorme un valor de tipo FrutiModel
        public static IList<FruitModel> Parse(IList<FruitWebElement> fruits)
        {
            return fruits.Select(fruit => Parse(fruit)).ToList();
        }
        //Método para convertir y separar el precio y convertir a decimal
        public static FruitModel Parse(FruitWebElement element)
        {
            var price = decimal.Parse(element.Price.Split(' ')[0]);
            return new FruitModel(element.Name, price, element.Description);
        }

        public IList<FruitWebElement> DisplayedFruitWebElements()
        {
            return FruitHelper.Parse(DisplayedFruits);
        }
        // Método que muestre la lista de frutas
        public IList<FruitModel> DisplayedFruitModel() => FruitHelper.Parse(DisplayedFruitWebElements());


    }
}
