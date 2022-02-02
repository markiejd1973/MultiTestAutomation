using Core.Logging;
using Generic.Steps;
using Generic.Steps.Helpers.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace Generic.Elements.Steps.Button
{
    [Binding]
    public class ThenAccordionSteps : StepsBase
    {
        public ThenAccordionSteps(IStepHelpers helpers) : base(helpers)
        {
        }

        [Then(@"""([^""]*)"" In Accordion ""([^""]*)"" Is Expanded")]
        public void ThenInAccordionIsExpanded(string value, string accordianName)
        {
            if (!Helpers.Accordion.IsElementExtended(accordianName, value))
            {
                DebugOutput.Log($"Is not expanded!");
                Assert.Fail("failed here!");
                return;
            }
            DebugOutput.Log($"{value} is EXPANDED");
        }

        [Then(@"""([^""]*)"" In Accordion ""([^""]*)"" Is Not Expanded")]
        public void ThenInAccordionIsNotExpanded(string value, string accordianName)
        {
            if (!Helpers.Accordion.IsElementNotExtended(accordianName, value))
            {
                DebugOutput.Log($"Is not expanded!");
                Assert.Fail("failed here!");
                return;
            }
            DebugOutput.Log($"{value} is EXPANDED");
        }



        [Then(@"Accordion ""([^""]*)"" Is Displayed")]
        public void ThenAccordionIsDisplayed(string accordionName)
        {
            if (!Helpers.Accordion.IsDisplayed(accordionName))
            {
                DebugOutput.Log($"failed");
                Assert.Fail("failed here!");
                return;
            }
            DebugOutput.Log($"{accordionName} isDisplayed");    
        }

    }
}
