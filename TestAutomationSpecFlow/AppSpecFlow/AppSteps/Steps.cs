using AppSpecFlow.Libs;
using Core.Configuration;
using Core.Logging;

namespace App_SpecFlow.AppSteps
{
    [Binding]
    public sealed class Steps
    {
        [Then(@"I Am Here")]
        public void ThenIAmHere()
        {
            DebugOutput.Log($"ThenIAmHere >>>>>>>>>>>>");
            DebugOutput.Log(TargetConfiguration.Configuration.ApplicationType);
        }


        [When("the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            DebugOutput.Log($"WhenTheTwoNumbersAreAdded ");
        }


        [Given(@"the second number is (.*)")]
        public void GivenTheSecondNumberIs(int p0)
        {
            DebugOutput.Log($"GivenTheSecondNumberIs {p0}");
        }

    }
}