using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Generic.Steps.Helpers.Interfaces;
using Core;
using Core.Logging;

namespace Generic.Steps.Helpers.Classes
{
    public class ButtonStepHelper : StepHelper, IButtonStepHelper
    {
        public ButtonStepHelper(FeatureContext featureContext) : base(featureContext)
        {
        }
        public bool Disabled(string button, int timeOut = 2)
        {
            DebugOutput.Log($"Proc - AssertButtonIsDispabled {button}");

            return true;
        }

    }
}
