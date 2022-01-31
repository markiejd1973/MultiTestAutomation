using Core.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace Generic.Steps.Button
{
    [Binding]
    public class GivenButtonSteps
    {
        [Given(@"Button ""([^""]*)"" Is Disabled")]
        public void GivenButtonIsDisabled(string x)
        {
            
            throw new PendingStepException();
        }

    }
}
