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
        public ButtonStepHelper(FeatureContext featureContext) : base(featureContext)
        {
        }

    }
}
