
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


    }
}
