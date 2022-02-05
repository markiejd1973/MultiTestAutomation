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

        /// <summary>
        /// Add new ElementStepHelper.cs needs to populate BELOW
        /// </summary>
        public IAccordionStepHelper Accordion { get; private set; }
        public IButtonStepHelper Button { get; private set; }   
        public IPageStepHelper Page { get; private set; }
        public IRadioButtonStepHelper RadioButton { get; private set; }
        public ITextBoxStepHelper TextBox { get; private set; }
        public ITreeStepHelper Tree { get; private set; }   

        private void InitializeHelpers()
        {
            Accordion = new AccordionStepHelper(featureContext, targetForms);
            Button = new ButtonStepHelper(featureContext, targetForms);
            Page = new PageStepHelper(featureContext, targetForms);
            RadioButton = new RadioButtonStepHelper(featureContext, targetForms);
            TextBox = new TextBoxStepHelper(featureContext, targetForms);
            Tree = new TreeStepHelper(featureContext, targetForms);
        }

    }
}
