using Core.Logging;
using Generic.Steps;
using Generic.Steps.Helpers.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace Generic.Elements.Steps.Button
{
    [Binding]
    public class WhenSpanSteps : StepsBase
    {
        public WhenSpanSteps(IStepHelpers helpers) : base(helpers)
        {
        }

        [When(@"I Click On Span ""([^""]*)""")]
        public void WhenIClickOnSpan(string text)
        {
            if (Helpers.Span.ClickOnLinkByName(text))
            {
                return;
            }
            Assert.Fail("failed");
        }


    }
}
