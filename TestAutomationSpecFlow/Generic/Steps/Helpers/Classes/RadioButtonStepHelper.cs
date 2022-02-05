using Core;
using Core.Logging;
using Generic.Steps.Helpers.Interfaces;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Generic.Steps.Helpers.Classes
{
    public class RadioButtonStepHelper : StepHelper, IRadioButtonStepHelper
    {
        private readonly ITargetForms targetForms;
        public RadioButtonStepHelper(FeatureContext featureContext, ITargetForms targetForms) : base(featureContext)
        {
            this.targetForms = targetForms;
        }

        int versionNumber = 0;

        private readonly By[] parentLocator = { By.XPath($"./..") };
        private readonly By[] inputLocator = { By.XPath($"./input") };
        private readonly By[] labelLocator = { By.ClassName($"custom-control-label") };

        public bool IsDisplayed(string radioButtonName)
        {
            DebugOutput.Log($"proc - IsDisplayed {radioButtonName}");
            radioButtonName = GetRadioButtonName(radioButtonName);
            var radioButtonElement = GetRadioButtonElement(radioButtonName);
            if (radioButtonElement == null) return false;
            DebugOutput.Log($"We have the RadioButton Element");
            return radioButtonElement.Displayed;
        }

        public bool IsEnabled(string radioButtonName)
        {
            DebugOutput.Log($"proc - IsEnabled {radioButtonName}");
            radioButtonName = GetRadioButtonName(radioButtonName);
            var radioButtonElement = GetRadioButtonElement(radioButtonName);
            if (radioButtonElement == null) return false;
            var radioButtonInputElement = SeleniumUtil.GetElementUnderElement(radioButtonElement, inputLocator[versionNumber]);
            if (radioButtonInputElement == null) return false;
            return SeleniumUtil.IsEnabled(radioButtonInputElement);
        }

        public bool IsSelected(string radioButtonName)
        {
            DebugOutput.Log($"proc - IsSelected {radioButtonName}");
            radioButtonName= GetRadioButtonName(radioButtonName);
            var radioButtonElement = GetRadioButtonElement(radioButtonName);
            if (radioButtonElement == null) return false;
            var radioButtonInputElement = SeleniumUtil.GetElementUnderElement(radioButtonElement, inputLocator[versionNumber]);
            if (radioButtonInputElement == null) return false;
            DebugOutput.Log($"{radioButtonInputElement.Selected}");
            return SeleniumUtil.IsSelected(radioButtonInputElement);
        }

        public bool Select(string radioButtonName)
        {
            DebugOutput.Log($"Select {radioButtonName}");
            radioButtonName = GetRadioButtonName(radioButtonName);
            var radioButtonElement = GetRadioButtonElement(radioButtonName);
            if (radioButtonElement == null) return false;
            SeleniumUtil.Click(radioButtonElement);
            var element = SeleniumUtil.GetElement(By.Id("yesRadio"));
            DebugOutput.Log($"YES INPUT {element}");
            return SeleniumUtil.Click(radioButtonElement);
        }


        ///Private 
        ///

        private string GetRadioButtonName(string radioButtonName)
        {
            DebugOutput.Log($"GetRadioButtonName {radioButtonName}");
            radioButtonName = radioButtonName.ToLower();
            if (radioButtonName.Contains("radiobutton")) return radioButtonName;
            return radioButtonName + " radiobutton";
        }

        private IWebElement GetRadioButtonElement(string radioButtonName)
        {
            DebugOutput.Log($"GetRadioButtonElement {radioButtonName}");
            var radioButtonLocator = CurrentPage.Elements[radioButtonName];
            DebugOutput.Log($"We have the LOCATOR for RadioButton {radioButtonName} {radioButtonLocator}");
            var element = SeleniumUtil.GetElement(radioButtonLocator);
            DebugOutput.Log($"RadioButton {radioButtonName} Element {radioButtonLocator} = {element}");
            DebugOutput.Log($"But we need its parent");
            var parentElement = SeleniumUtil.GetElementUnderElement(element, parentLocator[versionNumber]);
            return parentElement;
        }

    }
}
