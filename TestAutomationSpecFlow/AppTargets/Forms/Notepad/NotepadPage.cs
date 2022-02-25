using Core;
using OpenQA.Selenium;

namespace AppTargets.Forms
{
    public class NotepadPage : FormBase
    {
        public NotepadPage() : base(By.Id("new"), "new page")
        {
            // Add Elements
            Elements.Add("ID", By.Id("PageID"));


            // Page Dictionary
            ElementXPath.Add("value", "definition");
        }
    }
}
