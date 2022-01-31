
using Core.Logging;
using Generic.Steps.Helpers.Interfaces;
using TechTalk.SpecFlow;

namespace Generic.Steps
{
    [Binding]
    public class ThenSteps : StepsBase
    {
        public ThenSteps(IStepHelper helpers) : base(helpers)
        {
        }


    }
}
