using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestAutomation.Tests.PageObjectPattern.PageObject.ContactUs
{
    internal class ContactUsPageObject
    {
        private IWebDriver driver;
        // Propiedades de los elementos del formulario de contacto
        private IWebElement InputFieldContactTitle => driver.FindElement(By.Id("contactTitle"));
        private IWebElement InputFieldContactEmail => driver.FindElement(By.Id("contactEmail"));
        private SelectElement DropdownCategory => new SelectElement(driver.FindElement(By.Id("contactCategory")));
        private IWebElement InputFieldContactText => driver.FindElement(By.Id("contactText"));
        private IWebElement ButtonSubmit => driver.FindElement(By.CssSelector("#contactForm button"));
        private IWebElement ButtonClose => driver.FindElement(By.Id("closeContactPopup"));

        // Elementos de los mensajes de error
        private IWebElement TitleErrorMessage => driver.FindElement(By.Id("contactTitleError"));
        private IWebElement EmailErrorMessage => driver.FindElement(By.Id("contactEmailError"));
        private IWebElement TextErrorMessage => driver.FindElement(By.Id("contactTextError"));

        // Definimos el constructor de la clase
        public ContactUsPageObject(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void ClickSumit() => ButtonSubmit.Click();

        // Métodos para interactuar con los campos del formulario
        public string? GetDisplayedTitleErrorMessage() => TitleErrorMessage.Displayed ? TitleErrorMessage.Text : null;
        public string? GetDisplayedEmailErrorMessage() => EmailErrorMessage.Displayed ? EmailErrorMessage.Text : null;
        public string? GetDisplayedTextErrorMessage() => TextErrorMessage.Displayed ? TextErrorMessage.Text : null;
    }
}
