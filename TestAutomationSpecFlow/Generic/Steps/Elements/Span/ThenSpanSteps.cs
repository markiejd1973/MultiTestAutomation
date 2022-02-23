using Core.Logging;
using Generic.Steps;
using Generic.Steps.Helpers.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace Generic.Elements.Steps.Button
{
    [Binding]
    public class ThenSpanSteps : StepsBase
    {
        public ThenSpanSteps(IStepHelpers helpers) : base(helpers)
        {
        }

        [Then(@"Span ""([^""]*)"" Is Displayed")]
        public void ThenSpanIsDisplayed(string spanText)
        {
            if (Helpers.Span.LinkDisplayedByName(spanText)) 
            {
                return;
            }
            Assert.Fail("failed");
        }


    }
}
