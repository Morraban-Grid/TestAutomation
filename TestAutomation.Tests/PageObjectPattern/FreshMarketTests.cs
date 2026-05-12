using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TestAutomation.Tests.PageObjectPattern.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TestAutomation.Tests.PageObjectPattern
{
    public class FreshMarketTests
    {
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
                new FruitModel("Pomegranate", 4.00m, "Juicy and antioxidant-rich pomegranates for health - conscious individuals."),
                new FruitModel("Blackberry", 2.80m, "Sweet and juicy blackberries for desserts and smoothies."),
                new FruitModel("Cranberry", 3.20m, "Tart and antioxidant-packed cranberries for holiday dishes."),
            };
    }
}

}
