using Core;
using OpenQA.Selenium;

namespace AppTargets.Forms
{
    public class WikiContactUsPage : FormBase
    {
        public WikiContactUsPage() : base(By.Id("wikicontactus"), "wiki contact us page")
        {
            // Add Elements
            Elements.Add("ID", By.XPath("//h1[@id='firstHeading' and contains(text(),'Wikipedia:Contact us')]"));

            // Page Dictionary
            ElementXPath.Add("value", "definition");
        }
    }
}
