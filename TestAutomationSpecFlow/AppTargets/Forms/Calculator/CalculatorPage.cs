using Core;
using OpenQA.Selenium;

namespace AppTargets.Forms
{
    public class CalculatorPage : FormBase
    {
        public CalculatorPage() : base(By.Id("calculator"), "calculator page")
        {
            // Add Elements
            Elements.Add("ID", By.Id("PageID"));

            Elements.Add("one button", By.Name("One"));

            // Page Dictionary
            ElementXPath.Add("value", "definition");
        }
    }
}
