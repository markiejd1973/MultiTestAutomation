using Core.Logging;
using Generic.Steps;
using Generic.Steps.Helpers.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace Generic.Elements.Steps.Button
{
    [Binding]
    public class WhenTextBoxSteps : StepsBase
    {
        public WhenTextBoxSteps(IStepHelpers helpers) : base(helpers)
        {
        }

        [When(@"I Enter ""([^""]*)"" In TextBox ""([^""]*)""")]
        public void WhenIEnterInTextBox(string text, string textBoxName)
        {
            string proc = $"When I Enter {text} In TextBox {textBoxName}";
            if (CombinedSteps.OuputProc(proc))
            {
                if (Helpers.TextBox.EnterText(textBoxName, text))
                {
                    return;
                }
                Assert.Fail(proc + "FAILED");
                return;
            }
            Assert.Inconclusive();
        }

        [When(@"I Clear Then Enter ""([^""]*)"" In TextBox ""([^""]*)""")]
        public void WhenIClearThenEnterInTextBox(string text, string textBoxName)
        {
            string proc = $"When I Enter {text} In TextBox {textBoxName}";
            if (CombinedSteps.OuputProc(proc))
            {
                if (Helpers.TextBox.ClearThenEnterText(textBoxName, text))
                {
                    return;
                }
                Assert.Fail(proc + "FAILED");
                return;
            }
            Assert.Inconclusive();
        }


        [When(@"I Enter ""([^""]*)"" Then Press ""([^""]*)"" In TextBox ""([^""]*)""")]
        public void WhenIEnterThenPressInTextBox(string text, string key, string textBoxName)
        {
            string proc = $"When I Enter {text} Then Press {key} In TextBox {textBoxName}";
            if (CombinedSteps.OuputProc(proc))
            {
                if (Helpers.TextBox.EnterTextAndKey(textBoxName, text, key))
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
