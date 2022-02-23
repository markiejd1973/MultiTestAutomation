using Core;
using OpenQA.Selenium;

namespace AppTargets.Forms
{
    public class WikiHomePage : FormBase
    {
        public WikiHomePage() : base(By.Id("wikihome"), "wiki home page")
        {
            // Add Elements
            Elements.Add("ID", By.XPath("//input[@id='searchInput']"));


            // Page Dictionary
            ElementXPath.Add("value", "definition");
        }
    }
}
