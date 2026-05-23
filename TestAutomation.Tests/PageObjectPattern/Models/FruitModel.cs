using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace TestAutomation.Tests.PageObjectPattern.Models

{
    public class FruitModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        // creamos su constructor
        public FruitModel(string name, decimal price, string description)
        {
            Name = name;
            Price = price;
            Description = description;
        }
    }
}