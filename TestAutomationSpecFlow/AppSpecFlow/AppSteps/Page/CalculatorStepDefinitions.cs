using Core.Logging;

namespace App_SpecFlow.AppSteps
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {
        [Then("the result should be (.*)")]
        public void ThenTheResultShouldBe(int result)
        {
            DebugOutput.Log($"GivenTheSecondNumberIs {result}");
        }
    }
}