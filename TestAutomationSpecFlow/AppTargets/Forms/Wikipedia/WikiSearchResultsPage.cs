using Core;
using OpenQA.Selenium;

namespace AppTargets.Forms
{
    public class WikiSearchResultsPage : FormBase
    {
        public WikiSearchResultsPage() : base(By.Id("wikisearchresults"), "wiki search results page")
        {
            // Add Elements
            Elements.Add("ID", By.XPath("//h1[@id='firstHeading' and contains(text(),'Search result')]"));

            // Page Dictionary
            ElementXPath.Add("value", "definition");
        }
    }
}
