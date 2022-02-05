using Core.Logging;
using Generic.Steps;
using Generic.Steps.Helpers.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace Generic.Elements.Steps.Button
{
    [Binding]
    public class ThenButtonSteps : StepsBase
    {
        public ThenButtonSteps(IStepHelpers helpers) : base(helpers)
        {
        }

        [Then(@"Button ""([^""]*)"" Is Displayed")]
        public void ThenButtonIsDisplayed(string buttonName)
        {
            string proc = $"Then Button {buttonName} Is Displayed";
            if (CombinedSteps.OuputProc(proc))
            {
                if (Helpers.Button.IsDisplayed(buttonName))
                {
                    return;
                }
                Assert.Fail(proc + "FAILED");
                return;
            }
            Assert.Inconclusive();
        }


    }
}
