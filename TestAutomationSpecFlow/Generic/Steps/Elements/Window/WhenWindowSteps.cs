using Core;
using Core.Logging;
using Generic.Steps;
using Generic.Steps.Helpers.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace Generic.Elements.Steps.Button
{
    [Binding]
    public class WhenWindowSteps : StepsBase
    {
        public WhenWindowSteps(IStepHelpers helpers) : base(helpers)
        {
        }


    }
}
