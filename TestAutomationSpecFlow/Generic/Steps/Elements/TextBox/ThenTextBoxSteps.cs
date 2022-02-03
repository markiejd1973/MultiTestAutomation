using Core.Logging;
using Generic.Steps;
using Generic.Steps.Helpers.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace Generic.Elements.Steps.TextBox
{
    [Binding]
    public class ThenTextBoxSteps : StepsBase
    {
        public ThenTextBoxSteps(IStepHelpers helpers) : base(helpers)
        {
        }

        [Then(@"TextBox ""([^""]*)"" Is Displayed")]
        public void GivenButtonIsDisplayed(string textBoxName)
        {
            string proc = $"Then TextBox {textBoxName} Is Displayed";
            if (CombinedSteps.OuputProc(proc))
            {
                if (Helpers.TextBox.IsDisplayed(textBoxName))
                {
                    return;
                }
                Assert.Fail(proc + "FAILED");
                return;
            }
            Assert.Inconclusive();
        }

        [Then(@"TextBox ""([^""]*)"" Is Equal To ""([^""]*)""")]
        public void ThenTextBoxIsEqualTo(string textBoxName, string text)
        {
            string proc = $"Then TextBox {textBoxName} Is Equal To {text}";
            if (CombinedSteps.OuputProc(proc))
            {
                if (Helpers.TextBox.GetText(textBoxName) == text)
                {
                    return;
                }
                Assert.Fail(proc + "FAILED");
                return;
            }
            Assert.Inconclusive();
        }

        [Then(@"TextBox ""([^""]*)"" Is Not Equal To ""([^""]*)""")]
        public void ThenTextBoxIsNotEqualTo(string textBoxName, string text)
        {
            string proc = $"Then TextBox {textBoxName} Is Not Equal To {text}";
            if (CombinedSteps.OuputProc(proc))
            {
                if (Helpers.TextBox.GetText(textBoxName) != text)
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
