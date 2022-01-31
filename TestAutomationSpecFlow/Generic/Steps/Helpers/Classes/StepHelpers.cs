using Core;
using Generic.Steps.Helpers.Classes;
using Generic.Steps.Helpers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Generic.Steps.Helpers.Classes
{
    public class StepHelpers : IStepHelpers
    {
        private readonly FeatureContext featureContext;
        private readonly ITargetForms targetForms;

        public StepHelpers(FeatureContext featureContext, ITargetForms targetForms)
        {
            this.featureContext = featureContext;
            this.targetForms = targetForms;
            InitializeHelpers();
        }

        public IButtonStepHelper Button { get; private set; }   

        private void InitializeHelpers()
        {
            Button = new ButtonStepHelper(featureContext);
        }

    }
}
