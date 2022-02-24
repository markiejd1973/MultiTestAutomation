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

            Elements.Add("cgi logo image", By.Id("Calque_1"));

            Elements.Add("menu button", By.XPath("//button[contains(text(),'Menu')]"));
            Elements.Add("show me more button", By.XPath("//a[contains(text(),'Show Me More')]"));

            Elements.Add("username", By.XPath("//input[@name='username']"));
            Elements.Add("password", By.XPath("//input[@name='password']"));
            Elements.Add("login button", By.XPath("//input[@name='login']"));

            //Cars
            Elements.Add("cars table", By.XPath("//table[@id='available cars']"));

            // Page Dictionary
            ElementXPath.Add("value", "definition");
        }
    }
}
