using Core;
using Core.Logging;
using Generic.Steps.Helpers.Interfaces;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Generic.Steps.Helpers.Classes
{
    public class LinkStepHelper : StepHelper, ILinkStepHelper
    {
        private readonly ITargetForms targetForms;
        public LinkStepHelper(FeatureContext featureContext, ITargetForms targetForms) : base(featureContext)
        {
            this.targetForms = targetForms;
        }

        public bool ClickLink(string linkName)
        {
            DebugOutput.Log($"proc - IsDisplayed {linkName}");
            var linkElement = GetLinkElement(linkName);
            if (linkElement == null) return false;
            return SeleniumUtil.Click(linkElement);
        }

        public bool IsDisplayed(string linkName)
        {
            DebugOutput.Log($"proc - IsDisplayed {linkName}");
            var linkElement = GetLinkElement(linkName);
            if (linkElement == null) return false;
            return linkElement.Displayed;
        }

        // PRIVATE

        private string GetLinkName(string linkName)
        {
            DebugOutput.Log($"proc - GetLinkName {linkName}");
            linkName = linkName.ToLower();
            if (linkName.Contains("link")) return linkName;
            return linkName + " link";
        }

        private IWebElement GetLinkElementByDic(string linkName)
        {
            DebugOutput.Log($"GetLinkElement {linkName}");
            if(CurrentPage.Elements.ContainsKey(linkName))
            {
                var linkLocator = CurrentPage.Elements[linkName];
                DebugOutput.Log($"We have the LOCATOR for link {linkName} {linkLocator}");
                var elementLink = SeleniumUtil.GetElement(linkLocator, 1);
                return elementLink;
            }
            DebugOutput.Log($"No element found using page");
            return null;
        }

        private IWebElement GetLinkElement(string linkName)
        {
            DebugOutput.Log($"GetLinkElementByXPath {linkName}");
            var stringXPath = $"//*[contains(text(),'{linkName}')]";
            By stringLocator = By.XPath(stringXPath);
            var element = SeleniumUtil.GetElement(stringLocator, 1);
            DebugOutput.Log($"Tree Element By {stringLocator}");
            if (element == null)
            {
                return GetLinkElementByDic(GetLinkName(linkName));
            }
            return element;
        }

    }
}
