using Core.Logging;
using Generic.Steps;
using Generic.Steps.Helpers.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace Generic.Elements.Steps.Button
{
    [Binding]
    public class ThenPageSteps : StepsBase
    {
        public ThenPageSteps(IStepHelpers helpers) : base(helpers)
        {
        }

        [Then(@"Page Displays Message ""([^""]*)""")]
        public void ThenPageDisplaysMessage(string message)
        {
            {
                string proc = $"Then Page Displays Message {message}";
                if (CombinedSteps.OuputProc(proc))
                {
                    if (Helpers.Page.IsMessageDisplayed(message))
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
}
