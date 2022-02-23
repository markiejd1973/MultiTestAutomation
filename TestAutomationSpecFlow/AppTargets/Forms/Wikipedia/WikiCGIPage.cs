using Core;
using OpenQA.Selenium;

namespace AppTargets.Forms
{
    public class WikiCGIPage : FormBase
    {
        public WikiCGIPage() : base(By.Id("wikicgi"), "wiki cgi page")
        {
            // Add Elements
            Elements.Add("ID", By.XPath("//h1[@id='firstHeading' and contains(text(),'CGI Inc.')]"));

            Elements.Add("cgi logo image", By.XPath("/html[1]/body[1]/div[3]/div[3]/div[5]/div[1]/table[2]/tbody[1]/tr[1]/td[1]/a[1]/img[1]"));

            // Page Dictionary
            ElementXPath.Add("value", "definition");
        }
    }
}
