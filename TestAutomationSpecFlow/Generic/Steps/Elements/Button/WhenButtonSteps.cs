using Core.Logging;
using Generic.Steps;
using Generic.Steps.Helpers.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace Generic.Elements.Steps.Button
{
    [Binding]
    public class WhenButtonSteps : StepsBase
    {
        public WhenButtonSteps(IStepHelpers helpers) : base(helpers)
        {
        }

        [When(@"I Click On Button ""([^""]*)""")]
        public void WhenIClickOnButton(string buttonName)
        {
            string proc = $"When I Click On Button {buttonName}";
            if (CombinedSteps.OuputProc(proc))
            {
                if (Helpers.Button.ClickButton(buttonName))
                {
                    return;
                }
                Assert.Fail(proc + "FAILED");
                return;
            }
            Assert.Inconclusive();
        }

        [When(@"I Double Click On Button ""([^""]*)""")]
        public void WhenIDoubleClickOnButton(string buttonName)
        {
            string proc = $"When I Double Click On Button {buttonName}";
            if (CombinedSteps.OuputProc(proc))
            {
                if (Helpers.Button.DoubleClick(buttonName))
                {
                    return;
                }
                Assert.Fail(proc + "FAILED");
                return;
            }
            Assert.Inconclusive();
        }

        [When(@"I Right Click On Button ""([^""]*)""")]
        public void WhenIRightClickOnButton(string buttonName)
        {
            string proc = $"When I Right Click On Button {buttonName}";
            if (CombinedSteps.OuputProc(proc))
            {
                if (Helpers.Button.RightClick(buttonName))
                {
                    return;
                }
                Assert.Fail(proc + "FAILED");
                return;
            }
            Assert.Inconclusive();
        }

        [When(@"I Mouse Over Button ""([^""]*)""")]
        public void WhenIMouseOverButton(string buttonName)
        {
            string proc = $"When I Mouse Over Button {buttonName}";
            if (CombinedSteps.OuputProc(proc))
            {
                if (Helpers.Button.MouseOver(buttonName))
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
