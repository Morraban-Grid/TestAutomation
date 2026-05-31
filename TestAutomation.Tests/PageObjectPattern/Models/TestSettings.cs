using System;
using System.Collections.Generic;
using System.Text;

namespace TestAutomation.Tests.PageObjectPattern.Models
{
    public class TestSettings
    {
        public string Browser { get; set; } = string.Empty;
        public int WaitTimeout { get; set; }
    }
}
