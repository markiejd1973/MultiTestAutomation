using Core.Logging;
using Generic.Steps;
using Generic.Steps.Helpers.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace Generic.Elements.Steps.Button
{
    [Binding]
    public class WhenAccordionSteps : StepsBase
    {
        public WhenAccordionSteps(IStepHelpers helpers) : base(helpers)
        {
        }

        [When(@"I Click ""([^""]*)"" In Accordion ""([^""]*)""")]
        public void WhenIClickInAccordion(string subElement, string accordion )
        {
            if (!Helpers.Accordion.ClickSubElement(accordion, subElement))
            {
                DebugOutput.Log($"failed to click!");
                Assert.Fail("HER");
                return;
            }
        }


    }
}
