using Core.Logging;
using Generic.Steps;
using Generic.Steps.Helpers.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace Generic.Elements.Steps.Button
{
    [Binding]
    public class ThenRadioButtonSteps : StepsBase
    {
        public ThenRadioButtonSteps(IStepHelpers helpers) : base(helpers)
        {
        }

        [Then(@"RadioButton ""([^""]*)"" Is Displayed")]
        public void ThenRadioButtonIsDisplayed(string radioButtonName)
        {
            string proc = $"Then Radiobutton {radioButtonName} Is Displayed";
            if (CombinedSteps.OuputProc(proc))
            {
                if (Helpers.RadioButton.IsDisplayed(radioButtonName))   
                {
                    return;
                }
                Assert.Fail(proc + "FAILED");
                return;
            }
            Assert.Inconclusive();
        }

        [Then(@"RadioButton ""([^""]*)"" Is Read Only")]
        public void ThenRadioButtonIsReadOnly(string radioButtonName)
        {
            string proc = $"Then Radiobutton {radioButtonName} Is Read Only";
            if (CombinedSteps.OuputProc(proc))
            {
                if (!Helpers.RadioButton.IsEnabled(radioButtonName))
                {
                    return;
                }
                Assert.Fail(proc + "FAILED");
                return;
            }
            Assert.Inconclusive();
        }

        [Then(@"RadioButton ""([^""]*)"" Is Enabled")]
        public void ThenRadioButtonIsEnabled(string radioButtonName)
        {
            string proc = $"Then Radiobutton {radioButtonName} Is Read Only";
            if (CombinedSteps.OuputProc(proc))
            {
                if (Helpers.RadioButton.IsEnabled(radioButtonName))
                {
                    return;
                }
                Assert.Fail(proc + "FAILED");
                return;
            }
            Assert.Inconclusive();
        }

        [Then(@"RadioButton ""([^""]*)"" Is Selected")]
        public void ThenRadioButtonIsSelected(string radioButtonName)
        {
            string proc = $"Then Radiobutton {radioButtonName} Is Selected";
            if (CombinedSteps.OuputProc(proc))
            {
                if (Helpers.RadioButton.IsSelected(radioButtonName))
                {
                    return;
                }
                Assert.Fail(proc + "FAILED");
                return;
            }
            Assert.Inconclusive();
        }

        [Then(@"RadioButton ""([^""]*)"" Is Not Selected")]
        public void ThenRadioButtonIsNotSelected(string radioButtonName)
        {
            string proc = $"Then Radiobutton {radioButtonName} Is Not Selected";
            if (CombinedSteps.OuputProc(proc))
            {
                if (!Helpers.RadioButton.IsSelected(radioButtonName))
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
