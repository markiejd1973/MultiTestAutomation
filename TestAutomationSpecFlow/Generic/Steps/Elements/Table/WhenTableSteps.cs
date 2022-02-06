using Core.Logging;
using Generic.Steps;
using Generic.Steps.Helpers.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace Generic.Elements.Steps.Button
{
    [Binding]
    public class WhenTableSteps : StepsBase
    {
        public WhenTableSteps(IStepHelpers helpers) : base(helpers)
        {
        }

        [When(@"I Filter Table ""([^""]*)"" By ""([^""]*)""")]
        public void WhenIFilterTableBy(string tableName, string value)
        {
            string proc = $"When I Filter Table {tableName} By {value}";
            if (CombinedSteps.OuputProc(proc))
            {
                if (Helpers.Table.Filter(tableName, value))
                {
                    return;
                }
                Assert.Fail(proc + "FAILED");
                return;
            }
            Assert.Inconclusive();
        }


    }
}
