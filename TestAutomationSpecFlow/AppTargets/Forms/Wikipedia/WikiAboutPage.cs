using Core;
using OpenQA.Selenium;

namespace AppTargets.Forms
{
    public class WikiAboutPage : FormBase
    {
        public WikiAboutPage() : base(By.Id("wikiabout"), "wiki about page")
        {
            // Add Elements
            Elements.Add("ID", By.Id("firstHeading"));

            Elements.Add("search", By.Id("searchInput"));

            // Page Dictionary
            ElementXPath.Add("value", "definition");
        }
    }
}
