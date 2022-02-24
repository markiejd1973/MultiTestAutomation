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

            //Accordion Menu
            Elements.Add("accordian", By.ClassName("accordion"));

            //TextBox
            Elements.Add("full name", By.Id("userName"));
            Elements.Add("email", By.Id("userEmail"));
            Elements.Add("current address", By.Id("currentAddress"));
            Elements.Add("permanent address", By.Id("permanentAddress"));

            //Tree
            Elements.Add("checkbox tree", By.Id("tree-node"));

            //RadioButton
            Elements.Add("yes radiobutton", By.Id("yesRadio"));
            Elements.Add("impressive radiobutton", By.Id("impressiveRadio"));
            Elements.Add("no radiobutton", By.Id("noRadio"));

            //Button
            Elements.Add("double click me button", By.Id("doubleClickBtn"));
            Elements.Add("right click me button", By.Id("rightClickBtn"));
            Elements.Add("click me button", By.XPath("//div[3]/button[1]"));

            //Table
            Elements.Add("react table", By.XPath("//body/div[@id='app']/div[1]/div[1]/div[2]/div[2]/div[1]/div[3]"));

            //Link
            Elements.Add("home link", By.Id("simpleLink"));


            // Page Dictionary
            ElementXPath.Add("value", "definition");
        }
    }
}
