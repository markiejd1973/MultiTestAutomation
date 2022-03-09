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

            Elements.Add("text", By.Id("CalculatorResults"));

            Elements.Add("one button", By.Name("One"));
            Elements.Add("two button", By.Name("Two"));
            Elements.Add("three button", By.Name("Three"));
            Elements.Add("four button", By.Name("Four"));
            Elements.Add("five button", By.Name("Five"));
            Elements.Add("six button", By.Name("Six"));
            Elements.Add("seven button", By.Name("Seven"));
            Elements.Add("eight button", By.Name("Eight"));
            Elements.Add("nine button", By.Name("Nine"));
            Elements.Add("zero button", By.Name("Zero"));

            Elements.Add("1 button", By.Name("One"));
            Elements.Add("2 button", By.Name("Two"));
            Elements.Add("3 button", By.Name("Three"));
            Elements.Add("4 button", By.Name("Four"));
            Elements.Add("5 button", By.Name("Five"));
            Elements.Add("6 button", By.Name("Six"));
            Elements.Add("7 button", By.Name("Seven"));
            Elements.Add("8 button", By.Name("Eight"));
            Elements.Add("9 button", By.Name("Nine"));
            Elements.Add("0 button", By.Name("Zero"));

            Elements.Add("divide by button", By.Name("Divide by"));
            Elements.Add("multiply by button", By.Name("Multiply by"));
            Elements.Add("minus button", By.Name("Minus"));
            Elements.Add("plus button", By.Name("Plus"));
            Elements.Add("equals button", By.Name("Equals"));

            Elements.Add("/ button", By.Name("Divide by"));
            Elements.Add("x button", By.Name("Multiply by"));
            Elements.Add("- button", By.Name("Minus"));
            Elements.Add("+ button", By.Name("Plus"));
            Elements.Add("= button", By.Name("Equals"));

            // Page Dictionary
            ElementXPath.Add("value", "definition");
        }
    }
}
