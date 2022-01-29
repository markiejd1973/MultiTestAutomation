
using Core.Configuration;
using Core.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace Generic.Steps
{
    [Binding]
    public class GivenSteps
    {

        [Given(@"I Have Failed")]
        public void GivenIHaveFailed()
        {
            string proc = "Given I Have Failed";
            CombinedSteps.Failure(proc);
            return;
        }


        [Given("the first number is (.*)")]
        public void GivenTheFirstNumberIs(int number)
        {
            string proc = $"Given the first number is {number}";
            if (CombinedSteps.OuputProc(proc))
            {
                DebugOutput.Log("Do something that passes");
                DebugOutput.Log($"The EPOCH = {EPOCHControl.epoch}");
                return;
            }
            Assert.Inconclusive();
        }

    }
}
