using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Xml.Linq;
using TestAutomation.Tests.PageObjectPattern.Helpers;
using TestAutomation.Tests.PageObjectPattern.Models;
using TestAutomation.Tests.PageObjectPattern.PageObject.HomePage;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

            /*
            var homePage = new HomePageObject(driver); // Obtenemos la página donde están las frutas
            var displayedFruits = homePage.DisplayedFruitWebElements(); // Obtenemos 12 frutas de la página
            var displayedOfDisplayedFruits = displayedFruits.Count();// Pasinamos dicho número a una variable para poder comparar con el número de frutas que tenemos en la lista de frutas esperadas
            */

            /*
            var result = new List<FruitModel>();
            var homePage = new HomePageObject(driver); // Se obtiene la página donde están las frutas
            result.AddRange(homePage.DisplayedFruitModel()); // Con esto se obtienen 1as frutas de la page y se inserta
            */

            var result = new List<FruitModel>();
            var homePage = new HomePageObject(driver); // se obtiene la página donde estan las frutas.
            result.AddRange(homePage.DisplayedFruitModel()); //con esto se obtienen 12 frutas de la page y se inserta
            //para los otros rangos de frutas
            result.AddRange(homePage.PageNavegation.ClickButtonPage2().DisplayedFruitModel());
            result.AddRange(homePage.PageNavegation.ClickButtonPage3().DisplayedFruitModel());
            //para comprar los valores cargados de la pagina contra lo que tenemos:
            result.Should().BeEquivalentTo(expectedFruits);
        }

        // Nos implementa e siguiente test
        // 1. Buscar 'app' pulsar search, button y verifique que solo Apple y Pineapple se muestran en la página.
        // 2. Limpiar el search, pulsar el botón search, y verificar que 12 frutas y vegetales se muestran
        // 3. Buscar 'ape' pulsando la tecla 'Enter', y verificar que 2 frutas son mostradas Grape y GrapeFruit
        [Test]
        public void SearchTests()
        {
            var homePage = new HomePageObject(driver); // Instanciamos un obejto que nos retorna la página
            var foundFruits = homePage.SearchBar.InputSearch("app").ClickSearch().DisplayedFruitModels();
            foundFruits.Count.Should().Be(2); // Según la condición debe retornar 2

            // Para obtener los nombres de las frutas encontradas,
            // se hace un select sobre la lista de frutas encontradas
            // y se obtiene el nombre de cada fruta, luego se convierte
            // a una lista para poder comparar con la lista de nombres esperados.
            var foundFruitsName = foundFruits.Select(fruit => fruit.Name).ToList();
            var expectFruitNames = new[] { "Pineapple", "Apple" };
            foundFruitsName.Should().BeEquivalentTo(expectFruitNames);
            // Compara los valores

            // Para el test 2 , se limpia el search, se pulsa el botón de search
            // y se verifica que se muestran 12 frutas y vegetales
            homePage.SearchBar.InputSearch(string.Empty).ClickSearch().DisplayedFruitWebElements().Count.Should().Be(12);



            // Para el test 3, se busca 'ape' pulsando la tecla 'Enter',
            // y se verifica que 2 frutas son mostradas Grape y GrapeFruit
            foundFruits = homePage.SearchBar.InputSearch("ape").ClickEnter().DisplayedFruitModels();
            expectFruitNames = new[] { "Grape", "Grapefruit" };
            foundFruits.Select(fruit => fruit.Name).Should().BeEquivalentTo(expectFruitNames);
        }

        //Resumen
        //Shoping Car Testing:
        //1. Verificar que el Shoping car icon de la parte superior derecha tiene numero 0
        //2. Añadir 10 apples, 6 bananas, 5 Avocado y 1 Pomegranate al
        // Shoping Car(para encontrar las frutas use la navegación por pagina).
        // Verificar que el Shoping car icon de la parte superior derecha tiene un numero 4
        //3. Abra el Shoping car y verifique que el item 4 del paso anterior ha sido adicionado
        // y que su valor es correcto.Verifique que la cantidad total es correcta.
        //4. Remueva el Pomegrante. Verifique que la cantidad es 3 en el icon del Shoping Car.
        //5. Actualizar la cantidad de bananas a 3. Verificar que el costo total el correcto.
        //6. Cerrar el carro de compra
        [Test]
        public void ShoppingCartTest()
        {
            // Tarea 1. Verificar que el icon de arriba es 0
            var homePage = new HomePageObject(driver);
            homePage.IsShoppingCartIconNumberOfItems(0).Should().BeTrue();
            var expectedFruitsInCart = new List<FruitModel>();
            // Tarea 2: agregar 10apple, 6 bananas, 5 Avocado 1 Pomegranete. Verificar el icon de shopping = 4
            var element = homePage.DisplayedFruitWebElements().Single(fruit => fruit.Name.Equals("Apple"));
            element.InputQuantity(10).ClickAddToCar(); // agregar 10 apple y hacer click para anadir al carro.
            expectedFruitsInCart.Add(FruitHelper.Parse(element)); // Se adiciona a la lista.
            //Bananas 6
            element = homePage.DisplayedFruitWebElements().Single(fruit => fruit.Name.Equals("Banana"));
            element.InputQuantity(6).ClickAddToCar(); // add las 6 bananas pulsa click para anadir al carro.
            expectedFruitsInCart.Add(FruitHelper.Parse(element)); // Se adiciona a la lista.
            //Avocado 5. primero click para avanzar pagina
            homePage.PageNavegation.ClickButtonPage2(); // Estamos en pagina 2
            element = homePage.DisplayedFruitWebElements().Single(fruit => fruit.Name.Equals("Avocado"));
            element.InputQuantity(5).ClickAddToCar();
            expectedFruitsInCart.Add(FruitHelper.Parse(element)); // Se adiciona a la lista.
            //Pomegranate
            homePage.PageNavegation.ClickButtonPage3(); // Estamos en pagina 3
            element = homePage.DisplayedFruitWebElements().Single(fruit => fruit.Name.Equals("Pomegranate"));
            element.InputQuantity(1).ClickAddToCar();
            expectedFruitsInCart.Add(FruitHelper.Parse(element)); // Se adiciona a la lista.
            // Para verificar que el carro tiene numero 4
            homePage.IsShoppingCartIconNumberOfItems(3).Should().BeTrue();
            //Test 3: Abrir el carro, verificar que tiene 4 elementos y sus valores son correctos
            var cart = homePage.ClickShoppingCartIcon(); //abre el carrito

            cart.CartItemWebElements.Count().Should().Be(4);// Comprueba 4 elementos en el carro

            var item = () => cart.CartItemWebElements;


            for (var i = 0; i < 4; i++)
            {
                var fruit = expectedFruitsInCart[i];
                item.ElementAt(i).GetText().Should().Be($"{fruit.Name} {fruit.Price}€/ Kg");
                fruit.Quantity.Should().Be(item.ElementAt(i).GetQuantity());
            }
            // Para probar que los totales son iguales

            cart.GetTotalPrice().Should().Be(cart.GetTotalPriceFromItems());
            // Borrar la granada
            item().ElementAt(3).ClickButtonRemove();// Borra
            homePage.IsShoppingCartIconNumberOfItems(3); // El número del icon de carro es 3
            item().ElementAt(1).InputQuantity(3); // Se actualiza bananas a 3

            var totalPrice = cart.GetTotalPrice();
            var TotalPriceFromItems = cart.GetTotalPriceFromItems();
            cart.GetTotalPrice().Should().Be(cart.GetTotalPriceFromItems());

            cart.ClickButtonClose(); // Clic sobre booton Close.
        }

        private FruitModel AddItemToCart(IList<FruitWebElement> displayedFruits, string fruitName, int quantity)
        {
            var fruitWebElement = displayedFruits.Single(fruit => fruit.Name.Equals(fruitName));
            fruitWebElement.InputQuantity(quantity).ClickAddToCar();
            var fruitModel = FruitHelper.Parse(fruitWebElement);
            fruitModel.Quantity = quantity;
            return fruitModel;
        }
    }
}
