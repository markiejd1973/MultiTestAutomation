using Core;
using Core.Logging;
using Generic.Steps.Helpers.Interfaces;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Generic.Steps.Helpers.Classes
{
    public class WindowStepHelper : StepHelper, IWindowStepHelper
    {
        private readonly ITargetForms targetForms;
        public WindowStepHelper(FeatureContext featureContext, ITargetForms targetForms) : base(featureContext)
        {
            this.targetForms = targetForms;
        }

        public bool CloseWindow(string windowsName)
        {
            DebugOutput.Log($"CloseWindow ");
            var element = GetWindowElement(windowsName);
            return SeleniumUtil.SendKey(element, "close");
        }

        public bool IsDisplayed(string windowsName)
        {
            DebugOutput.Log($"IsDisplayed {windowsName}");
            var element = GetWindowElement(windowsName);
            if (element == null)
            {
                DebugOutput.Log($"No element to check");
                return false;
            }
            return element.Displayed;
        }

        public bool WriteInWindow(string documentName, string text)
        {
            By windowsLocator = By.Name(documentName);
            var element = SeleniumUtil.GetElement(windowsLocator);
            return SeleniumUtil.EnterText(element, text);
        }

        private IWebElement GetWindowElement(string windowsName)
        {
            By windowsLocator = By.Name(windowsName);
            var element = SeleniumUtil.GetElement(windowsLocator);
            if (element == null)
            {
                DebugOutput.Log($"Contains the name? {windowsName}");
                var xPath = $"//Window[contains(@Name,'{windowsName}')]";
                By xPathLocator = By.XPath(xPath);
                element = SeleniumUtil.GetElement(xPathLocator, 1);
            }
            return element;
        }

    }
}
