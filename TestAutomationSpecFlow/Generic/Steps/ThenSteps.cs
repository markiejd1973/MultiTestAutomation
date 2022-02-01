
using Core.Logging;
using Generic.Steps.Helpers.Interfaces;
using TechTalk.SpecFlow;

namespace Generic.Steps
{
    [Binding]
    public class ThenSteps : StepsBase
    {
        public ThenSteps(IStepHelpers helpers) : base(helpers)
        {
        }

        [Then(@"Wait ""([^""]*)"" Seconds")]
        public void ThenWaitSeconds(string secondsText)
        {
            var seconds = int.Parse(secondsText);
            seconds *= 1000;
            Thread.Sleep(seconds);
        }


    }
}
