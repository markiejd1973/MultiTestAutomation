using Core;
using Core.Logging;
using Generic.Steps.Helpers.Interfaces;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Generic.Steps.Helpers.Classes
{
    public class SpanStepHelper : StepHelper, ISpanStepHelper
    {
        private readonly ITargetForms targetForms;
        public SpanStepHelper(FeatureContext featureContext, ITargetForms targetForms) : base(featureContext)
        {
            this.targetForms = targetForms;
        }

        int versionNumber = 0;

        private readonly By[] linkXPath = { By.XPath($"//span[contains(text(),'") };

        public bool LinkDisplayedByName(string linkName)
        {
            DebugOutput.Log($"proc - LinkDisplayedByName {linkName}");
            var xPath = GetLinkXPath(linkName);
            By linkLocator = By.XPath(xPath);
            var element = SeleniumUtil.GetElement(linkLocator);
            if (linkLocator == null)
            {
                DebugOutput.Log($"Problem finding by XPATH {xPath}");
                return false;
            }
            return element.Displayed;
        }

        public bool ClickOnLinkByName(string linkName)
        {
            DebugOutput.Log($"proc - ClickOnLinkByName {linkName}");
            var xPath = GetLinkXPath(linkName);
            By linkLocator = By.XPath(xPath);
            var element = SeleniumUtil.GetElement(linkLocator);
            if (linkLocator == null)
            {
                DebugOutput.Log($"Problem finding by XPATH {xPath}");
                return false;
            }
            return SeleniumUtil.Click(element);
        }

        private string GetLinkXPath(string linkName)
        {
            DebugOutput.Log($"proc - GetLinkXPath {linkName}");
            return $"//span[contains(text(),'{linkName}')]";
        }

    }
}
