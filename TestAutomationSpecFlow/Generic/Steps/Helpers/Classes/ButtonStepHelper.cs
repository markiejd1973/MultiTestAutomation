using Core;
using Core.Logging;
using Generic.Steps.Helpers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Generic.Steps.Helpers.Classes
{
    public class ButtonStepHelper : StepHelper, IButtonStepHelper
    {
        private readonly ITargetForms targetForms;
        public ButtonStepHelper(FeatureContext featureContext) : base(featureContext)
        {
            this.targetForms = targetForms;
        }

        public string Hello()
        {
            DebugOutput.Log($"Proc - HELLO");
            //var expectedPage = targetForms["login"];

            return "hello";
        }

    }
}
