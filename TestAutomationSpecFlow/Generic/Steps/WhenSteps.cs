
using Core.Logging;
using Generic.Steps.Helpers.Interfaces;
using TechTalk.SpecFlow;

namespace Generic.Steps
{
    [Binding]
    public class WhenSteps : StepsBase
    {
        public WhenSteps(IStepHelpers helpers) : base(helpers)
        {
        }


    }
}
