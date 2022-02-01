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

namespace AppSpecFlow.Libs
{
    [Binding]
    public class Hooks
    {
        public static IWebDriver? driver;

        [BeforeTestRun]
        public static void TestSetup()
        {
            var assembly = Assembly.Load("AppTargets");
            TargetForms.Instance.PopulateList(assembly);
            TargetConfiguration.ReadJson();

            DebugOutput.Log($"Application Type = {TargetConfiguration.Configuration.ApplicationType}");
            if (TargetConfiguration.Configuration.ApplicationType.ToLower() == "web")
            {
                DebugOutput.Log($"Web based testing");
                DebugOutput.Log($"Application First Page Name = {TargetConfiguration.Configuration.FirstPage}");
                if (TargetConfiguration.Configuration.Browser.ToLower() == "chrome")
                {
                    driver = new ChromeDriver("c:\\chromedriver\\");
                }
                if (TargetConfiguration.Configuration.Browser.ToLower() == "firefox")
                {
                    driver = new FirefoxDriver("c:\\chromedriver\\");
                }
                if (driver == null)
                {
                    DebugOutput.Log($"Failure here due to NO DRIVER");
                    Assert.Fail("Failed no driver");
                    return;
                }    
                SeleniumUtil.webDriver = driver;
                DebugOutput.Log($"App started - navigate to StartURL {TargetConfiguration.Configuration.StartUrl}");
                driver.Url = $"{TargetConfiguration.Configuration.StartUrl}";
            }
        }


        [AfterTestRun]
        public static void TestCleanUp()
        {
            driver.Close();
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