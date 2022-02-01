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

            Elements.Add("accordian", By.XPath("//body/div[@id='app']/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]"));

            // Page Dictionary
            ElementXPath.Add("value", "definition");
        }
    }
}
