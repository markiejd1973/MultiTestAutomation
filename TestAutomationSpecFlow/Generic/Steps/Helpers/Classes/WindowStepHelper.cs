﻿using Core;
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

        public bool IsDisplayed(string windowsName)
        {
            DebugOutput.Log($"HELLO");
            By windowsLocator = By.Name(windowsName);
            var element = SeleniumUtil.GetElement(windowsLocator);
            return element.Displayed;
        }

        public bool WriteInWindow(string documentName, string text)
        {
            By windowsLocator = By.Name(documentName);
            var element = SeleniumUtil.GetElement(windowsLocator);
            return SeleniumUtil.EnterText(element, text);
        }

    }
}