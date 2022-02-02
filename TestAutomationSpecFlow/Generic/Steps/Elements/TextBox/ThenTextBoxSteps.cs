using Core.Logging;
using Generic.Steps;
using Generic.Steps.Helpers.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace Generic.Elements.Steps.TextBox
{
    [Binding]
    public class ThenTextBoxSteps : StepsBase
    {
        public ThenTextBoxSteps(IStepHelpers helpers) : base(helpers)
        {
        }

        [Then(@"TextBox ""([^""]*)"" Is Displayed")]
        public void GivenButtonIsDisplayed(string x)
        {
            throw new PendingStepException();
        }

    }
}
