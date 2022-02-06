using Core.Logging;
using Generic.Steps;
using Generic.Steps.Helpers.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace Generic.Elements.Steps.Button
{
    [Binding]
    public class WhenLinkSteps : StepsBase
    {
        public WhenLinkSteps(IStepHelpers helpers) : base(helpers)
        {
        }

        [When(@"I Click Link ""([^""]*)""")]
        public void WhenIClickLink(string linkName)
        {
            string proc = $"When I Click Link {linkName}";
            if (CombinedSteps.OuputProc(proc))
            {
                if (Helpers.Link.ClickLink(linkName))
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
