
using Core.Logging;
using Generic.Steps.Helpers.Interfaces;
using TechTalk.SpecFlow;

namespace Generic.Steps
{
    [Binding]
    public class GivenSteps
    {

        [Given("the first number is (.*)")]
        public void GivenTheFirstNumberIs(int number)
        {
            DebugOutput.Log($"GivenTheFirstNumberIs {number}");
        }

    }
}
