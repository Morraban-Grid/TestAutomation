using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using TestAutomation.Tests.PageObjectPattern.Models;

namespace TestAutomation.Tests.PageObjectPattern
{
    [Parallelizable(ParallelScope.All)]
    public class TestBase
    {
        public static TestSettings TestSettings { get; set; }
        // cargamos la configuración de appsettings.json en la propiedad TestSettings
        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            TestSettings = new TestSettings();
            var settings = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, true).Build();
            var automationSettings = settings.GetSection("AutomationSettings");
            automationSettings.Bind(TestSettings);
        }
    }
}
