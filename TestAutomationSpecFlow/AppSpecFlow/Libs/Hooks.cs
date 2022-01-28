using AppTargets.Configuration;
using BoDi;
using Core;
using Core.FileIO;
using Core.Logging;
using System.Reflection;

namespace AppSpecFlow.Libs
{
    [Binding]
    public class Hooks
    {

        [BeforeTestRun]
        public static void TestSetup()
        {
            var assembly = Assembly.Load("AppSpecFlow");
            TargetForms.Instance.PopulateList(assembly);
            //var this = TargetCon
            var thisRun = new TestRunProperties("hello");
            var fileDirectory = ".\\AppTargets\\Resources\\";
            var settingsFileName = "settings.json";
            if(!FileChecker.FileCheck(fileDirectory + settingsFileName))
            {
                DebugOutput.Log($"No FILE @ {fileDirectory + settingsFileName}");
            }
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

        }

        [AfterFeature]
        public static void FeatureCloseDown(FeatureContext featureContext)
        {

        }

        [BeforeScenario]
        public void ScenarioSetup(ScenarioContext scenarioContext)
        {

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


    }
}