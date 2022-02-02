using Core;
using Core.Logging;
using Generic.Steps.Helpers.Interfaces;
using TechTalk.SpecFlow;

namespace Generic.Steps.Helpers.Classes
{
    public class TextBoxStepHelper : StepHelper, ITextBoxStepHelper
    {
        private readonly ITargetForms targetForms;
        public TextBoxStepHelper(FeatureContext featureContext, ITargetForms targetForms) : base(featureContext)
        {
            this.targetForms = targetForms;
        }

        public void Hello()
        {
            DebugOutput.Log($"HELLO");
            return;
        }

    }
}
