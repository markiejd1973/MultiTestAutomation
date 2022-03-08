using Core.Logging;
using Generic.Steps;
using Generic.Steps.Helpers.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace Generic.Elements.Steps.Button
{
    [Binding]
    public class GivenWindowSteps : StepsBase
    {
        public GivenWindowSteps(IStepHelpers helpers) : base(helpers)
        {
        }

        [Given(@"Window ""([^""]*)"" Is Displayed")]
        public void GivenWindowIsDisplayed(string windowName)
        {
            string proc = $"Given Window {windowName} Is Displayed";
            if (CombinedSteps.OuputProc(proc))
            {
                if (Helpers.Window.IsDisplayed(windowName))
                {
                    DebugOutput.Log($"Is Displayed setting current page");
                    Helpers.Page.SetCurrentPage(windowName);
                    return;
                }
                Assert.Fail(proc + "FAILED");
                return;
            }
            Assert.Inconclusive();
        }


    }
}
