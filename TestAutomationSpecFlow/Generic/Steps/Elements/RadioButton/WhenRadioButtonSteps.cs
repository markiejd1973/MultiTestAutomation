using Core.Logging;
using Generic.Steps;
using Generic.Steps.Helpers.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace Generic.Elements.Steps.Button
{
    [Binding]
    public class WhenRadioButtonSteps : StepsBase
    {
        public WhenRadioButtonSteps(IStepHelpers helpers) : base(helpers)
        {
        }

        [When(@"I Click On RadioButton ""([^""]*)""")]
        public void WhenIClickOnRadioButton(string radioButtonName)
        {
            string proc = $"When I Click On Radiobutton {radioButtonName}";
            if (CombinedSteps.OuputProc(proc))
            {
                if (Helpers.RadioButton.Select(radioButtonName))
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
