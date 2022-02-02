using Core.Logging;
using Generic.Steps;
using Generic.Steps.Helpers.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace Generic.Elements.Steps.Accordion
{
    [Binding]
    public class ThenAccordionSteps : StepsBase
    {
        public ThenAccordionSteps(IStepHelpers helpers) : base(helpers)
        {
        }

        [Then(@"Accordion ""([^""]*)"" Is Displayed")]
        public void ThenAccordionIsDisplayed(string accordianName)
        {
            string proc = $"Then Accordion {accordianName} Is Displayed";
            if (CombinedSteps.OuputProc(proc))
            {
                if (Helpers.Accordion.IsDisplayed(accordianName))
                {
                    return;
                }
                Assert.Fail(proc + "FAILED");
                return;
            }
            Assert.Inconclusive();
        }

        [Then(@"Group ""([^""]*)"" In Accordion ""([^""]*)"" Is Expanded")]
        public void ThenGroupInAccordionIsExpanded(string groupName, string accordianName)
        {
            string proc = $"Then Group {groupName} In Accordion {accordianName} Is Displayed";
            if (CombinedSteps.OuputProc(proc))
            {
                if (Helpers.Accordion.GroupIsExpanded(accordianName, groupName))
                {
                    return;
                }
                Assert.Fail(proc + "FAILED");
                return;
            }
            Assert.Inconclusive();
        }

        [Then(@"Group ""([^""]*)"" In Accordion ""([^""]*)"" Is Not Expanded")]
        public void ThenGroupInAccordionIsNotExpanded(string groupName, string accordianName)
        {
            string proc = $"Then Group {groupName} In Accordion {accordianName} Is Displayed";
            if (CombinedSteps.OuputProc(proc))
            {
                if (Helpers.Accordion.GroupIsNotExpanded(accordianName, groupName))
                {
                    return;
                }
                Assert.Fail(proc + "FAILED");
                return;
            }
            Assert.Inconclusive();
        }

        [Then(@"Button ""([^""]*)"" In Accordion ""([^""]*)"" Displayed")]
        public void ThenButtonInAccordionDisplayed(string buttonName, string accordianName)
        {
            string proc = $"Then Button {buttonName} In Accordion {accordianName} Is Displayed";
            if (CombinedSteps.OuputProc(proc))
            {
                if (Helpers.Accordion.IsButtonDisplayed(accordianName, buttonName))    
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
