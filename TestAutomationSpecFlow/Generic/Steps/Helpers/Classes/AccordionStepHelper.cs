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

        int versionNumber = 0; //first is zero
        /// <summary>
        /// From the Accordion Element!
        /// </summary>
        /// Find accordion elment from Page.cs
        /// 
        readonly string[] subElementXPathStart = { $"//div[contains(text(),'" }; //group
        readonly string[] subElementXPathEnd = { $"')]/../../../span[1]/div[1]" }; //group
        readonly string[] subElementExpanded = { $"./../../*[@class='element-list collapse show']" }; //element-list collapse (show)
        readonly string[] subElementButtonsStart = { $"//span[contains(text(),'" }; //Buttons
        readonly string[] subElementButtonsEnd = { $"')]" }; //Buttons


        readonly string[] subElementXPathClick = { "/../div[2]/div[2]" };
        readonly string[] subListShow = { "//div[contains(@class, 'element-list collapse show')]" };

        public bool IsDisplayed(string accordionName)
        {
            DebugOutput.Log($"IsDisplayed {accordionName}");
            var accordionElement = GetAccordionElement(accordionName);
            if (accordionElement == null) return false;
            return accordionElement.Displayed;
        }

        public bool GroupIsDisplayed(string accordionName, string groupName)
        {
            DebugOutput.Log($"GroupIsDisplayed {accordionName} {groupName}");
            var accordionElement = GetAccordionElement(accordionName);
            if (accordionElement == null) return false;
            var groupElement = GetGroupElement(accordionElement, groupName);
            if (groupElement == null) return false;
            return groupElement.Displayed;
        }

        public bool GroupIsExpanded(string accordionName, string groupName)
        {
            DebugOutput.Log($"GroupIsExpanded {accordionName} {groupName}");
            var accordionElement = GetAccordionElement(accordionName);
            if (accordionElement == null) return false;
            var groupElement = GetGroupElement(accordionElement, groupName);
            if (groupElement == null) return false;
            var groupExpandedElement = GetGroupExpanded(groupElement);
            if (groupExpandedElement == null) return false ;
            return true;
        }

        public bool GroupIsNotExpanded(string accordionName, string groupName)
        {
            DebugOutput.Log($"GroupIsExpanded {accordionName} {groupName}");
            var accordionElement = GetAccordionElement(accordionName);
            if (accordionElement == null) return false;
            var groupElement = GetGroupElement(accordionElement, groupName);
            if (groupElement == null) return false;
            var groupExpandedElement = GetGroupExpanded(groupElement);
            if (groupExpandedElement == null) return true;
            return false;
        }

        public bool GroupClick(string accordionName, string groupName)
        {
            DebugOutput.Log($"GroupClick {accordionName} {groupName}");
            var accordionElement = GetAccordionElement(accordionName);
            if (accordionElement == null) return false;
            var groupElement = GetGroupElement(accordionElement, groupName);
            if (groupElement == null) return false;
            return SeleniumUtil.Click(groupElement);
        }

        public bool ButtonClick(string accordionName, string buttonName)
        {
            DebugOutput.Log($"GroupClick {accordionName} {buttonName}");
            var accordionElement = GetAccordionElement(accordionName);
            if (accordionElement == null) return false;
            var buttonElement = GetButtonElement(accordionElement, buttonName);
            return SeleniumUtil.Click(buttonElement);
        }

        public bool IsButtonDisplayed(string accordionName, string buttonName)
        {
            DebugOutput.Log($"IsButtonDisplayed {accordionName} {buttonName}");
            var accordionElement = GetAccordionElement(accordionName);
            if (accordionElement == null) return false;
            var buttonElement = GetButtonElement(accordionElement, buttonName);
            if (buttonElement == null) return false;
            return buttonElement.Displayed;
        }

        private IWebElement GetButtonElement(IWebElement accordionElement, string buttonName)
        {
            DebugOutput.Log($"GetButtonElement {accordionElement}");
            var buttonXPath = subElementButtonsStart[versionNumber] + buttonName + subElementButtonsEnd[versionNumber];
            var buttonLocator = By.XPath(buttonXPath); 
            var element = SeleniumUtil.GetElementUnderElement(accordionElement, buttonLocator);
            DebugOutput.Log($"button name {buttonName} = {element}");
            return element;
        }

        private IWebElement GetGroupExpanded(IWebElement groupElement)
        {
            DebugOutput.Log($"GetGroupExpanded {groupElement}");
            var groupExpandedXPath = subElementExpanded[versionNumber];
            var groupExpandedLocator = By.XPath(groupExpandedXPath);
            var element =  SeleniumUtil.GetElementUnderElement(groupElement, groupExpandedLocator, 1);
            DebugOutput.Log($"Group Expanded = {element}");
            return element;
        }

        private IWebElement GetGroupElement(IWebElement accordionElement, string groupName)
        {
            DebugOutput.Log($"GetGroupElement {accordionElement} {groupName}");
            var groupXPath = subElementXPathStart[versionNumber] + groupName + subElementXPathEnd[versionNumber] ;
            var groupLocator = By.XPath(groupXPath);
            var element = SeleniumUtil.GetElementUnderElement(accordionElement, groupLocator);
            DebugOutput.Log($"Group name {groupName} = {element} {groupXPath}");
            return element;
        }

        private IWebElement GetAccordionElement(string accordionName)
        {
            DebugOutput.Log($"IsDisplayed {accordionName}");
            var accordionLocator = CurrentPage.Elements[accordionName];
            DebugOutput.Log($"We have the LOCATOR for Accordion {accordionName} {accordionLocator}");
            var element =  SeleniumUtil.GetElement(accordionLocator);
            DebugOutput.Log($"Accordion Element {accordionName} = {element}");
            return element;
        }

    }

}
