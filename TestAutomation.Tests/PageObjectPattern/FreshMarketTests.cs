using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using TestAutomation.Tests.PageObjectPattern.Helpers;
using TestAutomation.Tests.PageObjectPattern.Models;
using TestAutomation.Tests.PageObjectPattern.PageObject.HomePage;
using NUnit.Framework;

namespace TestAutomation.Tests.PageObjectPattern
{
    public class FreshMarketTests
    {
#pragma warning disable NUnit1032
        IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            driver.Url = "https://curso.testautomation.es/FruitVegetablesShopWeb/index.html";
        }

        [TearDown]
        public void TearDownTest()
        {
            driver.Quit();
        }

        /// <summary>
        /// Verify that the next provided fruits are displayed into the shop.
        /// Please check that the content of all fruits are correct.
        /// </summary>
        [Test]
        public void VerifyThatFruitsAreCorrectlyDisplayed()
        {
            var expectedFruits = new List<FruitModel>
            {
                new FruitModel("Apple", 2.50m, "Crispy and delicious apples from the orchard."),
                new FruitModel("Banana", 1.00m, "Sweet and ripe bananas for a healthy snack."),
                new FruitModel("Orange", 1.50m, "Fresh and juicy oranges for a Vitamin C boost."),
                new FruitModel("Pear", 2.00m, "Sweet and juicy pears for a delightful taste."),
                new FruitModel("Strawberry", 3.00m, "Red and juicy strawberries for a sweet treat."),
                new FruitModel("Carrot", 1.20m, "Fresh and crunchy carrots for a healthy snack."),
                new FruitModel("Grape", 2.80m, "Sweet and delicious grapes for a refreshing taste."),
                new FruitModel("Watermelon", 0.80m, "Juicy and refreshing watermelon for hot days."),
                new FruitModel("Cherry", 2.70m, "Sweet and vibrant cherries for a delightful taste."),
                new FruitModel("Pumpkin", 1.80m, "Fresh and hearty pumpkin for a variety of recipes."),
                new FruitModel("Broccoli", 1.80m, "Fresh and nutritious broccoli for a healthy diet."),
                new FruitModel("Pineapple", 3.00m, "Sweet and tropical pineapples for a refreshing snack."),
                new FruitModel("Cucumber", 0.80m, "Crisp and refreshing cucumbers for salads and snacks."),
                new FruitModel("Potato", 1.20m, "Versatile and delicious potatoes for various dishes."),
                new FruitModel("Lemon", 2.00m, "Zesty and tangy lemons for cooking and beverages."),
                new FruitModel("Onion", 1.50m, "Flavorful and aromatic onions for cooking."),
                new FruitModel("Peach", 2.20m, "Sweet and juicy peaches for a delightful summer treat."),
                new FruitModel("Cabbage", 1.30m, "Crisp and crunchy cabbage for salads and coleslaw."),
                new FruitModel("Grapefruit", 2.40m, "Tangy and refreshing grapefruits for a healthy start."),
                new FruitModel("Kiwi", 3.20m, "Green and tangy kiwis for a tropical twist."),
                new FruitModel("Tomato", 1.60m, "Plump and juicy tomatoes for salads and sauces."),
                new FruitModel("Cantaloupe", 1.90m, "Sweet and aromatic cantaloupes for a refreshing treat."),
                new FruitModel("Avocado", 2.80m, "Creamy and nutritious avocados for salads and guacamole."),
                new FruitModel("Mango", 2.70m, "Exotic and sweet mangoes for a tropical delight."),
                new FruitModel("Raspberry", 3.50m, "Delicate and flavorful raspberries for desserts and snacking."),
                new FruitModel("Pomegranate", 4.00m, "Juicy and antioxidant-rich pomegranates for health-conscious individuals."),
                new FruitModel("Blackberry", 2.80m, "Sweet and juicy blackberries for desserts and smoothies."),
                new FruitModel("Cranberry", 3.20m, "Tart and antioxidant-packed cranberries for holiday dishes."),
            };

            var result = new List<FruitModel>();
            var homePage = new HomePageObject(driver);
            result.AddRange(homePage.DisplayedFruitModel());
            result.AddRange(homePage.PageNavegation.ClickButtonPage2().DisplayedFruitModel());
            result.AddRange(homePage.PageNavegation.ClickButtonPage3().DisplayedFruitModel());
            result.Should().BeEquivalentTo(expectedFruits);
        }

        [Test]
        public void SearchTests()
        {
            var homePage = new HomePageObject(driver);
            var foundFruits = homePage.SearchBar.InputSearch("app").ClickSearch().DisplayedFruitModels();
            foundFruits.Count.Should().Be(2);

            var foundFruitsName = foundFruits.Select(fruit => fruit.Name).ToList();
            var expectFruitNames = new[] { "Pineapple", "Apple" };
            foundFruitsName.Should().BeEquivalentTo(expectFruitNames);

            homePage.SearchBar.InputSearch(string.Empty).ClickSearch().DisplayedFruitWebElements().Count.Should().Be(12);

            foundFruits = homePage.SearchBar.InputSearch("ape").ClickEnter().DisplayedFruitModels();
            expectFruitNames = new[] { "Grape", "Grapefruit" };
            foundFruits.Select(fruit => fruit.Name).Should().BeEquivalentTo(expectFruitNames);
        }

        [Test]
        public void ShoppingCartTest()
        {
            // Tarea 1: verificar que el icono del carrito muestra 0
            var homePage = new HomePageObject(driver);
            homePage.IsShoppingCartIconNumberOfItems(0).Should().BeTrue();

            var expectedFruitsInCart = new List<FruitModel>();

            // Tarea 2: agregar frutas al carrito y verificar icono = 4
            var element = homePage.DisplayedFruitWebElements().Single(fruit => fruit.Name.Equals("Apple"));
            element.InputQuantity(10).ClickAddToCar();
            var appleModel = FruitHelper.Parse(element);
            appleModel.Quantity = 10;                          // ← asignar cantidad
            expectedFruitsInCart.Add(appleModel);

            element = homePage.DisplayedFruitWebElements().Single(fruit => fruit.Name.Equals("Banana"));
            element.InputQuantity(6).ClickAddToCar();
            var bananaModel = FruitHelper.Parse(element);
            bananaModel.Quantity = 6;                          // ← asignar cantidad
            expectedFruitsInCart.Add(bananaModel);

            homePage.PageNavegation.ClickButtonPage2();
            element = homePage.DisplayedFruitWebElements().Single(fruit => fruit.Name.Equals("Avocado"));
            element.InputQuantity(5).ClickAddToCar();
            var avocadoModel = FruitHelper.Parse(element);
            avocadoModel.Quantity = 5;                         // ← asignar cantidad
            expectedFruitsInCart.Add(avocadoModel);

            homePage.PageNavegation.ClickButtonPage3();
            element = homePage.DisplayedFruitWebElements().Single(fruit => fruit.Name.Equals("Pomegranate"));
            element.InputQuantity(1).ClickAddToCar();
            var pomegranateModel = FruitHelper.Parse(element);
            pomegranateModel.Quantity = 1;                     // ← asignar cantidad
            expectedFruitsInCart.Add(pomegranateModel);

            // Verificar icono = 4
            homePage.IsShoppingCartIconNumberOfItems(4).Should().BeTrue();

            // Tarea 3: abrir carrito y verificar 4 elementos con valores correctos
            var cart = homePage.ClickShoppingCartIcon();
            cart.CartItemWebElements.Count().Should().Be(4);

            var item = () => cart.CartItemWebElements;

            for (var i = 0; i < 4; i++)
            {
                var fruit = expectedFruitsInCart[i];
                item().ElementAt(i).GetText().Should().Be($"{fruit.Name} {fruit.Price} €/Kg");
                fruit.Quantity.Should().Be(item().ElementAt(i).GetQuantity());
            }

            // Verificar que el total del carrito es correcto
            cart.GetTotalPrice().Should().Be(cart.GetTotalPriceFromItems());

            // Tarea 4: eliminar Pomegranate y verificar icono = 3
            item().ElementAt(3).ClickButtonRemove();
            homePage.IsShoppingCartIconNumberOfItems(3).Should().BeTrue();  // ← aserción completa

            // Tarea 5: actualizar cantidad de bananas a 3 y verificar total
            item().ElementAt(1).InputQuantity(3);
            cart.GetTotalPrice().Should().Be(cart.GetTotalPriceFromItems());

            // Tarea 6: cerrar el carrito
            cart.ClickButtonClose();

            var totalPriceFromItems = cart.GetTotalPriceFromItems();
            cart.GetTotalPrice().Should().Be(cart.GetTotalPriceFromItems()); // Se verifica que el total del carrito es correcto antes de cerrar el carrito.
            cart.ClickButtonClose(); // Clicamos el botón de cerrar el carrito.
        }

        private FruitModel AddItemToCart(IList<FruitWebElement> displayedFruits, string fruitName, int quantity)
        {
            var fruitWebElement = displayedFruits.Single(fruit => fruit.Name.Equals(fruitName));
            fruitWebElement.InputQuantity(quantity).ClickAddToCar();
            var fruitModel = FruitHelper.Parse(fruitWebElement);
            fruitModel.Quantity = quantity;
            return fruitModel;
        }

        // resumen de 4to test
        //1.Abrir el Fresh Market.
        //2.Click en el botón “Contact Us”
        //3.Click en el botón “Submit”. Verificar que 3 mensajes de error son mostrados con sus valores
        //4.Verifique que el desplegable “Categoria” contiene 5 opciones, que se pueden ver en la IU.
        //5.Ingrese valores validos en todos los campos y pulse “Submit”. Verifique que una aleta se muestra con el mensaje “Form submitted successfully”
        //6.Click al boton “Accept” dentro del alerta.
        [Test]
        public void ContactUsTest()
        {
            var homePage = new HomePageObject(driver);
            var contactUsForm = homePage.clickContactUs();
            contactUsForm.ClickSumit();
            contactUsForm.GetDisplayedTitleErrorMessage().Should().Be("Please enter a title");
            contactUsForm.GetDisplayedEmailErrorMessage().Should().Be("Please enter a valid email address");
            contactUsForm.GetDisplayedTextErrorMessage().Should().Be("Please enter a message");
        }
        private FruitModel addItemToCart(IList<FruitWebElement> displayedFruits, string fruitName, int quantity)
        {
            var fruitWebElement = displayedFruits.Single(fruit => fruit.Name.Equals(fruitName));
            fruitWebElement
            .InputQuantity(quantity)
            .ClickAddToCar();
            var fruitModel = FruitHelper.Parse(fruitWebElement);
            fruitModel.Quantity = quantity;
            return fruitModel;
        }

    }
}