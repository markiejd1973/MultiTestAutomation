using Core;
using OpenQA.Selenium;

namespace AppTargets.Forms
{
    public class LoginPage : FormBase
    {
        public LoginPage() : base(By.Id("login"), "login page")
        {
            Elements.Add("Test", By.Id("Heelo"));
            ElementXPath.Add("jjeje", "value");
        }
    }
}
