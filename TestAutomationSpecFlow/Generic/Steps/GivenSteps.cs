
using AppTargets.Configuration;
using Core.Logging;
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
            DebugOutput.Log($"jytytyjytj {TargetConfiguration.Configuration.PositiveTimeout}");
        }

    }
}
