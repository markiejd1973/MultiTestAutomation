using Core.Configuration;
using BoDi;
using Core;
using Core.FileIO;
using Core.Logging;
using System.Reflection;
using Generic.Steps.Helpers.Interfaces;
using Generic.Steps.Helpers.Classes;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Appium.Enums;

namespace AppSpecFlow.Libs
{
    [Binding]
    public class Hooks
    {
        public static IWebDriver? driver;
        public static WindowsDriver<WindowsElement> newDriver;

        [BeforeTestRun]
        public static void TestSetup()
        {
            var assembly = Assembly.Load("AppTargets");
            TargetForms.Instance.PopulateList(assembly);
            TargetConfiguration.ReadJson();

            DebugOutput.Log($"Application Type = {TargetConfiguration.Configuration.ApplicationType}");
        }

        private static void ChromeDriver()
        {
            driver = new ChromeDriver("c:\\chromedriver\\");
        }


        [AfterTestRun]
        public static void TestCleanUp()
        {
            driver.Close();
            newDriver.Close();

        }

        [BeforeFeature]
        public static void FeatureSetup(FeatureContext featureContext)
        {
            SetEpoch();
        }

        [AfterFeature]
        public static void FeatureCloseDown(FeatureContext featureContext)
        {

        }

        [BeforeScenario]
        public void ScenarioSetup(ScenarioContext scenarioContext)
        {
            RegisterTypes(scenarioContext);

        }

        [AfterScenario]
        public void ScenarioCleanUp(ScenarioContext scenarioContext)
        {
            DebugOutput.Log($" ");
        }

        [BeforeStep]
        public void StepSetup(ScenarioContext scenarioContext)
        {

        }

        [AfterStep]
        public void StepCleanUp(ScenarioContext scenarioContext)
        {

        }

        /// <summary>
        /// Set the epoch value for each feature file so unique text is available
        /// </summary>
        private static void SetEpoch()
        {
            var epochNumber = DateTime.UtcNow.Ticks / 10000000 - 63082281600;
            var epoch = epochNumber.ToString();
            EPOCHControl.epoch = epoch;
            DebugOutput.Log($"This feature test unique id is equal to {epoch}");
        }


        private static void RegisterTypes(ScenarioContext scenarioContext)
        {
            var container = (IObjectContainer)scenarioContext.GetBindingInstance(typeof(IObjectContainer));
            container.RegisterTypeAs<StepHelpers, IStepHelpers>();
            container.RegisterInstanceAs<ITargetForms>(TargetForms.Instance);
        }

    }
}