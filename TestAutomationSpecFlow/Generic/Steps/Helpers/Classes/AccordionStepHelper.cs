using Core;
using Core.Logging;
using Generic.Steps.Helpers.Interfaces;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Generic.Steps.Helpers.Classes
{
    public class AccordionStepHelper : StepHelper, IAccordionStepHelper
    {
        private readonly ITargetForms targetForms;
        public AccordionStepHelper(FeatureContext featureContext, ITargetForms targetForms) : base(featureContext)
        {
            this.targetForms = targetForms;
        }

        public bool IsDisplayed(string accordionName)
        {
            DebugOutput.Log($"proc - IsDisplayed {accordionName}");
            accordionName = accordionName.ToLower();    
            var pageElement = GetAccordionElement(accordionName);
            if (pageElement == null) return false;
            return pageElement.Displayed;
        }

        private IWebElement GetAccordionElement(string elementName)
        {
            DebugOutput.Log($"proc - GetAccordionElement from current page {elementName}");
            var pageLocator = CurrentPage.Elements[elementName];
            DebugOutput.Log($"We have the LOCATOR {pageLocator}");
            return SeleniumUtil.GetElement(pageLocator);
        }

    }
}
