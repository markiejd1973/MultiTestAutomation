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
            var accordionElement = GetAccordionElement(accordionName);
            if (accordionElement == null) return false;
            return accordionElement.Displayed;
        }


        public bool ClickSubElement(string accordionName, string value)
        {
            DebugOutput.Log($"proc - ClickSubElement {accordionName}");
            accordionName = accordionName.ToLower();
            var accordionElement = GetAccordionElement(accordionName);
            if (accordionElement == null) return false;
            var xPath = $"//div[contains(text(),'{value}')]/../div[2]/div[2]";
            DebugOutput.Log(xPath);
            var subElementLocator = By.XPath(xPath);
            var subElement = SeleniumUtil.GetElementUnderElement(accordionElement, subElementLocator);
            if (subElement == null) return false;
            subElement.Click();
            return true;
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
