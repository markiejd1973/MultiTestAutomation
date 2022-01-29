using Core.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using Generic.Steps.Helpers.Classes;
using Generic.Steps.Helpers.Interfaces;

namespace Generic.Steps.Button
{
    [Binding]
    public class GivenButtonSteps : StepsBase
    {
        public GivenButtonSteps(IStepHelpers helpers) : base(helpers)
        {
        }

        [Given(@"Button ""([^""]*)"" Is Disabled")]
        public void GivenButtonIsDisabled(string buttonName)
        {
            string proc = $"Given Button {buttonName} Is Disabled";
            if (CombinedSteps.OuputProc(proc))
            {
                if(!Helpers.Button.Disabled(buttonName))
                {
                    CombinedSteps.Failure(proc);
                    return;
                }
                return;
            }
            Assert.Inconclusive();
        }

    }
}
