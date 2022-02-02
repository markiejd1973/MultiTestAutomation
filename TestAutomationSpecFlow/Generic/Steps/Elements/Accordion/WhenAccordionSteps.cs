using Core.Logging;
using Generic.Steps;
using Generic.Steps.Helpers.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace Generic.Elements.Steps.Accordion
{
    [Binding]
    public class WhenAccordionSteps : StepsBase
    {
        public WhenAccordionSteps(IStepHelpers helpers) : base(helpers)
        {
        }

        [When(@"I Click Group ""([^""]*)"" In Accordion ""([^""]*)""")]
        public void WhenIClickGroupInAccordion(string groupName, string accordianName)
        {
            string proc = $"When I Click Group {groupName} In Accordion {accordianName}";
            if (CombinedSteps.OuputProc(proc))
            {
                if (Helpers.Accordion.GroupClick(accordianName, groupName))
                {
                    return;
                }
                Assert.Fail(proc + "FAILED");
                return;
            }
            Assert.Inconclusive();
        }

        [When(@"I Click Button ""([^""]*)"" In Accordion ""([^""]*)""")]
        public void WhenIClickButtonInAccordion(string buttonName, string accordianName)
        {
            string proc = $"When I Click Button {buttonName} In Accordion {accordianName}";
            if (CombinedSteps.OuputProc(proc))
            {
                if (Helpers.Accordion.ButtonClick(accordianName, buttonName))
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
