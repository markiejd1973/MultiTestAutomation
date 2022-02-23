using Core;
using OpenQA.Selenium;

namespace AppTargets.Forms
{
    public class CGIWelcomePage : FormBase
    {
        public CGIWelcomePage() : base(By.Id("cgiwelcome"), "cgi welcome page")
        {
            // Add Elements
            Elements.Add("ID", By.XPath("//button[contains(text(),'Menu')]"));


            // Page Dictionary
            ElementXPath.Add("value", "definition");
        }
    }
}
