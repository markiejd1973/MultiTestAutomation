using Core.Configuration;
using BoDi;
using Core;
using Core.FileIO;
using Core.Logging;
using System.Reflection;
using Generic.Steps.Helpers.Interfaces;
using Generic.Steps.Helpers.Classes;

namespace AppSpecFlow.Libs
{
    [Binding]
    public class Hooks
    {

        [BeforeTestRun]
        public static void TestSetup()
        {
            var assembly = Assembly.Load("AppTargets");
            TargetForms.Instance.PopulateList(assembly);
            TargetConfiguration.ReadJson();
            DebugOutput.Log($"In hooks > {TargetConfiguration.Configuration.ApplicationType}");
        }


        [AfterTestRun]
        public static void TestCleanUp()
        {

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
            container.RegisterTypeAs<IStepHelper, IStepHelper>();
            container.RegisterInstanceAs<ITargetForms>(TargetForms.Instance);
        }

    }
}