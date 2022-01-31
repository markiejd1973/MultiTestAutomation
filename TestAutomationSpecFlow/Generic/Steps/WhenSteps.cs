
using Core.Logging;
using Generic.Steps.Helpers.Interfaces;
using TechTalk.SpecFlow;

namespace Generic.Steps
{
    [Binding]
    public class WhenSteps : StepsBase
    {
        public WhenSteps(IStepHelper helpers) : base(helpers)
        {
        }


    }
}
