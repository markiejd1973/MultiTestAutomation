using Core.Logging;
using Generic.Steps;
using Generic.Steps.Helpers.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace Generic.Elements.Steps.Button
{
    [Binding]
    public class GivenButtonSteps : StepsBase
    {
        public GivenButtonSteps(IStepHelpers helpers) : base(helpers)
        {
        }

        [Given(@"Button ""([^""]*)"" Is Disabled")]
        public void GivenButtonIsDisabled(string x)
        {
            throw new PendingStepException();
        }

    }
}
