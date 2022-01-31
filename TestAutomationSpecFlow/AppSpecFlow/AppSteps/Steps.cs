using AppSpecFlow.Libs;
using Core.Configuration;
using Core.Logging;
using Generic.Steps;
using Generic.Steps.Helpers.Interfaces;

namespace AppSpecFlow.AppSteps
{
    [Binding]
    public class Steps : StepsBase
    {
        public Steps(IStepHelpers helpers
            ) : base(helpers)
        {
        }


        [Then(@"I Am Here")]
        public void ThenIAmHere()
        {
            DebugOutput.Log($"ThenIAmHere >>>>>>>>>>>>");
            DebugOutput.Log(TargetConfiguration.Configuration.ApplicationType);
            Helpers.Button.Hello();
        }

        [Given(@"the first number is (.*)")]
        public void GivenTheFirstNumberIs(int p0)
        {
            DebugOutput.Log($"GivenTheFirstNumberIs ");
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