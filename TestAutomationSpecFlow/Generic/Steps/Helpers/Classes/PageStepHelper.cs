using Core;
using Core.Logging;
using Generic.Steps.Helpers.Interfaces;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Generic.Steps.Helpers.Classes
{
    public class PageStepHelper : StepHelper, IPageStepHelper
    {
        private readonly ITargetForms targetForms;
        public PageStepHelper(FeatureContext featureContext, ITargetForms targetForms) : base(featureContext)
        {
            this.targetForms = targetForms;
        }

        public bool IsDisplayed(string pageName)
        {
            DebugOutput.Log($"proc - IsDisplayed {pageName}");
            var pageElement = GetPageElement(pageName, "ID");
            if (pageElement == null) return false;
            return pageElement.Displayed;
        }

        public void SetCurrentPage(string pageName)
        {
            var expectedPage = targetForms[pageName];
            CurrentPage = expectedPage;
            DebugOutput.Log($"Current page now set to {CurrentPage}");
        }

        public IWebElement GetPageElement(string pageName, string elementName)
        {
            DebugOutput.Log($"proc - GetPageElement {pageName} {elementName}");
            var expectedPage = targetForms[pageName];
            var pageLocator = expectedPage.Elements[elementName];
            DebugOutput.Log($"We have the LOCATOR {pageLocator}");
            return SeleniumUtil.GetElement(pageLocator);
        }

    }
}
