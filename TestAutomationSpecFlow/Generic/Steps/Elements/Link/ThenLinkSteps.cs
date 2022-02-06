using Core.Logging;
using Generic.Steps;
using Generic.Steps.Helpers.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace Generic.Elements.Steps.Button
{
    [Binding]
    public class ThenLinkSteps : StepsBase
    {
        public ThenLinkSteps(IStepHelpers helpers) : base(helpers)
        {
        }

        [Then(@"Link ""([^""]*)"" Is Displayed")]
        public void ThenLinkIsDisplayed(string linkName)
        {
            string proc = $"Then Link {linkName} Is Displayed";
            if (CombinedSteps.OuputProc(proc))
            {
                if (Helpers.Link.IsDisplayed(linkName))
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
