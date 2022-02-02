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

        int subElementNumber = 0; //first is zero
        /// <summary>
        /// From the Accordion Element!
        /// </summary>
        readonly string[] subElementXPathStart = { "//div[contains(text(),'" };
        readonly string[] subElementXPathEnd = { "')]" };
        readonly string[] subElementXPathClick = { "/../div[2]/div[2]" };
        readonly string[] subListShow = { "//div[contains(@class, 'element-list collapse show')]" };

        public bool IsDisplayed(string accordionName)
        {
            DebugOutput.Log($"proc - IsDisplayed {accordionName}");
            accordionName = accordionName.ToLower();    
            var accordionElement = GetAccordionElement(accordionName);
            if (accordionElement == null) return false;
            return accordionElement.Displayed;
        }

        public bool IsElementDisplayed(string accordionName, string value)
        {
            DebugOutput.Log($"proc - IsElementDisplayed {accordionName} {value}");
            accordionName = accordionName.ToLower();
            var accordionElement = GetAccordionElement(accordionName);
            if (accordionElement == null) return false;
            var subElement = GetAccordionSubElement(accordionElement, value);
            if (subElement == null) return false;            
            return subElement.Displayed;
        }

        public bool ClickSubElement(string accordionName, string value)
        {
            DebugOutput.Log($"proc - ClickSubElement {accordionName} {value}");
            accordionName = accordionName.ToLower();
            var accordionElement = GetAccordionElement(accordionName);
            var subElement = GetAccordionSubElement(accordionElement, value);
            if (subElement == null) return false;
            try
            {
                subElement.Click();
                return true;
            }
            catch
            {
                DebugOutput.Log($"Failed to click on subElement {subElement}");
                return false;
            }
        }

        public bool IsElementExtended(string accordionName, string value)
        {
            DebugOutput.Log($"proc - IsElementExtended {accordionName} {value}");
            accordionName = accordionName.ToLower();
            var accordionElement = GetAccordionElement(accordionName);
            if (accordionElement == null) return false;
            var subElement = GetAccordionSubElement(accordionElement, value);
            if (subElement == null) return false;
            var listShowElement = GetListShow(subElement);
            if (listShowElement == null) return false;
            return true;
        }
        public bool IsElementNotExtended(string accordionName, string value)
        {
            DebugOutput.Log($"proc - IsElementExtended {accordionName} {value}");
            accordionName = accordionName.ToLower();
            var accordionElement = GetAccordionElement(accordionName);
            if (accordionElement == null) return false;
            var subElement = GetAccordionSubElement(accordionElement, value);
            if (subElement == null) return false;
            var listShowElement = GetListShow(subElement, 1);
            if (listShowElement == null) return true;
            return false;
        }

        private IWebElement GetAccordionElement(string elementName)
        {
            DebugOutput.Log($"proc - GetAccordionElement from current page {elementName}");
            var accordionLocator = CurrentPage.Elements[elementName];
            DebugOutput.Log($"We have the LOCATOR {accordionLocator}");
            return SeleniumUtil.GetElement(accordionLocator);
        }

        private IWebElement GetAccordionSubElement(IWebElement accordionElement, string value)
        {
            var xPath = $"{subElementXPathStart[subElementNumber]}{value}{subElementXPathEnd[subElementNumber]}{subElementXPathClick[subElementNumber]}";
            DebugOutput.Log(xPath);
            var subElementLocator = By.XPath(xPath);
            var subElement = SeleniumUtil.GetElementUnderElement(accordionElement, subElementLocator);
            if (subElement == null) return null;
            return subElement;
        }

        private IWebElement GetListShow(IWebElement subElement, int timeout = 0)
        {
            var xPath = $"{subListShow[0]}";
            DebugOutput.Log(xPath);
            var listLocator = By.XPath(xPath);
            var listElement = SeleniumUtil.GetElementUnderElement(subElement, listLocator, timeout);
            if (listElement == null) return null;
            return listElement;
        }


    }

}
