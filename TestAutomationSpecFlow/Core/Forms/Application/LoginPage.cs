using OpenQA.Selenium;

namespace Core.Forms.Application
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
