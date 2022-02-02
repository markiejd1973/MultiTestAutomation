using Core;
using OpenQA.Selenium;

namespace AppTargets.Forms
{
    public class ToolsQAPage : FormBase
    {
        public ToolsQAPage() : base(By.Id("toolsqa"), "tools qa page")
        {
            // Add Elements
            Elements.Add("ID", By.XPath("//body/div[@id='app']/div[1]/div[1]/div[1]/div[1][contains(text(),'Elements')]"));

            Elements.Add("accordian", By.ClassName("accordion"));

            //Text Box
            Elements.Add("full name", By.Id("userName"));
            Elements.Add("email", By.Id("userEmail"));
            Elements.Add("current address", By.Id("currentAddress"));
            Elements.Add("permanent address", By.Id("permanentAddress"));


            // Page Dictionary
            ElementXPath.Add("value", "definition");
        }
    }
}
