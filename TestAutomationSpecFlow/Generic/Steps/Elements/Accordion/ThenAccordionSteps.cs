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

        [Then(@"Accordion ""([^""]*)"" Is Displayed")]
        public void ThenAccordionIsDisplayed(string accordionName)
        {
            if (!Helpers.Accordion.IsDisplayed(accordionName))
            {
                DebugOutput.Log($"failed");
                Assert.Fail("failed here!");
            }
            DebugOutput.Log($"{accordionName} isDisplayed");    
        }

    }
}
