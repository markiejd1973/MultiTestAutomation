using Core;
using Generic.Steps.Helpers.Interfaces;
using TechTalk.SpecFlow;

namespace Generic.Steps.Helpers.Classes
{
    public class StepHelpers : IStepHelpers
    {
        private readonly FeatureContext featureContext;
        private readonly ITargetForms targetForms;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public StepHelpers(FeatureContext featureContext, ITargetForms targetForms)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
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
        public IImageStepHelper Image { get; private set; }
        public ILinkStepHelper Link { get; private set; }
        public IPageStepHelper Page { get; private set; }
        public IRadioButtonStepHelper RadioButton { get; private set; }
        public ISpanStepHelper Span { get; private set; }
        public ITableStepHelper Table { get; private set; }
        public ITextBoxStepHelper TextBox { get; private set; }
        public ITreeStepHelper Tree { get; private set; }
        public IWindowStepHelper Window { get; private set; }

        private void InitializeHelpers()
        {
            Accordion = new AccordionStepHelper(featureContext, targetForms);
            Button = new ButtonStepHelper(featureContext, targetForms);
            Image = new ImageStepHelper(featureContext, targetForms);
            Link = new LinkStepHelper(featureContext, targetForms);
            Page = new PageStepHelper(featureContext, targetForms);
            RadioButton = new RadioButtonStepHelper(featureContext, targetForms);
            Span = new SpanStepHelper(featureContext, targetForms);
            Table = new TableStepHelper(featureContext, targetForms);
            TextBox = new TextBoxStepHelper(featureContext, targetForms);
            Tree = new TreeStepHelper(featureContext, targetForms);
            Window = new WindowStepHelper(featureContext, targetForms);
        }

    }
}
