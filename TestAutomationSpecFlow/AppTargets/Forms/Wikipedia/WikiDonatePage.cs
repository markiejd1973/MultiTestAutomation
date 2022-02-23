using Core;
using OpenQA.Selenium;

namespace AppTargets.Forms
{
    public class WikiDonatePage : FormBase
    {
        public WikiDonatePage() : base(By.Id("wiki donate"), "wiki donate page")
        {
            // Add Elements
            Elements.Add("ID", By.XPath("//label[contains(text(),'Just Once')]"));

            // Page Dictionary
            ElementXPath.Add("value", "definition");
        }
    }
}
