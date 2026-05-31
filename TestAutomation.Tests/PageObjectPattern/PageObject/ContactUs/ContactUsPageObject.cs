using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestAutomation.Tests.PageObjectPattern.PageObject.ContactUs
{
    public class ContactUsPageObject
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
        public IEnumerable<string> GetCategoryOptions() => DropdownCategory.Options.Select(category => category.Text);

        // Métodos para interactuar con los campos del formulario
        public ContactUsPageObject InputTextContactTitle(string title)
        {
            InputFieldContactTitle.Clear();
            InputFieldContactTitle.SendKeys(title);
            return this;
        }
        public ContactUsPageObject InputTextContactEmail(string email)
        {
            InputFieldContactEmail.Clear();
            InputFieldContactEmail.SendKeys(email);
            return this;
        }
        public ContactUsPageObject InputTextContactMessage(string message)
        {
            InputFieldContactText.Clear();
            InputFieldContactText.SendKeys(message);
            return this;
        }
        public ContactUsPageObject SelectCategory(string category)
        {
            DropdownCategory.SelectByText(category);
            return this;
        }

    }
}
